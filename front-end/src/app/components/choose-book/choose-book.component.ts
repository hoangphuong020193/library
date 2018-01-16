import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { Store } from '@ngrx/store';
import * as fromRoot from '../../store/reducers';
import { Observable } from 'rxjs';
import { Category } from '../../models/index';

@Component({
    selector: 'choose-book',
    templateUrl: './choose-book.component.html'
})
export class ChooseBookComponent implements OnInit {

    private listCategories: Category[] = [];

    constructor(
        private categoryService: CategoryService,
        private store: Store<fromRoot.State>) { }

    public ngOnInit(): void {
        this.categoryService.getListCategory().subscribe();
        this.store.select(fromRoot.getCategory).subscribe((res) => {
            this.listCategories = res;
        });
    }

    private showType(index: number): boolean {
        if (index === 0
            || this.listCategories[index - 1].type !== this.listCategories[index].type) {
            return true;
        }
        return false;
    }
}
