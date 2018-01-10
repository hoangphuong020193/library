// tslint:disable:typedef
declare var ENV: string;
import * as fromRouter from '@ngrx/router-store';
import { compose } from '@ngrx/store';
import { combineReducers } from '@ngrx/store';
import { Action, ActionReducer, ActionReducerMap } from '@ngrx/store';
import * as moment from 'moment';
import { createSelector } from 'reselect';

import { User } from '../../models';
import * as fromUser from './user';
import * as fromBook from './book';

export interface State {
  router: fromRouter.RouterReducerState;
  user: fromUser.State;
  book: fromBook.State;
}

export const reducers: ActionReducerMap<State> = {
  router: fromRouter.routerReducer,
  user: fromUser.reducer,
  book: fromBook.reducer
};

// STATES
export const getRouterState = (state: State) => state.router;
export const getUserState = (state: State) => state.user;
export const getBookState = (state: State) => state.book;

// ROUTE
export const getRouter = createSelector(getRouterState, (state) => state);

// USER
export const getCurrentUser = createSelector(getUserState, fromUser.getCurrentUser);

// BOOK
export const getSelectedBookCode = createSelector(getBookState, fromBook.getSelectedBookCode);
export const getBookSelected = createSelector(getBookState, fromBook.getBookSelected);
