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
import {  ReactiveFormsModule } from '@angular/forms';
import { JwtInterceptor, ErrorInterceptor } from './Helpers';
import { AboutusComponent } from './Modules/aboutus/aboutus.component';
import { HowitComponent } from './Modules/howit/howit.component';
import { FaqComponent } from './Modules/faq/faq.component';
import { FeedbackComponent } from './Modules/feedback/feedback.component';
import { SurveylistComponent } from './Modules/surveylist/surveylist.component';
import { AuthenticationService } from './Services/authentication.service';
import { SurveyService } from './Services/survey.Service';
import { SurveydetailComponent } from './Modules/surveydetail/surveydetail.component';


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
    LoginComponent,
    AboutusComponent,
    HowitComponent,
    FaqComponent,
    FeedbackComponent,
    SurveylistComponent,
    SurveydetailComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    //AuthGuard,
    AuthenticationService,
    SurveyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
