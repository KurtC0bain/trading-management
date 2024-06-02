import { Component, Input, OnInit } from '@angular/core';
import { RegisterErrorsInterface } from '../../../auth/types/registerError.interface';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'tm-login-errors-messages',
  templateUrl: './loginErrorMessage.components.html',
  standalone: true,
  imports: [CommonModule],
})
export class LoginErrorMessages implements OnInit {
  @Input() loginErrors: RegisterErrorsInterface = {};

  errorMessages: string[] = [];

  ngOnInit(): void {
    this.errorMessages = Object.keys(this.loginErrors).map((name: string) => {
      const messages = this.loginErrors[name].join(' ');
      return `${messages}`;
    });
  }
}
