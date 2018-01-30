using AutoMapper;
using DryIoc;
using Library.Data.Services;
using Library.Library.Admin.Queries.GetListUserNotReturnBook;
using Library.Library.BookRequest.Queries.GetRequestInfoByCode;
using Library.Library.Books.Commands.CancelBook;
using Library.Library.Books.Commands.ReturnBook;
using Library.Library.Books.Commands.SaveBook;
using Library.Library.Books.Commands.SaveBookImage;
using Library.Library.Books.Commands.TakenBook;
using Library.Library.Books.Queries.CheckBookExistsCode;
using Library.Library.Books.Queries.GetBookBorrow;
using Library.Library.Books.Queries.GetBookByBookCode;
using Library.Library.Books.Queries.GetBookDetail;
using Library.Library.Books.Queries.GetBookPhoto;
using Library.Library.Books.Queries.GetBookSection;
using Library.Library.Books.Queries.GetBookViewByCategory;
using Library.Library.Books.Queries.GetListBook;
using Library.Library.Books.Queries.GetListBookByRequestCode;
using Library.Library.Books.Queries.GetListNewBook;
using Library.Library.Books.Queries.SearchBook;
using Library.Library.Cart.Commands.AddBookToCart;
using Library.Library.Cart.Commands.BorrowBook;
using Library.Library.Cart.Commands.DeleteToCart;
using Library.Library.Cart.Commands.UpdateStatusBookInCart;
using Library.Library.Cart.Queries.GetBookInCartDetail;
using Library.Library.Cart.Queries.GetBookInCartForBorrow;
using Library.Library.Cart.Queries.GetListBookInCart;
using Library.Library.Cart.Queries.GetSlotAvailable;
using Library.Library.Categories.Queries.GetCategory;
using Library.Library.Favorites.Commands.UpdateBookFavorite;
using Library.Library.Permission.Queries.GetPermissionByUserId;
using Library.Library.Publishers.Queries.GetListPublisher;
using Library.Library.Suppliers.Commands.SaveSupplier;
using Library.Library.Suppliers.Queries.GetListSupplier;
using Library.Library.UserAccount.Queries.GetUserInfo;
using Library.Library.UserAccount.Queries.GetUserInfoLogin;
using Library.Library.Users.Queries.GetUserNotification;
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
            registrator.Register<IGetBookSectionQuery, GetBookSectionQuery>(Reuse.InWebRequest);
            registrator.Register<IGetListBookQuery, GetListBookQuery>(Reuse.InWebRequest);
            registrator.Register<ICheckBookCodeExistsQuery, CheckBookCodeExistsQuery>(Reuse.InWebRequest);
            registrator.Register<ISaveBookCommand, SaveBookCommand>(Reuse.InWebRequest);
            registrator.Register<IGetBookByBookCodeQuery, GetBookByBookCodeQuery>(Reuse.InWebRequest);
            registrator.Register<ISaveBookImageCommand, SaveBookImageCommand>(Reuse.InWebRequest);

            // Cart
            registrator.Register<IGetBookInCartForBorrowQuery, GetBookInCartForBorrowQuery>(Reuse.InWebRequest);
            registrator.Register<IGetListBookInCartQuery, GetListBookInCartQuery>(Reuse.InWebRequest);
            registrator.Register<IGetBookInCartDetailQuery, GetBookInCartDetailQuery>(Reuse.InWebRequest);
            registrator.Register<IGetSlotAvailableQuery, GetSlotAvailableQuery>(Reuse.InWebRequest);
            registrator.Register<IAddBookToCartCommand, AddBookToCartCommand>(Reuse.InWebRequest);
            registrator.Register<IDeleteToCartCommand, DeleteToCartCommand>(Reuse.InWebRequest);
            registrator.Register<IUpdateStatusBookInCartCommand, UpdateStatusBookInCartCommand>(Reuse.InWebRequest);
            registrator.Register<IBorrowBookCommand, BorrowBookCommand>(Reuse.InWebRequest);
            registrator.Register<IGetBookViewByCategoryQuery, GetBookViewByCategoryQuery>(Reuse.InWebRequest);

            // Favorite
            registrator.Register<IUpdateBookFavoriteCommand, UpdateBookFavoriteCommand>(Reuse.InWebRequest);

            // User book
            registrator.Register<IGetBookBorrowQuery, GetBookBorrowQuery>(Reuse.InWebRequest);
            registrator.Register<IGetListBookByRequestCodeQuery, GetListBookByRequestCodeQuery>(Reuse.InWebRequest);
            registrator.Register<ITakenBookCommand, TakenBookCommand>(Reuse.InWebRequest);
            registrator.Register<IReturnBookCommand, ReturnBookCommand>(Reuse.InWebRequest);
            registrator.Register<ICancelBookCommand, CancelBookCommand>(Reuse.InWebRequest);

            // Search
            registrator.Register<ISearchBookQuery, SearchBookQuery>(Reuse.InWebRequest);

            // User notification
            registrator.Register<IGetUserNotificationQuery, GetUserNotificationQuery>(Reuse.InWebRequest);

            // Request
            registrator.Register<IGetRequestInfoByCodeQuery, GetRequestInfoByCodeQuery>(Reuse.InWebRequest);

            // Publisher
            registrator.Register<IGetListPublisherQuery, GetListPublisherQuery>(Reuse.InWebRequest);

            // Supplier
            registrator.Register<IGetListSupplier, GetListSupplier>(Reuse.InWebRequest);
            registrator.Register<ISaveSupplierCommand, SaveSupplierCommand>(Reuse.InWebRequest);

            // Admin
            registrator.Register<IGetListUserNotReturnBookQuery, GetListUserNotReturnBookQuery>(Reuse.InWebRequest);
        }
    }
}
