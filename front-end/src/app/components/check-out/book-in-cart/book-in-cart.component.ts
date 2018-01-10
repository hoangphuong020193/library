import { Component, OnInit } from '@angular/core';
import { Config } from '../../../config';

@Component({
    selector: 'book-in-cart',
    templateUrl: './book-in-cart.component.html'
})
export class BookInCartComponent implements OnInit {
    constructor() { }

    public ngOnInit(): void { }

    private getBookImgURL(bookCode: string): string {
        return Config.getBookImgApiUrl(bookCode);
    }
}
