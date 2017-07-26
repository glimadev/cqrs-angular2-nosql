import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { ApiService } from './services/api.service';

import { ClientListComponent } from './components/client/list/list.component';
import { ClientDetailComponent } from './components/client/detail/detail.component';
import { ClientCreateComponent } from './components/client/create/create.component';
import { ClientUpdateComponent } from './components/client/update/update.component';

const appRoutes: Routes = [
    { path: 'client-list', component: ClientListComponent },
    { path: 'client-create', component: ClientCreateComponent },
    { path: 'client-detail/:id', component: ClientDetailComponent },
    { path: 'client-update/:id', component: ClientUpdateComponent }
];


@NgModule({
    imports:
    [
        BrowserModule,
        FormsModule,
        BrowserAnimationsModule,
        ToastrModule.forRoot(appRoutes),
        RouterModule.forRoot(appRoutes),
        HttpModule
    ],
    declarations: [
        AppComponent,
        ClientListComponent,
        ClientCreateComponent,
        ClientDetailComponent,
        ClientUpdateComponent
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
