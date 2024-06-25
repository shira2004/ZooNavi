import { Component, OnInit } from '@angular/core';
import { AnimalService } from '../../../services/animal.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Animal } from '../../../models/animal.model';
import { APP_ROUTES } from '../../../app_routes';
import { DialogComponent } from '../../../dialogs/components/dialog/dialog.component';

@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrl: './remove.component.css'
})
export class RemoveComponent implements OnInit {


  selectedAnimalId!: number;
  public animalList!: Animal[];
  dialogData2 = {
    text1: 'nice',
    text2: 'we remone it.'
  }
  dialogData1 = {
    text1: 'we remove this animal from zoo !',
    text2: 'are you shure to remove this animal?.',
    button: {
      label: 'CONFIRM DELETE',
      onClick: () => {
        this._animalService.removeAnimal(this.selectedAnimalId).subscribe({
         next: (res) => {
          console.log('😊' , res); 
          this.dialog.open(DialogComponent, {
            data: this.dialogData2,
            height: '600px',
            width: '400px',
          });  

        }
        , 
        error: (err) => {
          console.log('🤦' , err); 
        }
      },)
      },
    },
  };
  constructor(
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
  animalSelected(animalId: number) {
    this.selectedAnimalId = animalId;
    console.log(this.selectedAnimalId);

    this.dialog.open(DialogComponent, {
      data: this.dialogData1,
      height: '600px',
      width: '400px',
    });  
  }

  }


