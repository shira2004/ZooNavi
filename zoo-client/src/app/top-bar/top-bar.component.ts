import { Observable } from 'rxjs';
import { UserService } from './../services/user.service';
import { APP_ROUTES } from './../app_routes';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SignUpComponent } from '../log-in/components/sign-up/sign-up.component';
import { SignInComponent } from '../log-in/components/sign-in/sign-in.component';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-top-bar',
  standalone: true,
  imports: [SignUpComponent , SignInComponent , CommonModule],
  templateUrl: './top-bar.component.html',
  styleUrl: './top-bar.component.css'
})
export class TopBarComponent implements OnInit {
  isLogIn$! : Observable<boolean>;
 // updateUserState$! : Observable<boolean>;

  constructor(private router: Router, private _userService: UserService) { }
  ngOnInit() {
  this.isLogIn$ = this._userService._updateUserState;
   }
  log_in(){
    console.log('hi');
    this.router.navigate([APP_ROUTES.SIGN_IN])
  }
  my_account(){
    console.log('hi');
    this.router.navigate([APP_ROUTES.MY_ACCOUNT])
  }
  map(){
    this._userService._updateUserState.subscribe(user =>{
      
      console.log(user);
    })
    this.router.navigate([APP_ROUTES.TRIP_MAP])
  }
  calculate_trip(){
    this.router.navigate([APP_ROUTES.TRIP_CALCULATOR])
  }
  log_out() {
    console.log('i am cleaning the local storage');
    localStorage.clear();
  
    this. _userService.updateUserStateValue(false);
    this.router.navigate([APP_ROUTES.HOME]);
  }

  handleLogIn(loggedIn: boolean) {
    // this.isLogIn=!this.isLogIn
    console.log('User logged in:', loggedIn);
   
  }

}
