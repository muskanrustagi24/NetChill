import { Injectable } from "@angular/core";
import { IUser } from "../models/IUser";

@Injectable({
    providedIn: 'root'
})

export class userDataService{
   public loggedInUser!: IUser;
}