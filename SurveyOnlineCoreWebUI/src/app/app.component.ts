import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http'
import { catchError, tap } from 'rxjs/operators' 

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SurveyOnlineCoreWebUI';
  private apiURL = "http://surveyonlinecore.azurewebsites.net/api/values/";



  public GetValues(){  
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(this.apiURL, {headers: headers}).pipe(tap(data => data));
  }
}


