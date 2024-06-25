import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

import { Cage } from '../../../models/cage.model';
import { Animal } from '../../../models/animal.model';

import { APP_ROUTES } from '../../../app_routes';
import { handleFileSelected } from '../../../helper';
import { CageService } from '../../../services/cage.service';
import { AnimalService } from '../../../services/animal.service';
import { DialogComponent } from '../../../dialogs/components/dialog/dialog.component';


@Component({
  selector: 'app-add-animal',
  templateUrl: './add-animal.component.html',
  styleUrl: './add-animal.component.css'
})
export class AddAnimalComponent implements OnInit {


  selectedImage: File | null = null;
  base64Image: string | null = null;
  showCodeField = false;
  code: string = '';

  public userId!: number;
  public cageId!: number;

  firstFormGroup = this._formBuilder.group({
    latitude: [0, [Validators.required, Validators.min(-90), Validators.max(90)]],
    longitude: [0, [Validators.required, Validators.min(-180), Validators.max(180)]],
    contentCtrl: [''],
  });
  secondFormGroup = this._formBuilder.group({
    AnimalName: ['', [Validators.minLength(2)]],
    AnimalDescription: ['', [Validators.minLength(10)]],  
    customOption: [0]
  });
  isLinear = true;
  cage!: Cage;
  animal!: Animal;

 
  constructor(
    private _formBuilder: FormBuilder,
    private _cageService: CageService,
    private _animalService: AnimalService,
    public dialog: MatDialog,
    private router: Router,
  ) { }
  ngOnInit(): void {
   
  }


  dialogData1 = {
    text1: 'good !',
    text2: 'Your Cage has been successfully added.',
    imageSrc: '../../../../assets/images/load.gif',
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate([APP_ROUTES.HOME]);
        console.log('OK button clicked');

      },
    },
  };

  dialogData2 = {
    text1: 'ooppss!',
    text2: 'we have problem with creating your quest.',
    imageSrc: '../../../../assets/images/load.gif',
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate(['home']);
        console.log('OK button clicked');

      },
    },
  };
  commit() {
    this.cage = {
      cageID: 0,
      zooId: 1,
      size:0,
      notes: this.firstFormGroup.get('contentCtrl')!.value || '',
      latitude: this.firstFormGroup.get('latitude')!.value || 0,
      longitude: this.firstFormGroup.get('longitude')!.value || 0,
    };
    console.log('👌',this.cage);

    this._cageService.addCage(this.cage)
      .subscribe({
        next: (CageRes) => {
          console.log('😊');
          console.log(CageRes);
          this.cageId = CageRes.cageID

          this.animal = {
            animalId: 0,
            cageId: this.cageId,
            name:this.secondFormGroup.get('AnimalName')!.value||'',
            description:this.secondFormGroup.get('AnimalDescription')!.value||'',
            image: this.base64Image || '',
          };
          console.log(this.animal);

          this.createAnimal();
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
          console.log(err);
          this.dialog.open(DialogComponent, {
            data: this.dialogData2,
            height: '600px',
            width: '400px',
          });

        }
      });
  }

  createAnimal() {
    if(this.animal.cageId!= undefined){
    this._animalService.addAnimal(this.animal)
      .subscribe({
        next: (AnimalRes) => {
          console.log(AnimalRes);
          this.dialog.open(DialogComponent, {
            data: this.dialogData1,
            height: '500px',
            width: '350px',
          });

        },
        error: (err) => {
          console.log(err);

        }
      });
    }
   
  }
  onFileSelected(event: any): void {
    handleFileSelected(event, (base64Image) => {
      this.selectedImage = event.target.files[0];
      this.base64Image = base64Image;
     
    });
  }

}

