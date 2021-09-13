import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { MovieService } from 'src/app/data-service/movie-service.component';
import { userDataService } from 'src/app/data-service/userData-service.component';
import { IMovie } from 'src/app/models/IMovie';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css']
})
export class AddMovieComponent implements OnInit {
  imageSrc!: any;  
  newMovie!: IMovie;
  constructor(private movieService: MovieService , private userDataService: userDataService , private router: Router) { }

  ngOnInit(): void {
    if(this.userDataService.loggedInUser == null){
      this.router.navigate(['/login']);
    }
    document.getElementById('uploadContent')?.classList.add('active');
  }

  // AddImagePreview(event: any){
  //   const reader = new FileReader();
  //   if(event.target.files && event.target.files.length){
  //     const [file] = event.target.files; 
  //     reader.readAsDataURL(file);

  //     reader.onload = () => {
  //       this.imageSrc = reader.result;
  //       alert(this.imageSrc);   
  //     }
  //   }
      
  // }

  preview(files: any){
    const reader = new FileReader();
    let imagepath = files;
    reader.readAsDataURL(files[0]);
    reader.onload = (_event) => {
      this.imageSrc = reader.result;
    }
  }

  Submit(addMovieForm: NgForm){
    if(addMovieForm.valid){
        this.newMovie = {
          Id: "",
          AvailabilityStarts: addMovieForm.value.AvailabilityStarts,
          Name: addMovieForm.value.Name,
          Category: addMovieForm.value.Category,
          ContentPath: addMovieForm.value.ContentPath,
          Description: addMovieForm.value.Description,
          IsFeatured: addMovieForm.value.IsFeatured,
          PosterPath: addMovieForm.value.PosterPath,
          YearOfRelease: addMovieForm.value.YearOfRelease
        }
    
        this.movieService.AddMovie(this.newMovie).subscribe(
          (res) => {
            alert(`Added ${this.newMovie.Name}`);
            this.router.navigate(['/movies']);
          },
          (err) => {
            console.log(err);
          }
        ) 
    
      }
  }

}
