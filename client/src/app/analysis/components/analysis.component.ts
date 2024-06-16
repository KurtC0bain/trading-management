// analysis.component.ts
import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { ChartConfiguration, ChartData } from 'chart.js';
import { Observable } from 'rxjs';
import { BaseChartDirective } from 'ng2-charts';
import { CommonModule } from '@angular/common';
import { AssetsIncome, SetupsEfficiency } from '../types/analysis.interface';
import { selectAssetsIncome, selectSetupEfficiency } from '../store/reducers';
import { analysisActions } from '../store/actions';

@Component({
  selector: 'app-analysis',
  templateUrl: './analysis.component.html',
  styleUrls: ['./analysis.component.css'],
  standalone: true,
  imports: [CommonModule, BaseChartDirective],
})
export class AnalysisComponent {
  setupEfficiency$: Observable<SetupsEfficiency[] | null>;
  assetsIncome$: Observable<AssetsIncome[] | null>;

  setupEfficiencyData: ChartData<'doughnut'> = {
    labels: [],
    datasets: [{ data: [] }],
  };

  assetIncomeData: ChartData<'bar'> = {
    labels: [],
    datasets: [{ data: [] }],
  };

  constructor(private store: Store) {
    this.setupEfficiency$ = this.store.select(selectSetupEfficiency);
    this.assetsIncome$ = this.store.select(selectAssetsIncome);

    this.store.dispatch(analysisActions.getAssetsIncome());
    this.store.dispatch(analysisActions.getSetupsEfficiency());

    this.setupEfficiency$.subscribe((setups) => {
      if (setups) {
        this.setupEfficiencyData.labels = setups.map((se) => se.setupId);
        this.setupEfficiencyData.datasets[0].data = setups.map(
          (se) => se.efficiency
        );
      }
    });

    this.assetsIncome$.subscribe((assets) => {
      if (assets) {
        this.assetIncomeData.labels = assets.map((ai) => ai.assetId);
        this.assetIncomeData.datasets[0].data = assets.map((ai) => ai.income);
      }
    });
  }

  setupEfficiencyOptions: ChartConfiguration['options'] = {
    responsive: true,
  };

  assetIncomeOptions: ChartConfiguration['options'] = {
    responsive: true,
  };
}
