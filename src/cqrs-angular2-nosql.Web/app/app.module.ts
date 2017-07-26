import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { ApiService } from './services/api.service';

import { ClientListComponent } from './components/client/list/list.component';
import { ClientDetailComponent } from './components/client/detail/detail.component';

const appRoutes: Routes = [
    { path: 'client-list', component: ClientListComponent },
    { path: 'client-detail/:id', component: ClientDetailComponent }
];


@NgModule({
    imports:
    [
        BrowserModule,
        RouterModule.forRoot(appRoutes),
        HttpModule
    ],
    declarations: [
        AppComponent,
        ClientListComponent,
        ClientDetailComponent
    ],
    bootstrap: [
        AppComponent
    ],
    providers: [
        ApiService,
        { provide: LocationStrategy, useClass: HashLocationStrategy }
    ]
})
export class AppModule { }
