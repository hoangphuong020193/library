declare var ENV: string;

import { CommonModule } from '@angular/common';
import { ApplicationRef, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

/*
 * Platform and Environment providers/directives/pipes
 */
import { environment } from 'environments/environment';
import { ROUTES } from './app.routes';
import '../../styles/main.scss';
import * as components from './component.declaration';
import * as providers from './provider.declaration';

// App is our top level component
import { AppComponent } from '../main/app.component';
import { APP_RESOLVER_PROVIDERS } from './app.resolver';
import { AppState, InternalStateType } from '../services/app.service';

// Module
import { StoreModule } from '@ngrx/store';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { reducers } from '../../store/reducers';
import { BootstrapModalModule } from 'angularx-bootstrap-modal';

// Component

// Application wide providers
const APP_PROVIDERS: any[] = [
  ...APP_RESOLVER_PROVIDERS,
  ...providers.services,
  ...providers.guards,
  AppState,
];

const APP_COMPONENTS: any[] = [
  ...components.CommonComponents,
  ...components.Components
];

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent,
    ...APP_COMPONENTS
  ],
  /**
   * Import Angular's modules.
   */
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
    RouterModule.forRoot(ROUTES, {
      useHash: Boolean(history.pushState) === false,
      preloadingStrategy: PreloadAllModules
    }),
    StoreModule.forRoot(reducers),
    RouterModule.forRoot(ROUTES, { useHash: false, preloadingStrategy: PreloadAllModules }),
    StoreRouterConnectingModule,
    'production' !== ENV ? StoreDevtoolsModule.instrument({ maxAge: 50 }) : [],
    BootstrapModalModule,
  ],
  /**
   * Expose our Services and Providers into Angular's dependency injection.
   */
  providers: [
    environment.ENV_PROVIDERS,
    APP_PROVIDERS
  ],
  entryComponents: [
    components.LoginPopupComponent
  ]
})
export class AppModule { }
