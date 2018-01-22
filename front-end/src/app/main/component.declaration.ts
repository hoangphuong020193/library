/*Components*/
import * as fromCommon from '../components/common';
import * as fromHome from '../components/home';
import * as fromLogin from '../components/login';
import * as fromChooseBook from '../components/choose-book';
import * as fromCheckOut from '../components/check-out';
import * as fromMyBook from '../components/my-book';
import * as fromSearchResult from '../components/search-result';

export const CommonComponents: any = [
    fromCommon.FavoriteStarComponent,
    fromCommon.ToastComponent,
    fromCommon.PopupConfirmComponent,
    fromCommon.CheckboxComponent,
    fromCommon.PaginationComponent,
    fromCommon.LoadingPageComponent,
];

export const Components: any = [
    fromHome.HomeComponent,
    fromLogin.LoginPopupComponent,
    fromChooseBook.ChooseBookComponent,
    fromChooseBook.BookSectionComponent,
    fromChooseBook.BookItemComponent,
    fromChooseBook.BookDetailComponent,
    fromCheckOut.CheckOutComponent,
    fromCheckOut.BookInCartComponent,
    fromCheckOut.BookInCartCheckComponent,
    fromCheckOut.PopupCheckOutSuccessComponent,
    fromMyBook.MyBookComponent,
    fromSearchResult.SearchResultComponent,
];

// Modal
export const LoginPopupComponent: any = fromLogin.LoginPopupComponent;
export const PopupConfirmComponent: any = fromCommon.PopupConfirmComponent;
export const PopupCheckOutSuccessComponent: any = fromCheckOut.PopupCheckOutSuccessComponent;
