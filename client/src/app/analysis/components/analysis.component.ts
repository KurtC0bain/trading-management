import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Chart, ChartModule } from 'angular-highcharts';
import { AssetsIncome, SetupsEfficiency } from '../types/analysis.interface';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import {
  selectAssetsIncome,
  selectErrors,
  selectLoading,
  selectSetupEfficiency,
} from '../store/reducers';
import { analysisActions } from '../store/actions';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-analysis',
  templateUrl: './analysis.component.html',
  styleUrls: ['./analysis.component.css'],
  standalone: true,
  imports: [CommonModule, ChartModule],
})
export class AnalysisComponent implements OnInit {
  setupEfficiency$: Observable<SetupsEfficiency[] | null>;
  assetsIncome$: Observable<AssetsIncome[] | null>;
  loading$: Observable<boolean>;
  errors$: Observable<ErrorResponse | null>;

  setupEfficiencyChart!: Chart;
  assetsIncomeChart!: Chart;

  constructor(private store: Store) {
    this.store.dispatch(analysisActions.getAssetsIncome());
    this.store.dispatch(analysisActions.getSetupsEfficiency());
    this.setupEfficiency$ = this.store.select(selectSetupEfficiency);
    this.assetsIncome$ = this.store.select(selectAssetsIncome);
    this.loading$ = this.store.select(selectLoading);
    this.errors$ = this.store.select(selectErrors);
  }

  ngOnInit(): void {
    this.setupEfficiency$.subscribe((data) => {
      if (data) {
        let setupEfficiency = data;
        console.log(setupEfficiency);
        this.setupEfficiencyChart = new Chart({
          chart: { type: 'pie' },
          title: { text: 'Setup Efficiency' },
          xAxis: { categories: setupEfficiency.map((se) => se.setupId) },
          yAxis: { title: { text: 'Efficiency' } },
          series: [
            {
              type: 'pie',
              name: 'Efficiency',
              data: setupEfficiency.map((se) => ({
                name: se.setupId,
                y: se.efficiency,
              })),
            },
          ],
        });
      }
    });

    this.assetsIncome$.subscribe((data) => {
      if (data) {
        let assetsIncome = data;
        console.log(assetsIncome);
        this.assetsIncomeChart = new Chart({
          chart: { type: 'column' },
          title: { text: 'Assets Income' },
          xAxis: { categories: assetsIncome.map((ai) => ai.assetId) },
          yAxis: { title: { text: 'Income' } },
          series: [
            {
              type: 'column',
              name: 'Income',
              data: assetsIncome.map((se) => se.income),
            },
          ],
        });
      }
    });
  }
}
