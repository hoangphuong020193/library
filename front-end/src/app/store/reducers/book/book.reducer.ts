import { Action, ActionReducer } from '@ngrx/store';
import { Book } from '../../../models';
import * as bookAction from '../../actions/book.action';

export interface State {
    bookCodeSelected: string;
    bookSelected: Book;
}

export const initialState: State = {
    bookCodeSelected: '',
    bookSelected: null
};

export function reducer(state: State = initialState, action: bookAction.Actions): State {
    switch (action.type) {
        case bookAction.ActionTypes.SELECTED_BOOK_CODE:
            return Object.assign({}, state, { bookCodeSelected: action.payload });
        case bookAction.ActionTypes.FETCH_BOOK_SELECTED:
            return Object.assign({}, state, { bookSelected: action.payload });
        default:
            return state;
    }
}
