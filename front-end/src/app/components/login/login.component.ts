import { Component, OnInit } from '@angular/core';
import { LsHelper } from '../../shareds/helpers/ls.helper';
import { DialogComponent, DialogService } from 'angularx-bootstrap-modal';
import { LoginService } from '../../services/login.service';
import { RouterService } from '../../services/router.service';
import { Login, User } from '../../models';
import $ from 'jquery';
import { Store } from '@ngrx/store';
import * as fromRoot from '../../store/reducers';
import * as userAction from '../../store/actions/user.action';
import { KeyCode } from '../../shareds/enums/keycode.enum';

@Component({
    selector: 'login',
    templateUrl: 'login.component.html'
})

export class LoginPopupComponent extends DialogComponent<any, any> implements OnInit {
    private loading: boolean = false;
    private errorMessage: string = '';
    private errorUser: boolean = false;
    private errorPassword: boolean = false;

    constructor(
        private loginService: LoginService,
        private routerService: RouterService,
        public dialogService: DialogService,
        private store: Store<fromRoot.State>
    ) {
        super(dialogService);
    }

    public ngOnInit(): void {
        if (LsHelper.getAccessToken()) {
            this.close();
        }
    }

    public onLogin(): void {
        this.loading = true;
        const modelLogin: Login = new Login();
        modelLogin.username = $('#username').val().toString();
        modelLogin.password = $('#password').val().toString();

        this.errorUser = this.errorPassword = false;

        if (modelLogin.username === '') {
            this.errorUser = true;
            return;
        } else if (modelLogin.password === '') {
            this.errorPassword = true;
            return;
        }

        this.loginService.login(modelLogin).subscribe((res) => {
            if (res && res.accessToken) {
                this.errorMessage = '';
                const user: User = this.loginService.createUserFromToken(res.accessToken);
                this.store.dispatch(new userAction.UpdateUser(user));
                this.close();
            } else {
                this.errorMessage = 'Sai tên đăng nhập hoặc mật khẩu';
            }
            this.loading = false;
        }, (err) => {
            this.loading = false;
            this.errorMessage = 'Không thể kết nối server';
        });

    }

    public onKeyPress(event: any): void {
        if (event.keyCode === KeyCode.Enter) {
            this.onLogin();
        }
    }
}
