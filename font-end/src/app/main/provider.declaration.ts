import { Http, RequestOptions } from '@angular/http';
import { AuthConfig, AuthHttp } from 'angular2-jwt';
import { ErrorHandler } from '@angular/core';

// Service
import { LoginService } from '../../services/login.service';
import { RouterService } from '../services/route.service';
import { LsHelper } from 'app/shareds/helpers/ls.helper';

export const services: any = [
    RouterService,
    LoginService,
    {
        provide: AuthHttp,
        useFactory: (http: Http, options: RequestOptions) => {
            return new AuthHttp(new AuthConfig({
                tokenName: 'accessToken',
                tokenGetter: (() => LsHelper.getAccessToken()),
                globalHeaders: [
                    {
                        'Content-Type': 'application/json'
                    },
                    {
                        'X-Requested-With': 'XMLHttpRequest'
                    }],
            }), http, options);
        },
        deps: [Http, RequestOptions]
    }
];

export const guards: any = [];
