import { Component } from '@angular/core';
import { APP_ROUTES } from '../../../app_routes';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-nav-bar',
 
  templateUrl: './admin-nav-bar.component.html',
  styleUrl: './admin-nav-bar.component.css'
})
export class AdminNavBarComponent {
  constructor(private router: Router){}

  addEvent(){
    this.router.navigate([APP_ROUTES.ADD_RIDDLE])
    console.log('hi');
    
  }

  add(){
    this.router.navigate([APP_ROUTES.ADD])
    console.log('hi');
   }

  update(){
    this.router.navigate([APP_ROUTES.UPDATE])
    console.log('hi');
  }

  delete(){
    this.router.navigate([APP_ROUTES.DELETE])
    console.log('hi');
  }
}
