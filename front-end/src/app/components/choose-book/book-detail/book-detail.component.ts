import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as fromRoot from '../../../store/reducers';
import { BookService } from '../../../services/book.service';
import { Book } from '../../../models/index';
import { JQueryHelper } from '../../../shareds/helpers/jquery.helper';
import { RouterService } from '../../../services/router.service';
import { Config } from '../../../config';
import { CartService } from '../../../services/cart.service';

@Component({
    selector: 'book-detail',
    templateUrl: './book-detail.component.html'
})

export class BookDetailComponent implements OnInit {
    private book: Book = new Book();
    private bookImgURL = '';

    constructor(
        private store: Store<fromRoot.State>,
        private bookService: BookService,
        private cartService: CartService,
        private routerService: RouterService) { }

    public ngOnInit() {
        JQueryHelper.showLoading();
        this.store.select(fromRoot.getSelectedBookCode).first().subscribe((bookCode) => {
            if (bookCode) {
                this.bookService.getBookDetailByCode(bookCode).subscribe((res) => {
                    if (res) {
                        this.book = res;
                        this.bookImgURL = Config.getBookImgApiUrl(this.book.bookCode);
                        JQueryHelper.hideLoading();
                    } else {
                        this.routerService.home();
                    }
                });
            }
        });
    }

    private addBookToCart(): void {
        this.cartService.addBookToCart(this.book.bookId).subscribe();
    }
}
