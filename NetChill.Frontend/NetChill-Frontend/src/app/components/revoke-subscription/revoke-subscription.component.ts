import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/data-service/user-service.component';
import { IUser } from 'src/app/models/IUser';

@Component({
  selector: 'app-revoke-subscription',
  templateUrl: './revoke-subscription.component.html',
  styleUrls: ['./revoke-subscription.component.css']
})
export class RevokeSubscriptionComponent implements OnInit {
  AllUsers!: IUser[];

  constructor(private userService : UserService) { }

  ngOnInit(): void {
    document.getElementById('revokeSubscription')?.classList.add('active');
    this.GetAllUsers();
  }

  GetAllUsers(){
    this.userService.GetAllUsers().subscribe({
      next: users => {
        this.AllUsers = users;
        console.log(this.AllUsers);
      },
      error: err => console.log(err)
    }
    )
  }

  RevokeSubscription(Id: string){
    this.userService.RemoveUser(Id).subscribe(
      (res) => {
        alert("Subscription Revoked!");
        window.location.reload();
      },
      (err) => {
        console.log(err);
      }
    )
  }

}
