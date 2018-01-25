import { Component, OnInit } from '@angular/core';
import { KeyCode } from '../../../shareds/enums/keycode.enum';
import { BookService } from '../../../services/book.service';
import { MyBook } from '../../../models/my-book.model';
import { JQueryHelper } from '../../../shareds/helpers/jquery.helper';
import * as moment from 'moment';
import { Format } from '../../../shareds/constant/format.constant';
import { BookStatus } from '../../../shareds/enums/book-status.enum';
import { UserBookRequest } from '../../../models/user-book-request.model';

@Component({
    selector: 'borrow-return-book',
    templateUrl: './borrow-return-book.component.html'
})
export class BorrowReturnBookComponent implements OnInit {
    private listBooks: MyBook[] = [];
    private requestInfo: UserBookRequest = new UserBookRequest();
    private onlyRequest: boolean = false;
    private code: string = '';
    private BookStatus: any = BookStatus;

    constructor(
        private bookService: BookService) { }

    public ngOnInit() { }

    private onKeyPress(event: any): void {
        if (event.keyCode === KeyCode.Enter || event.keyChar === KeyCode.Enter) {
            this.searchCode();
        }
    }

    private searchCode(): void {
        this.code = $('#search-code-box').val().toString();
        if (this.code === '' || this.code === null || this.code === undefined) {
            return;
        }
        JQueryHelper.showLoading();
        this.bookService.getListBookByCode(this.code).subscribe((res) => {
            this.listBooks = res;
            if (res.length) {
                const codeFirst: string = this.listBooks[0].requestCode;
                this.onlyRequest = this.listBooks.every((x) => x.requestCode === codeFirst);
                this.getRequestInfo(codeFirst);
            }
            JQueryHelper.hideLoading();
        });
    }

    private getRequestInfo(code: string): void {
        this.bookService.getRequestInfo(code).subscribe((res) => {
            if (res) {
                this.requestInfo = res;
            } else {
                this.requestInfo = new UserBookRequest();
            }
        });
    }

    private parseDateToString(date: Date): string {
        if (date == null) {
            return '-';
        }
        return moment(date).format(Format.DateTimeFormat);
    }

    private getStatus(status: number): string {
        switch (status) {
            case BookStatus.Pending:
                return 'Chờ nhận';
            case BookStatus.Borrowing:
                return 'Đang mượn';
            case BookStatus.OutDeadline:
                return 'Hết hạn mượn';
            case BookStatus.Returned:
                return 'Đã trả';
            case BookStatus.Cancel:
                return 'Huỷ';
        }
    }

    private takenBook(bookCode: string, index: number): void {
        this.bookService.takenBook(this.requestInfo.userId, bookCode, this.requestInfo.requestId)
            .subscribe((res) => {
                if (res) {
                    this.listBooks[index].status = BookStatus.Borrowing;
                    this.listBooks[index].receiveDate = new Date();
                } else {
                    // TODO
                }
            });
    }

    private returnBook(bookCode: string, index: number): void {
        this.bookService.returnBook(this.requestInfo.userId, bookCode, this.requestInfo.requestId)
            .subscribe((res) => {
                if (res) {
                    this.listBooks[index].status = BookStatus.Returned;
                    this.listBooks[index].returnDate = new Date();
                } else {
                    // TODO
                }
            });
    }

    private cancelBook(bookCode: string, index: number): void {
        this.bookService.cancelBook(this.requestInfo.userId, bookCode, this.requestInfo.requestId)
            .subscribe((res) => {
                if (res) {
                    this.listBooks[index].status = BookStatus.Cancel;
                } else {
                    // TODO
                }
            });
    }
}
