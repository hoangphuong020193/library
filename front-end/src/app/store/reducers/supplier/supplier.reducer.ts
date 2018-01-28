import { Action, ActionReducer } from '@ngrx/store';
import * as supplierAction from '../../actions/supplier.action';
import { Supplier } from '../../../models/supplier.model';

export interface State {
    suppliers: Supplier[];
}

export const initialState: State = {
    suppliers: []
};

export function reducer(state: State = initialState, action: supplierAction.Actions): State {
    switch (action.type) {
        case supplierAction.ActionTypes.FETCH_SUPPLIER:
            return Object.assign({}, state, { suppliers: action.payload });
        default:
            return state;
    }
}
