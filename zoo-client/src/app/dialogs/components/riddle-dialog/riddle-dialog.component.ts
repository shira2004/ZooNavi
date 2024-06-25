import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-riddle-dialog',
  templateUrl: './riddle-dialog.component.html',
  styleUrl: './riddle-dialog.component.css'
})
export class RiddleDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any , public dialogRef: MatDialogRef<RiddleDialogComponent>) {}
  
  onClose()  {
    this.dialogRef.close();
  }
  // onClick(num:number) {

  //   console.log(num);
    
  // }
}
