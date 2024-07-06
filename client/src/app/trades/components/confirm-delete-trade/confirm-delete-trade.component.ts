import { Component, Inject } from '@angular/core';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogModule,
} from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'tm-confirm-delete-dialog',
  templateUrl: './confirm-delete-trade.component.html',
  standalone: true,
  imports: [CommonModule, MatDialogModule, MatButtonModule],
})
export class ConfirmDeleteTradeComponent {
  constructor(
    public dialogRef: MatDialogRef<ConfirmDeleteTradeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { id: string }
  ) {}

  onNoClick(): void {
    this.dialogRef.close(false);
  }

  onYesClick(): void {
    this.dialogRef.close(true);
  }
}
