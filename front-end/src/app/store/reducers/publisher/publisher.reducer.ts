import { Action, ActionReducer } from '@ngrx/store';
import * as publisherAction from '../../actions/publisher.action';
import { Publisher } from '../../../models/index';

export interface State {
    publishers: Publisher[];
}

export const initialState: State = {
    publishers: []
};

export function reducer(state: State = initialState, action: publisherAction.Actions): State {
    switch (action.type) {
        case publisherAction.ActionTypes.FETCH_PUBLISHER:
            return Object.assign({}, state, { publishers: action.payload });
        default:
            return state;
    }
}
