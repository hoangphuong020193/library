declare var ENV: string;
import * as fromRouter from '@ngrx/router-store';
import { compose } from '@ngrx/store';
import { combineReducers } from '@ngrx/store';
import { Action, ActionReducer, ActionReducerMap } from '@ngrx/store';
import { createSelector } from 'reselect';

export interface State {
    route: fromRouter.RouterReducerState;
}

export const reducers: ActionReducerMap<State> = {
    route: fromRouter.routerReducer
};

export const getRouterState = (state: State) => state.route;

export const getRouter = createSelector(getRouterState, (state) => state);
