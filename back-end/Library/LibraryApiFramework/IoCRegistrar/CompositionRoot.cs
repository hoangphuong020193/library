using AutoMapper;
using DryIoc;
using Library.Data.Services;
using Library.Library.Books.Queries.GetBookDetail;
using Library.Library.Books.Queries.GetBookInCart;
using Library.Library.Books.Queries.GetBookPhoto;
using Library.Library.Books.Queries.GetListNewBook;
using Library.Library.Cart.Commands.AddBookToCart;
using Library.Library.Cart.Commands.DeleteToCart;
using Library.Library.Cart.Commands.UpdateStatusBookInCart;
using Library.Library.Categories.Queries.GetCategory;
using Library.Library.Favorites.Commands.UpdateBookFavorite;
using Library.Library.Permission.Queries.GetPermissionByUserId;
using Library.Library.UserAccount.Queries.GetUserInfo;
using Library.Library.UserAccount.Queries.GetUserInfoLogin;
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
            registrator.Register<IGetUserInfoLoginQuery, GetUserInfoLoginQuery>(Reuse.InWebRequest);
            registrator.Register<IGetUserInfoQuery, GetUserInfoQuery>(Reuse.InWebRequest);

            // Permission
            registrator.Register<IGetPermissionByUserIdQuery, GetPermissionByUserIdQuery>(Reuse.InWebRequest);

            // Category
            registrator.Register<IGetCategoryQuery, GetCategoryQuery>(Reuse.InWebRequest);

            // Book
            registrator.Register<IGetBookPhotoQuery, GetBookPhotoQuery>(Reuse.InWebRequest);
            registrator.Register<IGetListBookNewQuery, GetListBookNewQuery>(Reuse.InWebRequest);
            registrator.Register<IGetBookDetailQuery, GetBookDetailQuery>(Reuse.InWebRequest);
            registrator.Register<IGetBookInCartQuery, GetBookInCartQuery>(Reuse.InWebRequest);

            // Cart
            registrator.Register<IAddBookToCartCommand, AddBookToCartCommand>(Reuse.InWebRequest);
            registrator.Register<IDeleteToCartCommand, DeleteToCartCommand>(Reuse.InWebRequest);
            registrator.Register<IUpdateStatusBookInCartCommand, UpdateStatusBookInCartCommand>(Reuse.InWebRequest);

            // Favorite
            registrator.Register<IUpdateBookFavoriteCommand, UpdateBookFavoriteCommand>(Reuse.InWebRequest);
        }
    }
}
