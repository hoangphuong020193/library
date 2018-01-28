import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';

export const ActionTypes = {
    FETCH_SUPPLIER: '[Supplier] Fetch supplier'
};

export class FetchSupplier implements Action {
    public readonly type: string = ActionTypes.FETCH_SUPPLIER;
    constructor(public payload: any) { }
}

export type Actions = FetchSupplier;
