import { Component, OnInit } from '@angular/core';
import { DialogService } from 'angularx-bootstrap-modal';
import { ComponentId } from '../../shareds/enums/component.enum';
import { LoginPopupComponent } from 'app/components/login';
import { User } from '../../models/user.model';
import { Store } from '@ngrx/store';
import * as fromRoot from '../../store/reducers';
import * as userAction from '../../store/actions/user.action';

@Component({
  selector: 'home',
  templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
  private ComponentId: any = ComponentId;

  private user: User = null;

  constructor(
    private store: Store<fromRoot.State>,
    private dialogService: DialogService) { }

  public ngOnInit(): void {
    this.store.select(fromRoot.getCurrentUser).subscribe((user: User) => {
      this.user = user;
    });
  }

  private login(componentId: number): void {
    this.dialogService.addDialog(LoginPopupComponent, {
      componentId
    }).subscribe();
  }
}
