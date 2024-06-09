import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { AssetRateResponse } from '../../types/asset-rate.interface';

@Component({
  selector: 'tm-assets-rates',
  templateUrl: './assets-rates.component.html',
  styleUrls: ['./assets-rates.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatProgressSpinnerModule,
  ],
})
export class AssetsRatesComponent {
  @Input() assetRates!: AssetRateResponse[] | null;
  @Input() loading!: boolean | null;
}
