import { Routes } from '@angular/router';

// COMPONENT
import * as fromError from '../components/error';
import { HomeComponent } from '../components/home';

// GUARD

export const ROUTES: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', redirectTo: '', pathMatch: 'full' },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
