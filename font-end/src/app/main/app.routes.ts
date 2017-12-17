import { Routes } from '@angular/router';
import { HomeComponent } from '../components/home/home.component';

export const ROUTES: Routes = [
  { path: '',      component: HomeComponent },
  { path: 'home',  component: HomeComponent },
  // { path: 'about', component: AboutComponent },
  // { path: 'detail', loadChildren: './+detail#DetailModule'},
  // { path: 'barrel', loadChildren: './+barrel#BarrelModule'},
  // { path: '**',    component: NoContentComponent },
];
