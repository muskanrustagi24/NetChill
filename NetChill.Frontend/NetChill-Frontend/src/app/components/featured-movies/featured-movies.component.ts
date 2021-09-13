import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { userDataService } from 'src/app/data-service/userData-service.component';

@Component({
  templateUrl: './featured-movies.component.html',
  styleUrls: ['./featured-movies.component.css']
})
export class FeaturedMoviesComponent implements OnInit {

  constructor(private userDataService: userDataService , private router: Router) { }

  ngOnInit(): void {
    document.getElementById('featured')?.classList.add('active');
    if(this.userDataService.loggedInUser == null){
      this.router.navigate(['/login']);
    }
  }

}
