import { Component, OnInit } from '@angular/core';
import { Animal } from '../../../models/animal.model';
import { FormBuilder, Validators } from '@angular/forms';
import { AnimalService } from '../../../services/animal.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { APP_ROUTES } from '../../../app_routes';
import { DialogComponent } from '../../../dialogs/components/dialog/dialog.component';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrl: './update.component.css'
})
export class UpdateComponent implements OnInit {
  public animalList!: Animal[];
  isLinear = true;
  selectedAnimalId!: number;
  
  dialogData1 = {
    text1: 'Good!',
    text2: 'The animal added successfully.',
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate([APP_ROUTES.ADMIN]);
        console.log('OK button clicked');

      },
    },
  };
  dialogData2 = {
    text1: 'opopss!',
    text2: 'You didnt .',
    status:1,
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate([APP_ROUTES.HOME]);
        console.log('OK button clicked');

      },
    },
  };

  firstFormGroup = this._formBuilder.group({
    contentCtrl: ['', [Validators.required, Validators.minLength(5)]],
    AnimalName: ['', [Validators.minLength(2)]],
    AnimalDescription: ['', [Validators.minLength(10)]],
  });
  updatedAnimal!: Animal;


  constructor(
    private _formBuilder: FormBuilder,
    private _animalService: AnimalService,
    public dialog: MatDialog,
    private router: Router,
  ) { }

  ngOnInit() {
    this._animalService.getAllAnimalsByServer().subscribe({
      next: (res) => {
        this.animalList = res;
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      }
    });

  }

  commit() {
   console.log('in commit func');
   
    this.updatedAnimal = {
      name: this.firstFormGroup.get('AnimalName')!.value || '',
      description: this.firstFormGroup.get('AnimalDescription')!.value || '',
      animalId: this.updatedAnimal.animalId,
      cageId: this.updatedAnimal.cageId
      

    };
    
    console.log(this.updatedAnimal);
    this._animalService.updateAnimal(this.updatedAnimal.animalId, this.updatedAnimal).subscribe({
      next: (updatedAnimal) => {
        console.log('in next');
        
        console.log(updatedAnimal);
  
        this.dialog.open(DialogComponent, {
          data: this.dialogData1,
          height: '600px',
          width: '400px',
        });
        

      },
      error: (err) => {
        let errorMessage = 'An error occurred.';  
        console.log('Error object:', err.error);
        if (err.error.errors) {
          errorMessage = ''; 
          const errors = err.error.errors;
          for (const key in errors) {
            if (errors.hasOwnProperty(key)) {
              const errorMessages = errors[key];
              errorMessage += `${key}: ${errorMessages.join(', ')}\n`; 
            }
          }
        }
        console.log(errorMessage);    
        this.dialogData2.text2 = errorMessage;
      
        this.dialog.open(DialogComponent, {
          data: this.dialogData2,
          height: '600px',
          width: '400px',
        });
        

      }
    });

  }
  animalSelected(animalId: number): void {
    this.selectedAnimalId = animalId;
    console.log(this.selectedAnimalId);
    this._animalService.getAnimalById(this.selectedAnimalId).subscribe({
      next: (res) => {
        console.log(res);
        this.updatedAnimal = res;
        this.firstFormGroup.patchValue({
          AnimalName: this.updatedAnimal.name,
          AnimalDescription: this.updatedAnimal.description,
        });
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}
  



