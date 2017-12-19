import { Component, OnInit } from '@angular/core';
import { DialogService } from 'angularx-bootstrap-modal';
import { ComponentId } from '../../shareds/enums/component.enum';
import { LoginPopupComponent } from 'app/components/login';

@Component({
  selector: 'home',
  templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
  private ComponentId: any = ComponentId;
  constructor(private dialogService: DialogService) { }

  public ngOnInit(): void { }

  private login(componentId: number): void {
    this.dialogService.addDialog(LoginPopupComponent, {
      componentId
    }).subscribe();
  }
}
