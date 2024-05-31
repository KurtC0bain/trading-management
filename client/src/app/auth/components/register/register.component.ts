import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import { register } from '../../store/actions';
import { RegisterRequestInterface } from '../../types/registerRequest.interface';
import { RouterLink } from '@angular/router';
import { selectIsSubmitting } from '../../store/reducers';
import { AuthStateInterface } from '../../types/authState.interface';

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
  isSubmitting$ = this.store.select(selectIsSubmitting);

  constructor(
    private fb: FormBuilder,
    private store: Store<{ auth: AuthStateInterface }>
  ) {}

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
      this.store.dispatch(register({ request }));
    }
  }
}
