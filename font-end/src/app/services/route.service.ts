import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class RouterService {
    constructor(private router: Router) { }

    public home(): void {
        this.router.navigate(['/home']);
    }
}
