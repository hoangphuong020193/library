import { ErrorHandler } from '@angular/core';

/* Http Services */
import { Http, RequestOptions } from '@angular/http';
import { JwtModule } from '@auth0/angular-jwt';

/* Guards */
import { HomeGuard } from '../guards/home.guard';

/* Services */
import { RouterService } from '../services/router.service';
import { LoginService } from '../services/login.service';

/* Handlers */
import { SystemErrorHandler, ResponseHandler } from '../shareds/helpers';
import { LsHelper } from '../shareds/helpers';

export const services: any = [
    RouterService,
    LoginService,
    {
        provide: ErrorHandler,
        useClass: SystemErrorHandler
    },
    ResponseHandler
];

export const guards: any = [
    HomeGuard
];
