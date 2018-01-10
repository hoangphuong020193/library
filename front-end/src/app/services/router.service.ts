import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { JsHelper } from '../common/helpers/js.helper';
import { LsHelper } from '../common/helpers/ls.helper';
import * as fromRoot from '../store/reducers';

@Injectable()
export class RouterService {
    constructor(
        private router: Router,
        private store: Store<fromRoot.State>) { }

    public navigate(url: string): void {
        this.router.navigateByUrl(url);
    }

    public home(): void {
        this.router.navigate(['/home']);
    }

    public permissionDenied(): void {
        this.router.navigate(['/error/permission-denied']);
    }

    public bookDetail(bookCode: string): void {
        this.router.navigate(['/book-detail', bookCode]);
    }

    public checkOutCart(): void {
        this.router.navigate(['/checkout/cart']);
    }
}
