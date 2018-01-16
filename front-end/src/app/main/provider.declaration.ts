import { ErrorHandler } from '@angular/core';

/* Http Services */
import { Http, RequestOptions } from '@angular/http';
import { JwtModule } from '@auth0/angular-jwt';

/* Guards */
import { HomeGuard } from '../guards/home.guard';
import { BookDetailGuard } from '../guards/book-detail.guard';

/* Services */
import { RouterService } from '../services/router.service';
import { LoginService } from '../services/login.service';
import { CategoryService } from '../services/category.service';
import { BookService } from '../services/book.service';
import { CartService } from '../services/cart.service';

/* Handlers */
import { SystemErrorHandler, ResponseHandler } from '../shareds/helpers';
import { LsHelper } from '../shareds/helpers';

export const services: any = [
    RouterService,
    LoginService,
    CategoryService,
    BookService,
    CartService,
    {
        provide: ErrorHandler,
        useClass: SystemErrorHandler
    },
    ResponseHandler
];

export const guards: any = [
    HomeGuard,
    BookDetailGuard
];
