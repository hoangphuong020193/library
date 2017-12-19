// tslint:disable:typedef
declare var ENV: string;
import * as fromRouter from '@ngrx/router-store';
import { compose } from '@ngrx/store';
import { combineReducers } from '@ngrx/store';
import { Action, ActionReducer, ActionReducerMap } from '@ngrx/store';
import * as moment from 'moment';
import { createSelector } from 'reselect';
import { AppHelper } from '../../common/helpers';
import { LsHelper } from '../../common/helpers/ls.helper';
import { User } from '../../models';
import * as fromUser from './user';

export interface State {
  router: fromRouter.RouterReducerState;
  user: fromUser.State;
}

export const reducers: ActionReducerMap<State> = {
  router: fromRouter.routerReducer,
  user: fromUser.reducer
};

// STATES
export const getRouterState = (state: State) => state.router;
export const getUserState = (state: State) => state.user;

// ROUTE
export const getRouter = createSelector(getRouterState, (state) => state);

// USER
export const getCurrentUser = createSelector(getUserState, fromUser.getCurrentUser);

