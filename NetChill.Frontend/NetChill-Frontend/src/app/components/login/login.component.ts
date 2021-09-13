import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/data-service/user-service.component';
import { userDataService } from 'src/app/data-service/userData-service.component';
import { IUser } from 'src/app/models/IUser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  title: string = 'Login here!';
  isInvalid: boolean = false;

  checkStatus!: boolean;

  constructor(private userService: UserService, private router: Router, private userDataService: userDataService) {
    this.checkStatus = false;
  }

  ngOnInit(): void {
  }

  onSubmit(signInForm: NgForm) {
    if (signInForm.valid && this.checkStatus) {
      this.userService.LoginUser(signInForm.value).subscribe(
        (res: IUser) => {
           alert("Logged In");
           this.userDataService.loggedInUser = {
            Email: res.Email,
            Password: res.Password,
            Role: res.Role,
            Id: res.Id,
            FullName: res.FullName
          }
          console.log(this.userDataService.loggedInUser);
          this.router.navigate(['/movies']);
        },
        (err) => {
          this.isInvalid = true;
          alert("Wrong email or password");
        }
      )
    }
  }

  loginUser() {

  }

  switchCheckbox() {
    this.checkStatus = !this.checkStatus;
  }

}
