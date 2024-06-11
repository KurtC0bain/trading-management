import { Component, Inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogModule,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { tradeActions } from '../../store/actions';
import {
  PositionType,
  DirectionType,
  ResultType,
} from '../../types/trade.interface';
import { Setup } from '../../../setups/types/setup.interface';
import { CreateTradeRequest } from '../../types/create-trade.interface';
import { UpdateTradeRequest } from '../../types/update-trade.interface';
import { selectSetups } from '../../../setups/store/reducers';
import { setupActions } from '../../../setups/store/actions';

@Component({
  selector: 'tm-add-edit-trade',
  templateUrl: './add-edit-trade.component.html',
  styleUrls: ['./add-edit-trade.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
  ],
})
export class AddEditTradeComponent implements OnInit {
  tradeForm!: FormGroup;
  isEditMode: boolean = false;
  setups$!: Observable<Setup[] | null>;

  positionTypes = Object.values(PositionType);
  directionTypes = Object.values(DirectionType);
  resultTypes = Object.values(ResultType);

  constructor(
    private fb: FormBuilder,
    private store: Store,
    private dialogRef: MatDialogRef<AddEditTradeComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: CreateTradeRequest | UpdateTradeRequest | null
  ) {}

  ngOnInit(): void {
    this.isEditMode = !!this.data && 'id' in this.data;

    this.tradeForm = this.fb.group({
      userId: [this.data ? this.data.userId : '', Validators.required],
      setupId: [this.data ? this.data.setupId : '', Validators.required],
      pairId: [this.data ? this.data.pairId : '', Validators.required],
      date: [this.data ? this.data.date : new Date(), Validators.required],
      initialDeposit: [
        this.data ? this.data.initialDeposit : '',
        Validators.required,
      ],
      priceEntry: [this.data ? this.data.priceEntry : '', Validators.required],
      priceStop: [this.data ? this.data.priceStop : '', Validators.required],
      priceTake: [this.data ? this.data.priceTake : '', Validators.required],
      depositRisk: [
        this.data ? this.data.depositRisk : '',
        Validators.required,
      ],
      positionType: [
        this.data ? this.data.positionType : '',
        Validators.required,
      ],
      directionType: [
        this.data ? this.data.directionType : '',
        Validators.required,
      ],
      rating: [this.data ? this.data.rating : '', Validators.required],
      ...(this.isEditMode && {
        id: [(this.data as UpdateTradeRequest).id],
        resultType: [(this.data as UpdateTradeRequest).resultType],
        profit: [(this.data as UpdateTradeRequest).profit],
      }),
    });

    this.store.dispatch(setupActions.getAllSetups());

    this.setups$ = this.store.select(selectSetups);
  }

  onSave(): void {
    if (this.tradeForm.valid) {
      const trade = this.tradeForm.value;
      if (this.isEditMode) {
        this.store.dispatch(
          tradeActions.updateTrade({ trade: trade as UpdateTradeRequest })
        );
      } else {
        this.store.dispatch(
          tradeActions.createTrade({ trade: trade as CreateTradeRequest })
        );
      }
      this.dialogRef.close();
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
