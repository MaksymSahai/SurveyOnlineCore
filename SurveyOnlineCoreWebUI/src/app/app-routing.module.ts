import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ValueListComponent } from './Modules/value-list/value-list.component';
import { HomeComponent } from './Modules/home/home.component';
import { RegistrationComponent } from './Modules/registration/registration.component';
import { LoginComponent } from './Modules/login/login.component';
import { AuthGuard } from './Helpers';


const routes: Routes = [
  { path: '' , component: HomeComponent},
  { path: 'register' , component: RegistrationComponent},
  { path: 'login' , component: LoginComponent},
  { path: 'value' , component: ValueListComponent, canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
