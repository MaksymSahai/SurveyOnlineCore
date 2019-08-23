import { Component, OnInit } from '@angular/core';
import { SurveyService } from 'src/app/Services/survey.Service';

@Component({
  selector: 'app-surveylist',
  templateUrl: './surveylist.component.html',
  styleUrls: ['./surveylist.component.css']
})
export class SurveylistComponent implements OnInit {
  SurveyList: any = [];
  constructor(private surveyService: SurveyService) { }

  ngOnInit() {
    this.getAllSurveys();
  }

  getAllSurveys(){
    this.surveyService.getSurveys().subscribe((data: {}) => {this.SurveyList = data});
  }

}
