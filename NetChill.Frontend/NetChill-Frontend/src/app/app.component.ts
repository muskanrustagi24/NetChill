import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  <div class='container'>
  <router-outlet></router-outlet>
  </div>
  `
  /*
  template: `
  <nav class='navbar navbar-expand navbar-light bg-light'>
  <a class='navbar-brand' style="margin-left: 20px">{{title}}</a>
  <ul class='nav nav-pills'>
    <li><a class='nav-link' routerLink='/signup'>Sign Up</a></li>
    <li><a class='nav-link' routerLink='/login'>Login</a></li>
  </ul>
  </nav>
  <div class='container'>
  <router-outlet></router-outlet>
  </div>
  `
  */
})
export class AppComponent {
  title = 'NetChill-Frontend';
}
