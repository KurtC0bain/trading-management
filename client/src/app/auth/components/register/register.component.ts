import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import { authActions } from '../../store/actions';
import { RegisterRequestInterface } from '../../types/registerRequest.interface';
import { RouterLink } from '@angular/router';
import {
  selectIsSubmitting,
  selectValidationErrors,
} from '../../store/reducers';
import { combineLatest } from 'rxjs';
import { RegisterErrorMessages } from '../../../shared/components/registerErrorMessage/registerErrorMessage.components';

@Component({
  selector: 'tm-register',
  templateUrl: './register.component.html',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    RouterLink,
    RegisterErrorMessages,
  ],
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  form = this.fb.nonNullable.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
    confirmPassword: ['', Validators.required],
  });

  submitted = false;
  data$ = combineLatest({
    isSubmitting: this.store.select(selectIsSubmitting),
    registerErrors: this.store.select(selectValidationErrors),
  });

  constructor(private fb: FormBuilder, private store: Store) {}

  passwordMatchValidator(form: FormGroup) {
    return form.get('password')?.value === form.get('confirmPassword')?.value
      ? null
      : { mismatch: true };
  }

  onSubmit() {
    if (
      this.form.get('password')?.value !==
      this.form.get('confirmPassword')?.value
    )
      return;
    this.submitted = true;
    if (this.form.valid) {
      console.log(this.form.getRawValue());
      const request: RegisterRequestInterface = {
        email: this.form.get('email')?.getRawValue(),
        password: this.form.get('password')?.getRawValue(),
      };
      this.store.dispatch(authActions.register({ request }));
    }
  }
}
