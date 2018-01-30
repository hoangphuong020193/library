import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as fromRoot from '../../../store/reducers';
import { Supplier } from '../../../models/index';
import { DialogService } from 'angularx-bootstrap-modal';
import { SupplierEditorPopupComponent } from './supplier-editor-popup/supplier-editor-popup.component';
import { JQueryHelper } from '../../../shareds/helpers/jquery.helper';
import { JsHelper } from '../../../shareds/helpers/js.helper';
import { SupplierService } from '../../../services/supplier.service';

@Component({
    selector: 'supplier-management',
    templateUrl: './supplier-management.component.html'
})

export class SupplierManagementComponent implements OnInit {

    private listSuppliers: Supplier[] = [];

    constructor(
        private store: Store<fromRoot.State>,
        private supplierService: SupplierService,
        private dialogService: DialogService) { }

    public ngOnInit(): void {
        JQueryHelper.showLoading();
        this.store.select(fromRoot.getSupplier).subscribe((res) => {
            if (res) {
                this.listSuppliers = res;
                JQueryHelper.hideLoading();
            }
        });
    }

    private addNew(): void {
        this.supplierEditor(new Supplier());
    }

    private supplierEditor(supplier: Supplier, index: number = -1): void {
        this.dialogService.addDialog(SupplierEditorPopupComponent, {
            supplier: JsHelper.cloneObject(supplier)
        }).subscribe((res) => {
            if (index === -1) {
                this.listSuppliers.push(res);
            } else {
                this.listSuppliers[index] = res;
            }
        });
    }

    private updateStatus(index: number, enabled: boolean): void {
        this.listSuppliers[index].enabled = enabled;
        this.supplierService.saveSupplier(this.listSuppliers[index]).subscribe();
    }
}
