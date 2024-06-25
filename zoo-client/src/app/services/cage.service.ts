import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, of, tap } from 'rxjs';
import { Cage } from '../models/cage.model';

@Injectable({
  providedIn: 'root'
})
export class CageService {
  private cachedCages: Cage[] | null = null;

  constructor(private _httpClient: HttpClient) { }

  getAllCagesByServer(): Observable<Cage[]> {
    if (this.cachedCages) {
      console.log('without server call 🤩');
      return of(this.cachedCages);
    }
    console.log('go to call server 😢');

    return this._httpClient.get<Cage[]>('https://localhost:7068/api/Cage')
      .pipe(
        tap((cages: Cage[]) => this.cachedCages = cages)
      );
  }

  addCage(cage: Cage): Observable<Cage> {
    console.log('i am here in service');
    
    return this._httpClient.post<Cage>('https://localhost:7068/api/Cage', cage);
  }


  getCagesByIds(cagesIds: number[]): Observable<Cage[]> {
    console.log('getByCagesIds😁😁😁😁😁😁😁😁😁😁😁', cagesIds);

    if (!this.cachedCages) {
      // If cachedCages is null, fetch cages from server
      return this.getAllCagesByServer().pipe(
        map(() => this.filterCagesByIds(cagesIds))
      );
    } else {
      // If cachedCages is not null, filter directlyפ
      return of(this.filterCagesByIds(cagesIds));
    }
  }

  private filterCagesByIds(cagesIds: number[]): Cage[] {
    return this.cachedCages!.filter(cage => cagesIds.includes(cage.cageID));
  }
}
