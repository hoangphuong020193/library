/*Components*/
import * as fromCommon from '../components/common';
import * as fromHome from '../components/home';
import * as fromLogin from '../components/login';
import * as fromChooseBook from '../components/choose-book';
import * as fromCheckOut from '../components/check-out';

export const CommonComponents: any = [
    fromCommon.FavoriteStarComponent,
    fromCommon.ToastComponent
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
    fromCheckOut.BookInCartCheckComponent
];

// Modal
export const LoginPopupComponent: any = fromLogin.LoginPopupComponent;
