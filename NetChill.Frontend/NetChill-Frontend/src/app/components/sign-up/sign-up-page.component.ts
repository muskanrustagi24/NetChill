import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/data-service/user-service.component';
import { userDataService } from 'src/app/data-service/userData-service.component';
import { IUser } from 'src/app/models/IUser';

@Component({
  selector: 'app-signup',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.css']
})
export class SignUpPageComponent implements OnInit {
  title: string = 'Sign-up here!';
  newUser!: IUser;
  isInvalid: boolean = false;
  constructor(private userService: UserService , private userDataService: userDataService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(signUpForm: NgForm) {
    if (signUpForm.valid) {
      this.newUser = {
        Id: '',
        Email: signUpForm.value.Email,
        FullName: signUpForm.value.FullName,
        Password: signUpForm.value.Password,
        Role: 0
      };
      console.log(this.newUser);
      this.userService.AddUser(this.newUser).subscribe(
        (res) => {
          alert("Signed up!");
          this.router.navigate(['/login']);
          },
        err => {
          this.isInvalid = true;
          console.log(err);
        }
      )
    }
  }

}
