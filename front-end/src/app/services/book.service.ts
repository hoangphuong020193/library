import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Config, PathController } from '../config';
import { Book } from '../models/book.model';
import { map, tap, catchError } from 'rxjs/operators';

@Injectable()
export class BookService {
    private apiURL: string = Config.getPath(PathController.Book);

    constructor(
        private http: HttpClient) {
    }

    public getListNewBook(): Observable<Book[]> {
        return this.http.get(this.apiURL + '/ReturnListNewBook').pipe(
            tap(
                (res: any) => {
                    return res as Book[];
                }
            ),
            catchError((err) => {
                return Observable.of(null);
            }));
    }

    public getBookDetailByCode(bookCode: string): Observable<Book> {
        return this.http.get(this.apiURL + '/ReturnBookDetail/' + bookCode).pipe(
            tap(
                (res: any) => {
                    return res as Book[];
                }
            ),
            catchError((err) => {
                return Observable.of(null);
            }));
    }

    public userFavoriteBook(bookId: number): Observable<boolean> {
        let headers = new HttpHeaders();
        headers = headers.append('Content-Type', 'application/json; charset=utf-8');
        return this.http.post(this.apiURL + '/UserFavoriteBook/', bookId, { headers }).pipe(
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
