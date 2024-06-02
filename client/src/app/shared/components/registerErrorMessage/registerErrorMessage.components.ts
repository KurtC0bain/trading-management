import { Component, Input, OnInit } from '@angular/core';
import { RegisterErrorsInterface } from '../../../auth/types/registerError.interface';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'tm-register-errors-messages',
  templateUrl: './registerErrorMessage.components.html',
  standalone: true,
  imports: [CommonModule],
})
export class RegisterErrorMessages implements OnInit {
  @Input() registerErrors: RegisterErrorsInterface = {};

  errorMessages: string[] = [];

  ngOnInit(): void {
    this.errorMessages = Object.keys(this.registerErrors).map(
      (name: string) => {
        const messages = this.registerErrors[name].join(' ');
        return `${messages}`;
      }
    );
  }
}
