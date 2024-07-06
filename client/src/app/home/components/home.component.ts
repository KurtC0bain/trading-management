import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'tm-home',
  templateUrl: './home.component.html',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, RouterModule, CommonModule],
  styleUrl: './home.component.css',
})
export class HomeComponent {
  constructor(private fb: FormBuilder, private store: Store) {}
}
