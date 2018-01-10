import { Routes, CanActivate } from '@angular/router';

// COMPONENT
import { HomeComponent } from '../components/home';
import { ChooseBookComponent } from '../components/choose-book/choose-book.component';
import { CheckOutComponent } from '../components/check-out/check-out.component';

// GUARD
import { HomeGuard } from '../guards/home.guard';
import { BookDetailComponent } from '../components/choose-book/book-detail/book-detail.component';
import { BookDetailGuard } from '../guards/book-detail.guard';

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
      },
      {
        path: 'book-detail/:bookCode',
        component: BookDetailComponent,
        canActivate: [BookDetailGuard]
      },
      {
        path: 'checkout/cart',
        component: CheckOutComponent
      }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
