import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';

export const ActionTypes = {
    FETCH_PUBLISHER: '[Publisher] Fetch publisher'
};

export class FetchPublisher implements Action {
    public readonly type: string = ActionTypes.FETCH_PUBLISHER;
    constructor(public payload: any) { }
}

export type Actions = FetchPublisher;
