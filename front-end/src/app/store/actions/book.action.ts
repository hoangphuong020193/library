import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';
import { Book } from '../../models';

export const ActionTypes = {
    SELECTED_BOOK_CODE: '[Book] Selected book code',
    FETCH_BOOK_SELECTED: '[Book] Fetch book selected'
};

export class SelectedBook implements Action {
    public readonly type: string = ActionTypes.SELECTED_BOOK_CODE;
    constructor(public payload: any) { }
}

// tslint:disable-next-line:max-classes-per-file
export class FetchBookSelected implements Action {
    public readonly type: string = ActionTypes.FETCH_BOOK_SELECTED;
    constructor(public payload: Book) { }
}

export type Actions = SelectedBook | FetchBookSelected;
