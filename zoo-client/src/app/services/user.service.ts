import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { Observable, BehaviorSubject, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  user:boolean = false;

   bool!:boolean
   constructor(private _httpClient: HttpClient) { 

   }
  public _updateUserState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
 

  addUserByServer(user: User): Observable<User> {
    return this._httpClient.post<User>('https://localhost:7068/api/User', user);
  }

  getUserById(id: number): Observable<User> {
    return this._httpClient.get<User>(`https://localhost:7068/api/User/${id}`);
  }
  
  addPoint(): Observable<any> { 
    return this._httpClient.get('https://localhost:7068/api/User/addpoint' );
  }
  getPoint(): Observable<any> { 
    return this._httpClient.get('https://localhost:7068/api/User/getpoints' );
  }

  public updateUserStateValue(newState: boolean): void {
    this._updateUserState.next(newState);
  }
}