import { Component, OnInit } from '@angular/core';
import { Book } from '../../../models/book.model';
import { NgxCarousel } from 'ngx-carousel';

@Component({
    selector: 'book-section',
    templateUrl: './book-section.component.html'
})

export class BookSectionComponent implements OnInit {
    public carouselTile: NgxCarousel;

    private books: number[] = [];

    constructor() { }

    public ngOnInit(): void {
        this.books = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        this.carouselTile = {
            grid: { xs: 2, sm: 3, md: 3, lg: 4, all: 0 },
            slide: 4,
            speed: 400,
            animation: 'lazy',
            point: {
                visible: false
            },
            load: 2,
            touch: true,
            easing: 'ease'
        };
    }
}
