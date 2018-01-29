import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as fromRoot from '../../../store/reducers';
import { Supplier } from '../../../models/index';
import { DialogService } from 'angularx-bootstrap-modal';
import { SupplierEditorPopupComponent } from './supplier-editor-popup/supplier-editor-popup.component';
import { JQueryHelper } from '../../../shareds/helpers/jquery.helper';

@Component({
    selector: 'supplier-management',
    templateUrl: './supplier-management.component.html'
})

export class SupplierManagementComponent implements OnInit {

    private listSuppliers: Supplier[] = [];

    constructor(
        private store: Store<fromRoot.State>,
        private dialogService: DialogService) { }

    public ngOnInit(): void {
        JQueryHelper.showLoading();
        this.store.select(fromRoot.getSupplier).subscribe((res) => {
            this.listSuppliers = res;
            JQueryHelper.hideLoading();
        });
    }

    private addNew(): void {
        this.supplierEditor(new Supplier());
    }

    private supplierEditor(supplier: Supplier): void {
        this.dialogService.addDialog(SupplierEditorPopupComponent, {
            supplier
        }).subscribe((res) => {
            if (res) {

            }
        });
    }
}
