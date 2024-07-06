import { Component, Inject } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogModule,
} from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Factor } from '../../types/factor.interface';
import { factorActions } from '../../store/actions';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-edit-factor',
  templateUrl: './add-edit-factor.component.html',
  styleUrls: ['./add-edit-factor.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
  ],
})
export class AddEditFactorComponent {
  factorForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private store: Store,
    private dialogRef: MatDialogRef<AddEditFactorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { factor: Factor }
  ) {
    this.factorForm = this.fb.group({
      id: [data.factor?.id || ''],
      name: [data.factor?.name || '', Validators.required],
      description: [data.factor?.description || '', Validators.required],
      priority: [
        data.factor?.priority || 1,
        [Validators.required, Validators.min(1)],
      ],
    });
  }

  onSubmit() {
    if (this.factorForm.valid) {
      const factor = this.factorForm.value;
      factor.userId = '';
      if (factor.id) {
        this.store.dispatch(factorActions.updateFactor({ factor }));
      } else {
        this.store.dispatch(factorActions.createFactor({ factor }));
      }
      this.dialogRef.close();
    }
  }

  onCancel() {
    this.dialogRef.close();
  }
}
