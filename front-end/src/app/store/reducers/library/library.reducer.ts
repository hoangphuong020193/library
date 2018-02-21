import { Action, ActionReducer } from '@ngrx/store';
import * as libraryAction from '../../actions/library.action';
import { Library } from '../../../models/library.model';

export interface State {
    libraries: Library[];
}

export const initialState: State = {
    libraries: []
};

export function reducer(state: State = initialState, action: libraryAction.Actions): State {
    switch (action.type) {
        case libraryAction.ActionTypes.FETCH_LIBRARY:
            return Object.assign({}, state, { libraries: action.payload });
        default:
            return state;
    }
}
