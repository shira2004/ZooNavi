import { Component, OnInit } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';


import { HomeComponent } from './home/home.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { FooterComponent } from './footer/footer.component';
import { GoogleMapsModule } from '@angular/google-maps'
import { UserService } from './services/user.service';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    HomeComponent,
    TopBarComponent,
    FooterComponent,
    GoogleMapsModule,
    RouterModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'ZooNavi';

  constructor(private _userService: UserService) { }

  ngOnInit() {
    if (typeof localStorage !== 'undefined') {
      const currentUser = localStorage.getItem('CURRENT_USER');
      if (currentUser) {
        this._userService.updateUserStateValue(true);
        console.log('User set successfully');
      }
    }
  }
}