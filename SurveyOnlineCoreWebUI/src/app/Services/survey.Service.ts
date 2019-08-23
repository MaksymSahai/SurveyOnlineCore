import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SurveyList } from '../Models/surveylist';
import { retry } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class SurveyService {

    constructor(private http: HttpClient) {
    }

    getSurveys(): Observable<any>{
        let url = environment.UrlApi +'/surveys/list';
        return this.http.get<any>(url).pipe(retry(1));
    }

    getSurveyById(id: string): Observable<any>{
        let url = environment.UrlApi +'/surveys/survey/'+id;
        return this.http.get<any>(url).pipe(retry(1));
    }
}