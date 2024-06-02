import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'tm-trades',
  templateUrl: './trades.component.html',
  standalone: true,
  imports: [CommonModule, RouterLink],
  styleUrl: './trades.component.css',
})
export class TradesComponent {}
