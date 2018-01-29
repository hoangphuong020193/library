import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Config, PathController } from '../config';
import { map, tap, catchError } from 'rxjs/operators';
import { Publisher } from '../models/publisher.model';
import { Store } from '@ngrx/store';
import * as fromRoot from '../store/reducers';
import * as publisherAction from '../store/actions/publisher.action';

@Injectable()
export class PublisherService {
    private apiURL: string = Config.getPath(PathController.Publisher);

    constructor(
        private http: HttpClient,
        private store: Store<fromRoot.State>) {
    }

    public getListPublisher(): Observable<Publisher[]> {
        return this.http.get(this.apiURL + '/ReturnListPublisher').pipe(
            tap(
                (res: any) => {
                    this.store.dispatch(new publisherAction.FetchPublisher(res));
                    return res as Publisher[];
                }
            ),
            catchError((err) => {
                return Observable.of(null);
            }));
    }
}
