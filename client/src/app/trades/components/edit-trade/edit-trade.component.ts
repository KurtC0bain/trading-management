import { Component, Inject } from '@angular/core';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogModule,
} from '@angular/material/dialog';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_FORMATS, MatNativeDateModule } from '@angular/material/core';
import { Trade } from '../../types/trade.interface';

const CUSTOM_DATE_FORMATS = {
  parse: {
    dateInput: 'DD/MM/YYYY',
  },
  display: {
    dateInput: 'DD/MM/YYYY',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};

@Component({
  selector: 'app-edit-trade-dialog',
  templateUrl: './edit-trade.component.html',
  styleUrls: ['./edit-trade.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    ReactiveFormsModule,
  ],
  providers: [{ provide: MAT_DATE_FORMATS, useValue: CUSTOM_DATE_FORMATS }],
})
export class EditTradeComponent {
  tradeForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<EditTradeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Trade,
    private fb: FormBuilder
  ) {
    this.tradeForm = this.fb.group({
      setupId: [data.setupId, Validators.required],
      pairId: [data.pairId, Validators.required],
      date: [data.date || new Date(), Validators.required],
      initialDeposit: [data.initialDeposit, Validators.required],
      riskAmount: [data.riskAmount, Validators.required],
      priceEntry: [data.priceEntry, Validators.required],
      priceStop: [data.priceStop, Validators.required],
      priceTake: [data.priceTake, Validators.required],
      profit: [data.profit, Validators.required],
      depositRisk: [data.depositRisk, Validators.required],
      riskRewardRatio: [data.riskRewardRatio, Validators.required],
      positionType: [data.positionType, Validators.required],
      directionType: [data.directionType, Validators.required],
      resultType: [data.resultType, Validators.required],
      rating: [data.rating, Validators.required],
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSaveClick(): void {
    if (this.tradeForm.valid) {
      this.dialogRef.close(this.tradeForm.value);
    }
  }
}
