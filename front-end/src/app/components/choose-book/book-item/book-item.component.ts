import { Component, OnInit, Input } from '@angular/core';
import { Book } from '../../../models/index';

@Component({
    selector: 'book-item',
    templateUrl: './book-item.component.html'
})
export class BookItemComponent implements OnInit {
    @Input('book') public book: Book;

    constructor() { }

    public ngOnInit(): void { }
}
