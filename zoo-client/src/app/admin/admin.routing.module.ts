import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { AdminNavBarComponent } from "./components/admin-nav-bar/admin-nav-bar.component";
import { AddAnimalComponent } from "./components/add-animal/add-animal.component";
import { AddRiddleComponent } from "./components/add-riddle/add-riddle.component";
import { UpdateComponent } from "./components/update/update.component";
import { RemoveComponent } from "./components/remove/remove.component";


const adminRoute: Routes = [
  { path: '', redirectTo: 'admin-home', pathMatch: 'full' },
  { path: 'admin-home', component: AdminNavBarComponent},
  {path: 'add-animal', component: AddAnimalComponent},
  {path: 'add-riddle', component: AddRiddleComponent},
  {path: 'update', component: UpdateComponent},
  {path: 'delete', component: RemoveComponent}
  
]
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(adminRoute)
  ],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
