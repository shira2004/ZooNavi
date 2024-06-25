import { Component, OnInit } from '@angular/core';

import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormBuilder } from '@angular/forms';
import { AnimalService } from '../services/animal.service';
import { Animal } from '../models/animal.model';
import { MatChipsModule } from '@angular/material/chips';
import { Router } from '@angular/router';
import { APP_ROUTES } from '../app_routes';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-trip-calculator',
  standalone: true,
  imports: [MatButtonModule,CommonModule ,  MatChipsModule, MatFormFieldModule, MatInputModule, MatSelectModule],
  templateUrl: './trip-calculator.component.html',
  styleUrl: './trip-calculator.component.css'
})
export class TripCalculatorComponent implements OnInit {

  public animalList!: Animal[];
  selectedAnimals: number[] = [];
  chipsColor: string = '';

  constructor(
    private _formBuilder: FormBuilder,
    private _animalService: AnimalService,
    private router: Router

  ){}
  ngOnInit() {
    this._animalService.getAllAnimalsByServer().subscribe({
      next: (res) => {
        this.animalList = res;
      },
      error: (err) => {
        console.log(err);
      }
    });   
     
  }
  categorySelected(cageId: number): void {
    if (this.selectedAnimals.includes(cageId)) {
      this.selectedAnimals = this.selectedAnimals.filter((selectedId) => selectedId !== cageId);
    } else {
      this.selectedAnimals.push(cageId);
      console.log('add to list of cages' , cageId);
      this.chipsColor = 'blue';
    }
  }

  confirmSelectionQuestion(): void {
    console.log('hiii');
    console.log(this.selectedAnimals);
    
    console.log('Selected animals:', this.selectedAnimals);

    this.router.navigate([APP_ROUTES.TRIP_MAP], {
      queryParams: {cages: this.selectedAnimals.join(',') }
    });
  }

  
  }


