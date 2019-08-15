import { HttpClient } from '@angular/common/http';
import ValueData from '../Models/ValueModel';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class JwtServiceComponent {

  constructor(private httpClient: HttpClient) { }

  registrater(name: string, email: string, password: string){
    return this.httpClient.post<{access_token: string}>('http://localhost:49976/api/Auth/register', {name, email, password}).pipe(tap(res=>{this.login(email, password)}))
  }

  login(email:string, password:string) {
    return this.httpClient.post<{access_token:  string}>("http://localhost:49976/api/Auth/login", {email, password}).pipe(tap(res => {
    localStorage.setItem('access_token', res.access_token);
}))
}

  logout() {
    localStorage.removeItem('access_token');
  }

  public get loggedIn(): boolean{
    return localStorage.getItem('access_token') !==  null;
  }
}