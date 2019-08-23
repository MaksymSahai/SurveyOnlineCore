import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { SurveyService } from 'src/app/Services/survey.Service';
import { SurveyDetail } from 'src/app/Models/SurveyDetail';

@Component({
  selector: 'app-surveydetail',
  templateUrl: './surveydetail.component.html',
  styleUrls: ['./surveydetail.component.css']
})
export class SurveydetailComponent implements OnInit {
  Id: any;
  SurveyDetails: SurveyDetail;
  
  constructor(private route: ActivatedRoute,private surveyService: SurveyService) { }


  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      console.log(params.get('id'))
         this.surveyService.getSurveyById(params.get('id')).subscribe(data => this.SurveyDetails = data);
      });
  }

  

}
