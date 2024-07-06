import { Component, Inject } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogModule,
} from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { setupActions } from '../../store/actions';
import { Setup } from '../../types/setup.interface';
import { Observable } from 'rxjs';
import { Factor } from '../../../factors/types/factor.interface';
import { factorActions } from '../../../factors/store/actions';
import { selectFactors } from '../../../factors/store/reducers';

@Component({
  selector: 'tm-add-edit-setup',
  templateUrl: './add-edit-setup.component.html',
  styleUrls: ['./add-edit-setup.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatDialogModule,
  ],
})
export class AddEditSetupComponent {
  setupForm: FormGroup;
  factors$!: Observable<Factor[] | null>;

  constructor(
    private fb: FormBuilder,
    private store: Store,
    private dialogRef: MatDialogRef<AddEditSetupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { setup: Setup }
  ) {
    this.setupForm = this.fb.group({
      id: [data.setup?.id || ''],
      name: [data.setup?.name || '', Validators.required],
      description: [data.setup?.description || '', Validators.required],
      factors: [data.setup?.factors || [], Validators.required],
    });

    this.factors$ = this.store.select(selectFactors);
  }

  onSubmit() {
    if (this.setupForm.valid) {
      const setup = this.setupForm.value;
      setup.userId = '';
      if (setup.id) {
        this.store.dispatch(setupActions.updateSetup({ setup }));
      } else {
        this.store.dispatch(setupActions.createSetup({ setup }));
      }
      this.dialogRef.close();
    }
  }

  onCancel() {
    this.dialogRef.close();
  }
}
