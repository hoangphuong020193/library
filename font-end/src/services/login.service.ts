import { Injectable } from '@angular/core';
import { Headers, Http, RequestOptions } from '@angular/http';
import { AuthHttp, JwtHelper } from 'angular2-jwt';
import { Observable } from 'rxjs';
import { Login } from '../model/login.model';
import { Config, PathController } from '../app/config';
import { User } from '../model/user.model';
import { map } from 'rxjs/operators/map';

@Injectable()
export class LoginService {
    constructor(
        private http: Http,
        private authHttp: AuthHttp) { }

    public login(loginModel: Login): Observable<any> {
        const url: string = Config.getPath(PathController.Account);
        //const headers: Headers = new Headers({ 'Content-Type': 'application/json' });
        //return this.http.post(url + '/Login', JSON.stringify(loginModel), { headers })
        return this.http.get(url + '/PingAPI')
            .map((res) => res.json())
            .catch((err) => {
                console.error(err);
                return Observable.throw(err);
            });
    }

    public createUserFromToken(token: string): User {
        const user: User = this.parseUserFromToken(token);
        return user;
    }

    private parseUserFromToken(token: string): User {
        const user: User = new User();
        user.accessToken = token;

        try {
            const jwtHelper: JwtHelper = new JwtHelper();
            const decodedToken: any = jwtHelper.decodeToken(token);
            user.userName = decodedToken.sub;
            user.displayName = decodedToken.displayName;
            user.firstName = decodedToken.fistName;
            user.lastName = decodedToken.lastName;
            user.middleName = decodedToken.middleName;
            return user;
        } catch (err) {
            console.error(err);
            return user;
        }
    }

}
