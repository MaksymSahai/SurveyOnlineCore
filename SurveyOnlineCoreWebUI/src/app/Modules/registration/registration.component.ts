import { Component, OnInit, Injectable } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})

export class RegistrationComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    //this.jwtService.registrater("name", "email@mail.com", "password11");
  }

}
