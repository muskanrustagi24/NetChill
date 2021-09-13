import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'src/app/data-service/movie-service.component';
import { IMovie } from 'src/app/models/IMovie';
import { userDataService } from 'src/app/data-service/userData-service.component';
import { MovieListService } from 'src/app/data-service/movie-list-service.component';
import { IMovieList } from 'src/app/models/IMovieList';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';



@Component({
  selector: 'app-view-movie',
  templateUrl: './view-movie.component.html',
  styleUrls: ['./view-movie.component.css']
})
export class ViewMovieComponent implements OnInit {
    errorMessage = '';
    movie: IMovie | undefined;
    movieListModel!: IMovieList;
    videoUrl!: SafeResourceUrl;
   
   constructor(
      private route: ActivatedRoute,
      private router: Router,
      private movieService: MovieService,
      private userDataService: userDataService,
      private movieListService: MovieListService,
      private sanitizer: DomSanitizer) {
    }
    
    ngOnInit(): void {
      if(this.userDataService.loggedInUser == null){
          this.router.navigate(['/login']);
      }
      const id = this.route.snapshot.paramMap.get('id');
      if (id) {
        this.GetMovie(id);
       }
      
      this.movieListModel = {
        UserId: this.userDataService.loggedInUser.Id,
        MovieId: id as string
      };
    }
    
    GetMovie(id: string){
      this.movieService.GetMovie(id).subscribe(
        {
            next: movie => {
              this.movie = movie;
              this.videoUrl =  this.sanitizer.bypassSecurityTrustResourceUrl(movie.ContentPath);
              console.log(this.movie);
            },
            error: err => this.errorMessage = err
        }
    )}

    AddMovieToList(){
      this.movieListService.AddMovieToList(this.movieListModel).subscribe(
        (res) => {
          alert("Movie added to list!");
          this.router.navigate([`/mylist/${this.movieListModel.UserId}`]);
        },
        (err) => {
          console.log(err);
        }
      );
    }

}
