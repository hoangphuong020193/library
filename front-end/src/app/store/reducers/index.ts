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
import * as fromCategory from './category';
import * as fromNotification from './notification';

export interface State {
  router: fromRouter.RouterReducerState;
  user: fromUser.State;
  category: fromCategory.State;
  book: fromBook.State;
  notification: fromNotification.State;
}

export const reducers: ActionReducerMap<State> = {
  router: fromRouter.routerReducer,
  user: fromUser.reducer,
  category: fromCategory.reducer,
  book: fromBook.reducer,
  notification: fromNotification.reducer,
};

// STATES
export const getRouterState = (state: State) => state.router;
export const getUserState = (state: State) => state.user;
export const getCategoryState = (state: State) => state.category;
export const getBookState = (state: State) => state.book;
export const getNotificationState = (state: State) => state.notification;

// ROUTE
export const getRouter = createSelector(getRouterState, (state) => state);

// USER
export const getCurrentUser = createSelector(getUserState, fromUser.getCurrentUser);

// CATEGORY
export const getCategory = createSelector(getCategoryState, fromCategory.getCategory);

// BOOK
export const getSelectedBookCode = createSelector(getBookState, fromBook.getSelectedBookCode);
export const getBookSelected = createSelector(getBookState, fromBook.getBookSelected);
export const getBookInCart = createSelector(getBookState, fromBook.getBookInCart);

// NOTIFICATION
export const getNotification
  = createSelector(getNotificationState, fromNotification.getNotification);
