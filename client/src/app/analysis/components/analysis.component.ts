import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'tm-analysis',
  templateUrl: './analysis.component.html',
  standalone: true,
  imports: [CommonModule, RouterLink],
  styleUrl: './analysis.component.css',
})
export class AnalysisComponent {}
