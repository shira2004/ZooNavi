import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, tap } from 'rxjs';
import { Animal } from '../models/animal.model';

@Injectable({
  providedIn: 'root'
})
export class AnimalService {
  private cachedAnimals: Animal[] | null = null;

  constructor(private _httpClient: HttpClient) { }

  getAllAnimalsByServer(): Observable<Animal[]> {
    
    if (this.cachedAnimals) {
      console.log('without server call 🤩');
      return of(this.cachedAnimals);
    }
    console.log('go to call  server 😢')

    return this._httpClient.get<Animal[]>('https://localhost:7068/api/Animal')
      .pipe(
        tap((animals: Animal[]) => this.cachedAnimals = animals)
      );
  }
  addAnimal(animal: Animal): Observable<Animal> {
    return this._httpClient.post<Animal>('https://localhost:7068/api/Animal', animal);
  }

  getAnimalById(id:number):Observable<Animal> {
    return this._httpClient.get<Animal>(`https://localhost:7068/api/Animal/${id}`)
  }
 // getAnimalById(id: number): Observable<Animal> {
    // if (this.cachedAnimals) {
    //   const cachedAnimal = this.cachedAnimals.find(animal => animal.id === id);
    //   if (cachedAnimal) {
    //     console.log('Animal found in cache');
    //     return of(cachedAnimal);
    //   }
    // }

  updateAnimal(id: number, animal: Animal): Observable<Animal> {
    return this._httpClient.put<Animal>(`https://localhost:7068/api/Animal/${id}`, animal);
  }
  removeAnimal(id: number): Observable<Animal> {
    return this._httpClient.delete<Animal>(`https://localhost:7068/api/Animal/${id}`);
  }
}


