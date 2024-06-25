import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';


import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { AdminNavBarComponent } from './components/admin-nav-bar/admin-nav-bar.component';
import { AddAnimalComponent } from './components/add-animal/add-animal.component';
import { AdminRoutingModule } from './admin.routing.module';
import { AddRiddleComponent } from './components/add-riddle/add-riddle.component';
import { UpdateComponent } from './components/update/update.component';
import { RemoveComponent } from './components/remove/remove.component';


@NgModule({
  declarations: [
    AdminNavBarComponent,
    AddRiddleComponent,
    AddAnimalComponent,
    UpdateComponent,
    RemoveComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MatButtonModule,
    MatStepperModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatCardModule,
    MatChipsModule,
    MatIconModule,
    MatButtonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }