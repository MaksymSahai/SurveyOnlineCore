import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { Routes } from '@angular/router';
import { ValueListComponent } from './Modules/value-list/value-list.component';
import { HeaderComponent } from './Modules/header/header.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/value-list', pathMatch: 'full' },
  {
    path: 'value-list',
    component: ValueListComponent
  },
];

@NgModule({
  declarations: [
    AppComponent,
    ValueListComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    
  ],
  providers: [ValueListComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
