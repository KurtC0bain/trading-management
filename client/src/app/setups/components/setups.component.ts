import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'tm-setups',
  templateUrl: './setups.component.html',
  standalone: true,
  imports: [CommonModule, RouterLink],
  styleUrl: './setups.component.css',
})
export class SetupsComponent {}
