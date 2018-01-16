import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';
import { Book } from '../../models';

export const ActionTypes = {
    FETCH_CATEGORY: '[Category] Fetch category'
};

export class FetchCategory implements Action {
    public readonly type: string = ActionTypes.FETCH_CATEGORY;
    constructor(public payload: any) { }
}

export type Actions = FetchCategory;
