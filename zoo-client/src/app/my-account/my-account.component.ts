import { Component, OnInit } from '@angular/core';
import { User } from '../models/user.model';
import { CommonModule } from '@angular/common';
import { loginRes } from '../models/logInRes.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-my-account',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './my-account.component.html',
  styleUrl: './my-account.component.css'
})
export class MyAccountComponent implements OnInit {

  public userPoints!: number;
  public user!: loginRes

  constructor(
    private _userService: UserService
  ){}
  ngOnInit() {
    if (typeof localStorage !== 'undefined') {
      var currentUserString = localStorage.getItem('CURRENT_USER');
      if (currentUserString !== null) {
        var currentUser = JSON.parse(currentUserString);
        this.user = currentUser;
        this.getPoints();
      }

    } else {
      console.log('User data is not present in local storage.');
    }
  }
  getPoints() {
    this._userService.getPoint().subscribe({
      next:(response: any)=>{
        this.userPoints = response.points;

      },
      error:(err:any)=>{
        console.log(err);       
      }
    })

  }

}
