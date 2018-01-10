import { Component, OnInit } from '@angular/core';
import { DialogService } from 'angularx-bootstrap-modal';
import { ComponentId } from '../../shareds/enums/component.enum';
import { User } from '../../models/user.model';
import { Store } from '@ngrx/store';
import * as fromRoot from '../../store/reducers';
import * as userAction from '../../store/actions/user.action';
import { JQueryHelper } from '../../shareds/helpers/jquery.helper';
import { RouterService } from '../../services/router.service';
import { LoginPopupComponent } from '../login/login.component';

@Component({
  selector: 'home',
  templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
  private ComponentId: any = ComponentId;
  private user: User = null;

  private toggleMenuNotify: boolean = false;
  private toggleMenuLogin: boolean = false;

  constructor(
    private store: Store<fromRoot.State>,
    private dialogService: DialogService,
    private routerService: RouterService) { }

  public ngOnInit(): void {
    this.store.select(fromRoot.getCurrentUser).subscribe((user: User) => {
      this.user = user;
    });

    JQueryHelper.onClickOutside('.user-login', () => {
      this.toggleMenuLogin = false;
    });
    JQueryHelper.onClickOutside('.user-notify', () => {
      this.toggleMenuNotify = false;
    });
  }

  private viewMenuLogin(): void {
    if (!this.user) {
      this.dialogService.addDialog(LoginPopupComponent, {}).subscribe();
    } else {
      this.toggleMenuLogin = !this.toggleMenuLogin;
    }
  }

  private navigateToHome(): void {
    this.routerService.home();
  }

  private logout(event: any): void {
    this.store.dispatch(new userAction.Logout(null));
    this.user = null;
    event.stopPropagation();
    this.toggleMenuLogin = false;
  }

  private viewMenuNotify(): void {
    this.toggleMenuNotify = !this.toggleMenuNotify;
  }

  private viewBookInCart(): void {
    if (!this.user) {
      this.dialogService.addDialog(LoginPopupComponent, {}).subscribe();
    } else {
      this.routerService.checkOutCart();
    }
  }
}
