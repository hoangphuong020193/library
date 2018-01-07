import { Component, OnInit } from '@angular/core';
import { Book } from '../../../models/book.model';
@Component({
    selector: 'book-section',
    templateUrl: './book-section.component.html'
})

export class BookSectionComponent implements OnInit {
    private slideConfig: any = { slidesToShow: 4, slidesToScroll: 4 };

    private books: number[] = [];

    constructor() { }

    public ngOnInit(): void {
        this.books = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
    }
}
