import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AnimalService } from '../../../services/animal.service';
import { APP_ROUTES } from '../../../app_routes';
import { Animal } from '../../../models/animal.model';
import { Riddle } from '../../../models/riddle.model';
import { RiddleService } from '../../../services/riddle.service';
import { DialogComponent } from '../../../dialogs/components/dialog/dialog.component';

@Component({
  selector: 'app-add-riddle',
 
  templateUrl: './add-riddle.component.html',
  styleUrl: './add-riddle.component.css'
})
export class AddRiddleComponent implements OnInit {
  public animalList!: Animal[];
  isLinear = true;
  selectedAnimalId!: number;
  goodAnswerValue!:any;
  new_riddle!:Riddle
  //public new_riddle!:Riddle;
  
  dialogData1 = {
    text1: 'Good!',
    text2: 'The riddle added successfully.',
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
    text2: 'rhe riddle didnt add  .',
    status:1,
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate([APP_ROUTES.ADMIN]);
        console.log('OK button clicked');

      },
    },
  };

  constructor(
    private _formBuilder: FormBuilder,
    public dialog: MatDialog,
    private router: Router,
    private _animalService: AnimalService,
    private _riddleService: RiddleService
  ){}

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

  firstFormGroup = this._formBuilder.group({
   question: ['', [Validators.required, Validators.minLength(10)]],
    ans1: ['', [Validators.required, Validators.minLength(2)]],
    ans2: ['', [Validators.required, Validators.minLength(2)]],
    ans3: ['', [Validators.required, Validators.minLength(2)]],
    good_ans:['',Validators.required],
    contentCtrl: [''],
  });
  
 
  animalSelected(animalId: number): void {
    this.selectedAnimalId = animalId;
    console.log(this.selectedAnimalId);
  }
  commit(){
    this.goodAnswerValue = this.firstFormGroup.get('good_ans')!.value;
    this.new_riddle = {
    questionId:0,
    question: this.firstFormGroup.get('question')!.value || '',
    answer1: this.firstFormGroup.get('ans1')!.value || '',
    answer2: this.firstFormGroup.get('ans2')!.value || '',
    answer3: this.firstFormGroup.get('ans3')!.value || '',
    correctAnswerId: this.goodAnswerValue ? parseInt(this.goodAnswerValue) || 0 : 0,
    animalId:this.selectedAnimalId
  };
  this._riddleService.addRiddle(this.new_riddle)
  .subscribe({
    next:(res) =>{
      console.log(res);
      this.dialog.open(DialogComponent, {
        data: this.dialogData1,
        height: '600px',
        width: '400px',
      });  
    },
    error:(err) =>{
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
  })
  


  }
}
