import { Component, OnInit } from '@angular/core';
import { Config } from '../../../config';
import { CartService } from '../../../services/cart.service';
import { BookInCart } from '../../../models/index';
import { BookStatus } from '../../../shareds/enums/book-status.enum';
import { Store } from '@ngrx/store';
import * as fromRoot from '../../../store/reducers';
import { RouterService } from '../../../services/router.service';

@Component({
    selector: 'book-in-cart',
    templateUrl: './book-in-cart.component.html'
})
export class BookInCartComponent implements OnInit {
    private bookAvailable: BookInCart[] = [];
    private bookWaiting: BookInCart[] = [];
    private BookStatus: any = BookStatus;

    constructor(
        private cartService: CartService,
        private store: Store<fromRoot.State>,
        private router: RouterService) { }

    public ngOnInit(): void {
        this.cartService.getBookInCart().subscribe();
        this.store.select(fromRoot.getBookInCart).subscribe((res) => {
            if (res) {
                this.bookAvailable = res.filter((x) => x.status === BookStatus.InOrder);
                this.bookWaiting = res.filter((x) => x.status === BookStatus.Waiting);
            }
        });
    }

    private getBookImgURL(bookCode: string): string {
        return Config.getBookImgApiUrl(bookCode);
    }

    private deleteBookInCart(bookId: number): void {
        this.cartService.deleteBookToCart(bookId).subscribe();
    }

    private changeStatusBook(bookId: number, status: number): void {
        this.cartService.updateStatusBookInCart(bookId, status).subscribe();
    }
}
