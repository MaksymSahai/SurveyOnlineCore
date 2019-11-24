import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import ValueData from '../Models/ValueModel';

@Injectable()
export class ValueServiceComponent {

  constructor(private httpClient: HttpClient) { }

  getValues(): Observable<Array<ValueData>>{
    return this.httpClient.get<Array<ValueData>>('http://localhost:49976/api/values');
  }
}
