import { Routes } from '@angular/router';

// COMPONENT
import * as fromError from '../components/error';
import { HomeComponent } from '../components/home';
import { ChooseBookComponent } from '../components/choose-book/choose-book.component';

// GUARD
import { HomeGuard } from '../guards/home.guard';

export const ROUTES: Routes = [
  { path: 'home', redirectTo: '', pathMatch: 'full' },
  {
    path: '',
    component: HomeComponent,
    canActivate: [HomeGuard],
    children: [
      {
        path: '',
        redirectTo: 'index',
        pathMatch: 'full'
      },
      {
        path: 'index',
        component: ChooseBookComponent
      }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
