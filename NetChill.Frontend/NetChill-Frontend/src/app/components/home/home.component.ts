import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { userDataService } from 'src/app/data-service/userData-service.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private userDataService: userDataService , private router: Router) { }

  ngOnInit(): void {
    if(this.userDataService.loggedInUser == null){
      this.router.navigate(['/login']);
    }
  }

}
