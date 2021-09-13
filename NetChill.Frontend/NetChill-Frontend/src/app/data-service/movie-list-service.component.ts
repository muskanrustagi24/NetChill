import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IMovieList } from "../models/IMovieList";

@Injectable({
    providedIn: 'root'
})

export class MovieListService{
    private movieListUrl = "https://localhost:44322/api/mylist";
    constructor(private http: HttpClient){}

    AddMovieToList(movie: IMovieList){
        return this.http.post(this.movieListUrl , movie);
    }

}