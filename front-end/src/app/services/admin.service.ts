import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Config, PathController } from '../config';
import { map, tap, catchError } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import * as fromRoot from '../store/reducers';
import { PagedList } from '../models/index';
import { UserNotReturnBook } from '../models/admin.model';

@Injectable()
export class AdminService {
    private apiURL: string = Config.getPath(PathController.Admin);

    constructor(
        private http: HttpClient,
        private store: Store<fromRoot.State>) {
    }

    public getListUserNotReturnBook(page: number, pageSize: number)
        : Observable<PagedList<UserNotReturnBook>> {
        return this.http.get(this.apiURL + '/ReturnListUserNotReturnBook/'
            + page + '/' + pageSize)
            .pipe(
            tap(
                (res: any) => {
                    return res;
                }
            ),
            catchError((err) => {
                return Observable.of(null);
            }));
    }
}
