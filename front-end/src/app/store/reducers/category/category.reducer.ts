import { Action, ActionReducer } from '@ngrx/store';
import { Category } from '../../../models';
import * as categoryAction from '../../actions/category.action';

export interface State {
    categories: Category[];
}

export const initialState: State = {
    categories: []
};

export function reducer(state: State = initialState, action: categoryAction.Actions): State {
    switch (action.type) {
        case categoryAction.ActionTypes.FETCH_CATEGORY:
            return Object.assign({}, state, { categories: action.payload });
        default:
            return state;
    }
}
