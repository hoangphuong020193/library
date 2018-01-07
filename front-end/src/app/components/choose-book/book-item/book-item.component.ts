import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'book-item',
    templateUrl: './book-item.component.html'
})
export class BookItemComponent implements OnInit {
    @Input('bookName') public bookName: string = '';

    constructor() { }

    public ngOnInit(): void { }
}
