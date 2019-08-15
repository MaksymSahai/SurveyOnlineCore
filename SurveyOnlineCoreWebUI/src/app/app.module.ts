import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { ValueListComponent } from './Modules/value-list/value-list.component';
import { HeaderComponent } from './Modules/header/header.component';
import { FooterComponent } from './Modules/footer/footer.component';
import { BannerComponent } from './Modules/banner/banner.component';
import { MenuComponent } from './Modules/menu/menu.component';
import { HomeComponent } from './Modules/home/home.component';
import { RegistrationComponent } from './Modules/registration/registration.component';
import { LoginComponent } from './Modules/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthenticationService } from './Services/authentication.service';
import { JwtInterceptor, ErrorInterceptor } from './Helpers';


@NgModule({
  declarations: [
    AppComponent,
    ValueListComponent,
    HeaderComponent,
    FooterComponent,
    BannerComponent,
    MenuComponent,
    HomeComponent,
    RegistrationComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    //AuthGuard,
    //AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
