import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MovieService } from 'src/app/data-service/movie-service.component';
import { userDataService } from 'src/app/data-service/userData-service.component';
import { IMovie } from 'src/app/models/IMovie';

@Component({
  selector: 'app-display-movies',
  templateUrl: './display-movies.component.html',
  styleUrls: ['./display-movies.component.css']
})
export class DisplayMoviesComponent implements OnInit {
  movies : IMovie[] = [];
  errorMessage = '';
  private _listFilter = '';
  filteredMovies: IMovie[] = [];
  
  sub!: Subscription;
  // Get Value represents which function to call Home==> 0 , Featured ==> 1 , New Releases => 2 , Upcoming => 3 , My List => 4
  @Input()
  getValue: number = -1;

  constructor(private movieService: MovieService , private router : Router , private user: userDataService){}

  ngOnInit(): void {
    if(this.getValue == 0){
      this.GetAllMovies();
    }else if(this.getValue == 1){
      this.GetFeaturedMovies();
    }else if(this.getValue == 2){
      this.GetNewReleases();
    }else if(this.getValue == 3){
      this.GetUpcomingMovies();
    }else if(this.getValue == 4){
      this.GetMyMovies(this.user.loggedInUser.Id);
    }else{
      alert("Error!! Returning to home!");
      this.router.navigate(['/movies']);
    }
  }

  GetAllMovies(){
    this.sub = this.movieService.GetAllMovies().subscribe({
      next: movies => {
        this.movies = movies;
        this.filteredMovies = movies;
      },
      error: err => this.errorMessage = err
  });
  }

  GetUpcomingMovies(){
    this.sub = this.movieService.GetUpcomingMovies().subscribe({
      next: movies => {
        this.movies = movies;
        this.filteredMovies = movies;
      },
      error: err => this.errorMessage = err
  });
  }
  
  GetFeaturedMovies(){
    this.sub = this.movieService.GetFeaturedMovies().subscribe({
      next: movies => {
        this.movies = movies;
        this.filteredMovies = movies;
      },
      error: err => this.errorMessage = err
    });
  }

  GetNewReleases(){
    this.sub = this.movieService.GetNewReleases().subscribe({
      next: movies => {
        this.movies = movies;
        this.filteredMovies = movies;
      },
      error: err => this.errorMessage = err
    });
  }

  GetMyMovies(userId: string){
    this.sub = this.movieService.GetMyMovies(userId).subscribe({
      next: movies => {
        this.movies = movies;
        this.filteredMovies = movies;
      },
      error: err => this.errorMessage = err
    });
  }
  
  get listFilter(): string {
    return this._listFilter;
  }

  set listFilter(value: string) {
    this._listFilter = value;
    console.log(this._listFilter);
    this.filteredMovies = this.performFilter(value);
  }
  
  performFilter(filterBy: string): IMovie[] {
      filterBy = filterBy.toLocaleLowerCase();
      var res = this.movies.filter((movie: IMovie) =>
        movie.Name.toLocaleLowerCase().includes(filterBy));
      console.log(res);
      return res;
  }
  
  ngOnDestroy(): void {
      this.sub.unsubscribe();
  }

}
