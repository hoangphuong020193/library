using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Data.Entities.Account;
using Library.Data.Entities.Library;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using System.Data;
using System.Data.Common;

namespace Library.Data.Services
{
    public partial class ApplicationDbContext : DbContext, IDbContext
    {
        public virtual DbSet<PermissionGroup> PermissionGroup { get; set; }
        public virtual DbSet<PermissionGroupMember> PermissionGroupMember { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<User> User { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=library;Trusted_Connection=True;");
        //            }
        //        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionGroup>(entity =>
            {
                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<PermissionGroupMember>(entity =>
            {
                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.PermissionGroupMember)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Permissio__Group__2E1BDC42");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PermissionGroupMember)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Permissio__UserI__2F10007B");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.ShortName).HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__User__C9F2845693CCEBA5")
                    .IsUnique();

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.FirstName).HasColumnType("nchar(20)");

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasColumnType("nchar(50)");

                entity.Property(e => e.MiddleName).HasColumnType("nchar(20)");

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.PersonalEmail).HasColumnType("nchar(100)");

                entity.Property(e => e.PhoneNumber).HasColumnType("nchar(15)");

                entity.Property(e => e.SchoolEmail).HasColumnType("nchar(50)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("nchar(15)");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("FK__User__TitleId__276EDEB3");
            });
        }

        public Task<int> SaveChangesAsync()
        {
            var validationErrors = ChangeTracker
                .Entries<IValidatableObject>()
                .SelectMany(e => e.Entity.Validate(null))
                .Where(r => r != ValidationResult.Success)
                .ToArray();

            if (validationErrors.Any())
            {
                var exceptionMessage = string.Join(Environment.NewLine, validationErrors.Select(error => string.Format("Properties {0} Error: {1}", error.MemberNames, error.ErrorMessage)));
                throw new Exception(exceptionMessage);
            }

            return base.SaveChangesAsync();
        }

        public Task<int> ExecuteSqlCommandAsync(string commandText,
            params object[] parameters) => Database.ExecuteSqlCommandAsync(commandText, parameters: parameters);

        public async Task<List<Dictionary<string, object>>> ExecuteStoredProcedureListAsync(string commandText,
           params object[] parameters)
        {
            using (var cmd = Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0)
                {
                    for (var i = 0; i <= parameters.Length - 1; i++)
                    {
                        var p = parameters[i] as DbParameter;
                        if (p == null)
                        {
                            throw new Exception("Not support parameter type");
                        }
                        cmd.Parameters.Add(p);
                    }
                }

                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                var list = new List<Dictionary<string, object>>();
                using (var dataReader = await cmd.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        var dataRow = new Dictionary<string, object>();
                        for (var iField = 0; iField < dataReader.FieldCount; iField++)
                        {
                            dataRow.Add(dataReader.GetName(iField),
                                dataReader.IsDBNull(iField) ? null : dataReader[iField]);
                        }
                        list.Add(dataRow);
                    }
                }
                return list;
            }
        }
    }

}
