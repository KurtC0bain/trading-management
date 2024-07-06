import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ReactiveFormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { Factor } from '../../types/factor.interface';
import { factorActions } from '../../store/actions';
import { selectFactors, selectIsFactorsLoading } from '../../store/reducers';
import { AddEditFactorComponent } from '../add-edit-factor/add-edit-factor.component';

@Component({
  selector: 'tm-home',
  templateUrl: './factors.component.html',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
    ReactiveFormsModule,
    MatDialogModule,
  ],
  styleUrl: './factors.component.css',
})
export class FactorsComponent implements OnInit {
  factors$!: Observable<Factor[] | null>;
  loading$!: Observable<boolean>;

  constructor(private dialog: MatDialog, private store: Store) {}

  ngOnInit(): void {
    this.store.dispatch(factorActions.getAllFactors());
    this.factors$ = this.store.select(selectFactors);
    this.loading$ = this.store.select(selectIsFactorsLoading);
  }

  onAdd() {
    this.dialog.open(AddEditFactorComponent, {
      width: '400px',
      data: { factor: null },
    });
  }

  onEdit(factor: Factor) {
    this.dialog.open(AddEditFactorComponent, {
      width: '400px',
      data: { factor },
    });
  }

  onDelete(factorId: string) {
    this.store.dispatch(factorActions.deleteFactor({ factorId }));
  }
}
