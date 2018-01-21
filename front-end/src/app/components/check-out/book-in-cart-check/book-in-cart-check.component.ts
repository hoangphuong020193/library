import { Component, OnInit } from '@angular/core';
import { CartService } from '../../../services/cart.service';
import { BookInCartDetail } from '../../../models/book.model';
import * as moment from 'moment';
import { Format } from '../../../shareds/constant/format.constant';
import { DialogService } from 'angularx-bootstrap-modal';
import { PopupConfirmComponent, TypeButton } from '../../common/index';
import { BookStatus } from '../../../shareds/enums/book-status.enum';
import { RouterService } from '../../../services/router.service';
import {
    PopupCheckOutSuccessComponent
} from '../../check-out/popup-check-out-success/popup-check-out-success.component';

@Component({
    selector: 'book-in-cart-check',
    templateUrl: './book-in-cart-check.component.html'
})
export class BookInCartCheckComponent implements OnInit {
    private books: BookInCartDetail[] = [];
    private slotAvailable: number = 0;

    constructor(
        private cartService: CartService,
        private routeService: RouterService,
        private dialogService: DialogService) { }

    public ngOnInit() {
        this.cartService.getBookInCartForBorrow().subscribe((res) => {
            this.books = res;
        });

        this.cartService.getSlotAvailable().subscribe((res) => {
            this.slotAvailable = res;
        });
    }

    private parseDateToString(date: Date): string {
        return moment(date).format(Format.DateFormat);
    }

    private deleteBookInCart(bookId: number): void {
        this.cartService.deleteBookToCart(bookId).subscribe();
        this.books = this.books.filter((x) => x.bookId !== bookId);
    }

    private changeStatusBook(bookId: number): void {
        this.cartService.updateStatusBookInCart(bookId, BookStatus.Waiting).subscribe();
        this.books = this.books.filter((x) => x.bookId !== bookId);
    }

    private onConfirm(): void {
        if (this.slotAvailable > 0 && this.books.length <= this.slotAvailable) {
            this.dialogService.addDialog(PopupConfirmComponent, {
                title: 'Xác nhận mượn sách',
                message: 'Bạn đang đăng ký mượn ' + this.books.length
                    + ' sách. Bấm xác nhận để hoàn tất.',
                typeButton: TypeButton.ConfirmCancel
            }).subscribe((confirm) => {
                if (confirm) {
                    this.cartService.borrowBook().subscribe((res) => {
                        if (res.succeeded) {
                            this.dialogService.addDialog(PopupCheckOutSuccessComponent, {
                                requestCode: res.data
                            }).subscribe((x) => {
                                this.routeService.myBook();
                            });
                        } else {
                            location.reload();
                        }
                    });
                }
            });
        }
    }
}
