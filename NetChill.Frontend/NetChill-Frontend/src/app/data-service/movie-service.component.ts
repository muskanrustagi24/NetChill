import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IMovie } from "../models/IMovie";

@Injectable({
    providedIn: "root"
})

export class MovieService{
    private movieUrl = "https://localhost:44322/api/movies";
    private upcomingMovieUrl = "https://localhost:44322/api/upcoming";
    private featuredMovieUrl = "https://localhost:44322/api/featured";
    private newMovieUrl = "https://localhost:44322/api/new";
    private myMoviesUrl = "https://localhost:44322/api/mylist";

    constructor(private http : HttpClient) {}

    AddMovie(movie: IMovie){
      return this.http.post<IMovie>(this.movieUrl , movie);
    }

    GetAllMovies(){
      return this.http.get<IMovie[]>(this.movieUrl);
    }

    GetUpcomingMovies(){
      return this.http.get<IMovie[]>(this.upcomingMovieUrl);
    }

    GetFeaturedMovies(){
      return this.http.get<IMovie[]>(this.featuredMovieUrl);
    }

    GetNewReleases(){
      return this.http.get<IMovie[]>(this.newMovieUrl);
    }

    GetMovie(id : string){
      return this.http.get<IMovie>(this.movieUrl + `/${id}`);
    }

    GetMyMovies(id: string){
      return this.http.get<IMovie[]>(this.myMoviesUrl + `/${id}`);
    }

  }