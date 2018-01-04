/*Components*/
import * as fromCommon from 'app/components/common';
import * as fromHome from 'app/components/home';
import * as fromLogin from 'app/components/login';
import * as fromChooseBook from 'app/components/choose-book';

export const CommonComponents: any = [
    fromCommon.FavoriteStarComponent
];

export const Components: any = [
    fromHome.HomeComponent,
    fromLogin.LoginPopupComponent,
    fromChooseBook.ChooseBookComponent,
    fromChooseBook.BookSectionComponent,
    fromChooseBook.BookItemComponent
];

// Modal
export const LoginPopupComponent: any = fromLogin.LoginPopupComponent;
