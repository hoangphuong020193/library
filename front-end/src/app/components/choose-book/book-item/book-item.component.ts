import { Component, OnInit, Input } from '@angular/core';
import { Book } from '../../../models/index';
import { RouterService } from '../../../services/router.service';
import { State } from '../../../store/reducers/book/index';
import { Store } from '@ngrx/store';
import * as fromRoot from '../../../store/reducers';
import * as bookAction from '../../../store/actions/book.action';
import { Config } from '../../../config';
import { CartService } from '../../../services/cart.service';

@Component({
    selector: 'book-item',
    templateUrl: './book-item.component.html'
})
export class BookItemComponent implements OnInit {
    @Input('book') public book: Book;

    private bookImgURL = '';

    constructor(
        private routerService: RouterService,
        private store: Store<fromRoot.State>,
        private cartService: CartService) { }

    public ngOnInit(): void {
        this.bookImgURL = Config.getBookImgApiUrl(this.book.bookCode);
    }

    private navigateToBookDetail(): void {
        this.routerService.bookDetail(this.book.bookCode);
        this.store.dispatch(new bookAction.SelectedBook(this.book.bookCode));
    }

    private addBookToCart(): void {
        this.cartService.addBookToCart(this.book.bookId).subscribe();
    }
}
