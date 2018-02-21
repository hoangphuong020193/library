import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';

export const ActionTypes = {
    FETCH_LIBRARY: '[Library] Fetch library'
};

export class FetchLibrary implements Action {
    public readonly type: string = ActionTypes.FETCH_LIBRARY;
    constructor(public payload: any) { }
}

export type Actions = FetchLibrary;
