import { AuthService } from './../../../services/auth.service';
import { Input, Component, Output, EventEmitter, OnInit } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormControl, Validators, FormsModule, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';

import { Router } from '@angular/router';
import { APP_ROUTES } from '../../../app_routes';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from '../../../dialogs/components/dialog/dialog.component';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    CommonModule
  ],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.css'
})
export class SignInComponent {
  constructor(private router: Router ,
    private _authService :AuthService , 
    public dialog: MatDialog,
    private _userService: UserService) { }
  ngOnInit(): void {
    this.SignInForm = new FormGroup({
      //email: new FormControl(''),
      userName: new FormControl('', [Validators.required]),
      password: new FormControl('', [
        Validators.required,
        Validators.pattern(/^(?=.*[a-zA-Z])(?=.*\d).{6,}$/),
      ]),
    });
  }
  SignInForm!: FormGroup;
  hide = true;
  dialogData1 = {
    text1: 'Welcome Back!',
    text2: 'Youre now logged in to Zoonavi. Lets explore the zoo together!',
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate([APP_ROUTES.HOME]);
        console.log('OK button clicked');

      },
    },
  };
  dialogData2 = {
    text1: 'Access Denied!',
    text2: 'Login unsuccessful. Please verify your credentials and try again.',
    status:1,
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate([APP_ROUTES.HOME]);
        console.log('OK button clicked');

      },
    },
  };


  submit() {
    console.log('Form Object:', this.SignInForm.value);
    
    this._authService.LogIn(this.SignInForm.value).subscribe({
      next: (res) => {
        console.log(res);  
        this.dialog.open(DialogComponent, {
          data: this.dialogData1,
          height: '600px',
          width: '400px',
        });
        
        this._userService.updateUserStateValue(true);
      },
      error: (err) => {
        console.error('Login error:', err);
        this.dialog.open(DialogComponent, {
          data: this.dialogData2,
          height: '600px',
          width: '400px',
        });
      }
    });
  }
  
  GoToSignUp() {
    console.log('go to sign up ');
    this.router.navigate([APP_ROUTES.SIGN_UP]);
  }

}
