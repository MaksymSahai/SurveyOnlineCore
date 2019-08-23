import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ValueListComponent } from './Modules/value-list/value-list.component';
import { HomeComponent } from './Modules/home/home.component';
import { RegistrationComponent } from './Modules/registration/registration.component';
import { LoginComponent } from './Modules/login/login.component';
import { AuthGuard } from './Helpers';
import { AboutusComponent } from './Modules/aboutus/aboutus.component';
import { HowitComponent } from './Modules/howit/howit.component';
import { FaqComponent } from './Modules/faq/faq.component';
import { FeedbackComponent } from './Modules/feedback/feedback.component';
import { SurveylistComponent } from './Modules/surveylist/surveylist.component';
import { SurveydetailComponent } from './Modules/surveydetail/surveydetail.component';


const routes: Routes = [
  { path: '' , component: HomeComponent},
  { path: 'register' , component: RegistrationComponent},
  { path: 'login' , component: LoginComponent},
  { path: 'aboutus' , component: AboutusComponent},
  { path: 'howit' , component: HowitComponent},
  { path: 'faq' , component: FaqComponent},
  { path: 'feedback' , component: FeedbackComponent},
  { path: 'value' , component: ValueListComponent, canActivate: [AuthGuard]},
  { path: 'surveys' , component: SurveylistComponent, canActivate: [AuthGuard]},
  { path: 'survey/detail/:id' , component: SurveydetailComponent, canActivate: [AuthGuard]},

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
