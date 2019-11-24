import { Component, OnInit } from '@angular/core';
import { ValueServiceComponent } from 'src/app/Api/valueService';
import ValueData from 'src/app/Models/ValueModel';

@Component({
  selector: 'app-value-list',
  templateUrl: './value-list.component.html',
  styleUrls: ['./value-list.component.css']
})
export class ValueListComponent implements OnInit {
  values: Array<ValueData>;

  constructor(private valueService: ValueServiceComponent) { }

  ngOnInit() {
    this.valueService.getValues().subscribe(data => {this.values = data;});
  }

}
