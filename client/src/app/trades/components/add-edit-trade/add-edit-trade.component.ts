import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogModule,
} from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import {
  Trade,
  PositionType,
  DirectionType,
  ResultType,
} from '../../types/trade.interface';
import { tradeActions } from '../../store/actions';
import { PairResponse } from '../../types/pair.interface';
import { Setup } from '../../../setups/types/setup.interface';
import { selectPairs } from '../../store/reducers';
import { selectSetups } from '../../../setups/store/reducers';
import { CreateTradeRequest } from '../../types/create-trade.interface';
import { UpdateTradeRequest } from '../../types/update-trade.interface';

@Component({
  selector: 'tm-add-edit-trade',
  templateUrl: './add-edit-trade.component.html',
  styleUrls: ['./add-edit-trade.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatDialogModule,
  ],
})
export class AddEditTradeComponent implements OnInit {
  tradeForm!: FormGroup;
  pairs$ = this.store.select(selectPairs);
  setups$ = this.store.select(selectSetups);
  isUpdateMode: boolean;

  positionTypes = Object.values(PositionType);
  directionTypes = Object.values(DirectionType);
  resultTypes = Object.values(ResultType);

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<AddEditTradeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Trade | null,
    private store: Store
  ) {
    this.isUpdateMode = !!data;
  }

  ngOnInit(): void {
    this.tradeForm = this.fb.group({
      setupID: [this.data?.setupID || '', Validators.required],
      pairID: [this.data?.pairID || '', Validators.required],
      date: [this.data?.date || new Date(), Validators.required],
      initialDeposit: [this.data?.initialDeposit || 0, Validators.required],
      priceEntry: [this.data?.priceEntry || 0, Validators.required],
      priceStop: [this.data?.priceStop || 0, Validators.required],
      priceTake: [this.data?.priceTake || 0, Validators.required],
      depositRisk: [this.data?.depositRisk || 0, Validators.required],
      positionType: [this.data?.positionType || '', Validators.required],
      directionType: [this.data?.directionType || '', Validators.required],
      rating: [this.data?.rating || 0, Validators.required],
    });

    if (this.isUpdateMode) {
      this.tradeForm.addControl(
        'resultType',
        this.fb.control(this.data?.resultType || '', Validators.required)
      );
      this.tradeForm.addControl(
        'profit',
        this.fb.control(this.data?.profit || 0, Validators.required)
      );
      this.tradeForm.addControl('id', this.fb.control(this.data?.id));
    }
  }

  onSubmit(): void {
    if (this.tradeForm.valid) {
      if (this.isUpdateMode) {
        let res = this.tradeForm.value;
        res.userID = '';
        // let newDate = new Date(res.date);
        // newDate.setDate(newDate.getDate() + 1);
        // res.date = newDate;
        this.store.dispatch(tradeActions.updateTrade({ trade: res }));
      } else {
        let res = this.tradeForm.value;
        res.userID = '';
        // let newDate = new Date(res.date);
        // newDate.setDate(newDate.getDate() + 1);
        // res.date = newDate;
        this.store.dispatch(tradeActions.createTrade({ trade: res }));
      }
      this.dialogRef.close();
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
