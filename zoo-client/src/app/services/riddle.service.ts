import { Riddle } from './../models/riddle.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RiddleService {

  constructor(private _httpClient:HttpClient) { }

  getRiddle(id: number): Observable<Riddle> {
    return this._httpClient.get<Riddle>(`https://localhost:7068/api/Riddle/riddle/${id}`);
  }
  
  addRiddle(riddle: Riddle): Observable<Riddle> {
    return this._httpClient.post<Riddle>('https://localhost:7068/api/riddle', riddle);
  }



}
