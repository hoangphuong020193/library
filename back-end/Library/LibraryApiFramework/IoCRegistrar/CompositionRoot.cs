﻿using AutoMapper;
using DryIoc;
using Library.Data.Services;
using Library.Library.Permission.Queries.GetPermissionByUserId;
using Library.Library.UserAccount.Queries.GetUserByUserName;
using System;
using System.Net.Http;

namespace Library.ApiFramework.IoCRegistrar
{
    public class CompositionRoot
    {
        public CompositionRoot(IRegistrator registrator)
        {
            // general
            registrator.RegisterDelegate(resolver => Mapper.Instance, Reuse.Singleton);
            registrator.Register<Lazy<HttpClient>>(Reuse.InWebRequest);
            registrator.Register<IDbContext, ApplicationDbContext>(Reuse.InWebRequest);
            registrator.Register(typeof(IRepository<>), typeof(EfRepository<>), Reuse.InWebRequest);

            // User
            registrator.Register<IGetUserByUserNameQuery, GetUserByUserNameQuery>(Reuse.InWebRequest);

            // Permission
            registrator.Register<IGetPermissionByUserIdQuery, GetPermissionByUserIdQuery>(Reuse.InWebRequest);
        }
    }
}