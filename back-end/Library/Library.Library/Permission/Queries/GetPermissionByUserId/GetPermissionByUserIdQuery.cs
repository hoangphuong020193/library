﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Library.Permission.ViewModels;
using Library.Data.Services;
using Library.Data.Entities.Library;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Permission.Queries.GetPermissionByUserId
{
    public class GetPermissionByUserIdQuery : IGetPermissionByUserIdQuery
    {
        private readonly IRepository<PermissionGroup> _permissionRepository;
        private readonly IRepository<PermissionGroupMember> _permissionMemberRepository;

        public GetPermissionByUserIdQuery(
            IRepository<PermissionGroup> permissionRepository,
            IRepository<PermissionGroupMember> permissionMemberRepository)
        {
            _permissionRepository = permissionRepository;
            _permissionMemberRepository = permissionMemberRepository;
        }

        public async Task<List<PermissionViewModel>> ExecuteAsync(int userId)
        {
            var groups = (from permission in _permissionRepository.TableNoTracking.AsQueryable()
                          join permissionMember in _permissionMemberRepository.TableNoTracking.AsQueryable()
                          on permission.Id equals permissionMember.GroupId
                          where permission.Enabled == true && permissionMember.UserId == userId
                          select new PermissionViewModel
                          {
                              GroupPermissionId = permission.Id,
                              GroupPermissionName = permission.GroupName
                          });

            return await groups.GroupBy(p => p.GroupPermissionId).Select(pg => pg.First()).ToListAsync();
        }
    }
}