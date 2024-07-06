import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, combineLatest, filter, map, pipe } from 'rxjs';

import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatChipsModule } from '@angular/material/chips';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { selectIsSetupsLoading, selectSetups } from '../../store/reducers';
import { setupActions } from '../../store/actions';
import { AddEditSetupComponent } from '../add-edit-setup/add-edit-setup.component';
import { Setup } from '../../types/setup.interface';
import { Factor } from '../../../factors/types/factor.interface';
import { selectFactors } from '../../../factors/store/reducers';
import { factorActions } from '../../../factors/store/actions';

@Component({
  selector: 'tm-setups',
  templateUrl: './setups.component.html',
  styleUrls: ['./setups.component.css'],
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
    MatChipsModule,
  ],
})
export class SetupsComponent implements OnInit {
  loading$!: Observable<boolean>;
  combinedSetups$!: Observable<any>;

  constructor(private store: Store, private dialog: MatDialog) {}

  ngOnInit() {
    this.store.dispatch(setupActions.getAllSetups());
    this.store.dispatch(factorActions.getAllFactors());
    this.loading$ = this.store.select(selectIsSetupsLoading);

    this.combinedSetups$ = combineLatest([
      this.store.select(selectSetups),
      this.store.select(selectFactors),
    ]).pipe(
      filter(([setups, factors]) => setups !== null && factors !== null), // Ensure both setups and factors are loaded
      map(([setups, factors]) =>
        (setups || []).map((setup) => ({
          ...setup,
          factorNames: (setup.factors || []).map((factorId) => {
            const factor = (factors || []).find((f) => f.id === factorId);
            return factor ? factor.name : 'Unknown';
          }),
        }))
      )
    );
  }

  onAdd() {
    this.dialog.open(AddEditSetupComponent, {
      width: '400px',
      data: { setup: null },
    });
  }

  onEdit(setup: Setup) {
    this.dialog.open(AddEditSetupComponent, {
      width: '400px',
      data: { setup },
    });
  }

  onDelete(setupId: string) {
    this.store.dispatch(setupActions.deleteSetup({ setupId }));
  }
}
