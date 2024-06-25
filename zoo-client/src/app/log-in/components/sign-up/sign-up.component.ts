import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, Validators, FormsModule, ReactiveFormsModule, FormGroup } from '@angular/forms';


import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { APP_ROUTES } from '../../../app_routes';

import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialog } from '@angular/material/dialog'

import { User } from '../../../models/user.model';
import { UserService } from '../../../services/user.service';
import { DialogComponent } from '../../../dialogs/components/dialog/dialog.component';
import { handleFileSelected } from '../../../helper';
import { AuthService } from '../../../services/auth.service';


@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatCheckboxModule,
    RouterModule,
    CommonModule
  ],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css'
})
export class SignUpComponent implements OnInit {
  
  SignUpForm!: FormGroup;
  hide = true;
  ErrorMessage='';
  selectedImage: File | null = null;
  base64Image: string | null = null;


  constructor(private router: Router,
    private _userService: UserService,
    public dialog: MatDialog,
    private _authService :AuthService  ) { }
  ngOnInit(): void {
    this.SignUpForm = new FormGroup({
      // firstName: new FormControl(''),
      // lastName: new FormControl(''),
      userName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.pattern(/^(?=.*[a-zA-Z])(?=.*\d).{6,}$/),
      ]),
    });
  }

  dialogData1 = {
    text1: 'Welcome Aboard!',
    text2: 'Youve successfully signed up to Zoonavi. Start exploring the zoo now!',
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate([APP_ROUTES.HOME]);
        console.log('OK button clicked');
      },
    },
  };

  dialogData2 = {
    text1: 'Oops, Try Again!',
    text2: this.ErrorMessage,
    status:1,
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate(['home']);
        console.log('OK button clicked');

      },
    },
  };
  submit() {
    console.log('Form Object:', this.SignUpForm.value);
    const userToAdd: User = {
      ...this.SignUpForm.value,
      image: this.base64Image || '',
    };
    console.log('before service call', userToAdd);
    this._authService.register(userToAdd).subscribe({
      next: (res) => {
        console.log(res);
        this._userService.updateUserStateValue(true);
        this.dialog.open(DialogComponent, {
          data: this.dialogData1,
          height: '500px',
          width: '350px',
        });
        this._userService.updateUserStateValue(true);
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
        if(err.error.UserName){
          errorMessage += `UserName: ${err.error.UserName.join(', ')}\n`;
        }  
        if(err.error.email){
          errorMessage += `Email : ${err.error.email.join(', ')}\n`;
        }      
        console.log(errorMessage);    
        this.dialogData2.text2 = errorMessage;
    
        this.dialog.open(DialogComponent, {
          data: this.dialogData2
        });
      }
    });
    
   }


  GoToSignIn() {
    console.log('go to sign in ');
    this.router.navigate([APP_ROUTES.SIGN_IN]);
  }

  onFileSelected(event: any): void {
    handleFileSelected(event, (base64Image) => {
      this.selectedImage = event.target.files[0];
      this.base64Image = base64Image;

    });

  }
}  
