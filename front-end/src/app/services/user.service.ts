import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';
import { Config, PathController } from '../config';

@Injectable()
export class UserService {
    private apiURL: string = Config.getPath(PathController.Account);

    constructor(
        private http: HttpClient) {
    }
}
