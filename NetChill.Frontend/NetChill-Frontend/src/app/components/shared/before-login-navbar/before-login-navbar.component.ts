import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-before-login-navbar',
  templateUrl: './before-login-navbar.component.html',
  styleUrls: ['./before-login-navbar.component.css']
})
export class BeforeLoginNavbarComponent implements OnInit {
  pageTitle : string = 'NetChill';
  constructor() { }

  ngOnInit(): void {
  }

}
