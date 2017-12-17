import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../../services/login.service';
import { User } from '../../../model/user.model';
import { Login } from '../../../model/login.model';
import { LsHelper } from '../../shareds/helpers/ls.helper';
import { RouterService } from '../../services/route.service';
import { DialogComponent, DialogService } from 'angularx-bootstrap-modal';
import { ComponentId } from '../../shareds/enums/component.enum';
import $ from 'jquery';

@Component({
    selector: 'login',
    templateUrl: 'login.component.html'
})

export class LoginPopupComponent extends DialogComponent<any, any> implements OnInit {
    public componentId: number = ComponentId.SelectBooks;
    private loading: boolean = false;
    private errorMessage: string = '';

    constructor(
        private loginService: LoginService,
        private routerService: RouterService,
        public dialogService: DialogService
    ) {
        super(dialogService);
    }

    public ngOnInit(): void {
        // if (LsHelper.getAccessToken()) {
        //     this.routerService.home();
        // }
    }

    public onLogin(): void {
        this.loading = true;
        const modelLogin: Login = new Login();
        modelLogin.password = $('#username').val().toString();
        modelLogin.username = $('#password').val().toString();

        this.loginService.login(modelLogin).subscribe((res) => {
            if (res && res.accessToken) {
                const user: User = this.loginService.createUserFromToken(res.accessToken);
            } else {
                this.errorMessage = 'Sai tên đăng nhập hoặc mật khẩu';
            }
            this.loading = false;
        }, (err) => {
            this.loading = false;
            this.errorMessage = 'Không thể kết nối server';
        });

    }
}
