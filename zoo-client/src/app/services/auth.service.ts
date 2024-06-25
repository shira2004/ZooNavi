import { userLogIn } from './../models/userLogIn';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { tap } from 'rxjs';
import { loginRes } from '../models/logInRes.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _httpClient: HttpClient) { }

  LogIn(user: userLogIn) {
    
    return this._httpClient.post<loginRes>('https://localhost:7068/api/login', user)
    .pipe(
      tap((response: loginRes) => {
        console.log(response);
        localStorage.setItem("ACCESS_TOKEN", JSON.stringify(response.token));
        localStorage.setItem("CURRENT_USER", JSON.stringify({
          userName: response.userName, 
          userImage: response.userImage 
        }));
      })
    );
  }


  register(user: userLogIn) {
    return this._httpClient.post<loginRes>('https://localhost:7068/api/register', user)
    .pipe(   
      tap((response: loginRes) => {
        console.log(response);
        console.log(response);
        localStorage.setItem("ACCESS_TOKEN", JSON.stringify(response.token));
        localStorage.setItem("CURRENT_USER", JSON.stringify({
          userName: response.userName, 
          userImage: response.userImage 
        }));
      })
    );
  }
}


