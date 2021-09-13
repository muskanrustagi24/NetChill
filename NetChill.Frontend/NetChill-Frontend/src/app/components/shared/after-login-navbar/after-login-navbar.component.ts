import { Component, OnInit } from '@angular/core';
import { userDataService } from 'src/app/data-service/userData-service.component';
import { IUser } from 'src/app/models/IUser';

@Component({
  selector: 'app-after-login-navbar',
  templateUrl: './after-login-navbar.component.html',
  styleUrls: ['./after-login-navbar.component.css']
})
export class AfterLoginNavbarComponent implements OnInit {
  pageTitle : string = 'NetChill';
  FullName !: string;
  constructor(private userDataService : userDataService) { }

  ngOnInit(): void {
    this.FullName = this.userDataService.loggedInUser.FullName;
  }

}
