import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MovieService } from 'src/app/data-service/movie-service.component';
import { userDataService } from 'src/app/data-service/userData-service.component';
import { IMovie } from 'src/app/models/IMovie';

@Component({
  selector: 'app-welcome-movies',
  templateUrl: './welcome-movies.component.html',
  styleUrls: ['./welcome-movies.component.css']
})
export class WelcomeMoviesComponent implements OnInit {
  movies : IMovie[] = [];
  errorMessage = '';
  
  sub!: Subscription;
  // Get Value represents which function to call Featured ==> 0 , New Releases => 1 & Upcoming => 2 
  @Input()
  getValue: number = -1;

  constructor(private movieService: MovieService , private router : Router , private user: userDataService){}

  ngOnInit(): void {
    if(this.getValue == 0){
      this.GetFeaturedMovies();
    }else if(this.getValue == 1){
      this.GetNewReleases();
    }else if(this.getValue == 2){
      this.GetUpcomingMovies();
    }else{
      alert("Error!! Returning to home!");
      this.router.navigate(['/movies']);
    }
  }

  GetUpcomingMovies(){
    this.sub = this.movieService.GetUpcomingMovies().subscribe({
      next: movies => {
        this.movies = movies;
        
      },
      error: err => this.errorMessage = err
  });
  }
  
  GetFeaturedMovies(){
    this.sub = this.movieService.GetFeaturedMovies().subscribe({
      next: movies => {
        this.movies = movies;
      },
      error: err => this.errorMessage = err
    });
  }

  GetNewReleases(){
    this.sub = this.movieService.GetNewReleases().subscribe({
      next: movies => {
        this.movies = movies;
      },
      error: err => this.errorMessage = err
    });
  }

  ngOnDestroy(): void {
      this.sub.unsubscribe();
  }
}

