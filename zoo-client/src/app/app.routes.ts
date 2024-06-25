import { Component } from '@angular/core';
import { Routes } from '@angular/router';

import { NotFoundComponent } from './not-found/not-found.component';
import { MyAccountComponent } from './my-account/my-account.component';
import { SignUpComponent } from './log-in/components/sign-up/sign-up.component';
import { DialogComponent } from './dialogs/components/dialog/dialog.component';
import { HomeComponent } from './home/home.component';
import { SignInComponent } from './log-in/components/sign-in/sign-in.component';
import { userGuard } from './user.guard';
import { TripCalculatorComponent } from './trip-calculator/trip-calculator.component';
import { TripMapComponent } from './trip-map/trip-map.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', loadComponent: () => import('./home/home.component').then(c => c.HomeComponent) },

    { path: 'sign_in', component: SignInComponent },
    { path: 'sign_up', component: SignUpComponent },
    
    { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule) ,canActivate: [userGuard]  },
    { path: 'my_account', component: MyAccountComponent, canActivate: [userGuard]},
    { path: 'dialog', component: DialogComponent },
    { path: 'trip-calculator', component: TripCalculatorComponent ,canActivate: [userGuard] },

    { path: "trip-map", component: TripMapComponent,canActivate: [userGuard] },
    { path: '**', component: NotFoundComponent },
];
