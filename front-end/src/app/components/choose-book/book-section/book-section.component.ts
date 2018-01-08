import { Component, OnInit } from '@angular/core';
import { Book } from '../../../models/book.model';
import { NgxCarousel } from 'ngx-carousel';
import { BookService } from '../../../services/book.service';

@Component({
    selector: 'book-section',
    templateUrl: './book-section.component.html'
})

export class BookSectionComponent implements OnInit {
    public carouselOption: NgxCarousel;

    private books: Book[] = [];

    constructor(private bookService: BookService) { }

    public ngOnInit(): void {
        this.carouselOption = {
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

        this.bookService.getListNewBook().subscribe((res) => {
            this.books = res;
        });
    }
}
