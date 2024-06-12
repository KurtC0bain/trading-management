import { CommonModule } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatListModule } from '@angular/material/list';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatChipsModule } from '@angular/material/chips';
import { Observable, combineLatest } from 'rxjs';
import { map, filter, tap } from 'rxjs/operators';
import { DirectionType, ResultType, Trade } from '../../types/trade.interface';
import { Store } from '@ngrx/store';
import {
  selectAssets,
  selectIsAssetsLoading,
  selectIsLoading,
  selectIsPairsLoading,
  selectPairs,
  selectTrades,
} from '../../store/reducers';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { tradeActions } from '../../store/actions';
import { AddEditTradeComponent } from '../add-edit-trade/add-edit-trade.component';
import { ConfirmDeleteTradeComponent } from '../confirm-delete-trade/confirm-delete-trade.component';
import { AssetsRatesComponent } from '../assets-rates/assets-rates.component';
import { AssetRateResponse } from '../../types/asset-rate.interface';
import { PairResponse } from '../../types/pair.interface';
import { Setup } from '../../../setups/types/setup.interface';
import { setupActions } from '../../../setups/store/actions';
import {
  selectIsSetupsLoading,
  selectSetups,
} from '../../../setups/store/reducers';
import { Conditional } from '@angular/compiler';

@Component({
  selector: 'tm-trades',
  templateUrl: './trades.component.html',
  styleUrls: ['./trades.component.css'],
  standalone: true,
  imports: [
    AssetsRatesComponent,
    CommonModule,
    RouterLink,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatListModule,
    MatTableModule,
    MatPaginatorModule,
    RouterModule,
    ReactiveFormsModule,
    MatSortModule,
    MatIconModule,
    MatDialogModule,
    MatChipsModule,
    MatProgressSpinnerModule,
  ],
})
export class TradesComponent {
  trades$!: Observable<Trade[] | null>;
  isLoading$!: Observable<boolean>;
  setups$!: Observable<Setup[] | null>;
  isSetupsLoading$!: Observable<boolean>;
  pairs$!: Observable<PairResponse[] | null>;
  isPairsLoading$!: Observable<boolean>;
  assetRates$!: Observable<AssetRateResponse[] | null>;
  isAssetsLoading$!: Observable<boolean>;

  displayedColumns: string[] = [
    'setup',
    'pair',
    'date',
    'initialDeposit',
    'riskAmount',
    'priceEntry',
    'priceStop',
    'priceTake',
    'profit',
    'depositRisk',
    'riskRewardRatio',
    'positionType',
    'directionType',
    'resultType',
    'rating',
    'actions',
  ];
  dataSource = new MatTableDataSource<Trade>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  pairsMap: { [key: string]: string } = {};
  setupsMap: { [key: string]: string } = {};

  constructor(private store: Store, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.store.dispatch(tradeActions.getAllTrades());
    this.store.dispatch(tradeActions.getAllPairs());
    this.store.dispatch(setupActions.getAllSetups());

    this.isLoading$ = this.store.select(selectIsLoading);
    this.isSetupsLoading$ = this.store.select(selectIsSetupsLoading);
    this.isPairsLoading$ = this.store.select(selectIsPairsLoading);
    this.isAssetsLoading$ = this.store.select(selectIsAssetsLoading);

    this.trades$ = this.store.select(selectTrades);
    this.setups$ = this.store.select(selectSetups);
    this.pairs$ = this.store.select(selectPairs);

    combineLatest([this.pairs$, this.setups$, this.trades$])
      .pipe(
        filter(([pairs, setups, trades]) => !!pairs && !!setups && !!trades),
        tap(([pairs, setups]) => {
          pairs?.forEach((pair) => {
            this.pairsMap[pair.id] = pair.name;
          });

          setups?.forEach((setup) => {
            this.setupsMap[setup.id] = setup.name;
          });
        }),
        map(([pairs, setups, trades]) => {
          console.log(trades);
          return (trades || []).map((trade) => {
            console.log(trade);

            console.log(this.pairsMap);
            console.log(trade.pairID);

            console.log(this.pairsMap[trade.pairID]);
            let res = {
              ...trade,
              pairName: this.pairsMap[trade.pairID] || '',
              setupName: this.setupsMap[trade.setupID] || '',
              directionTypeIcon: this.getDirectionTypeIcon(trade.directionType),
            };
            console.log(res);

            return res;
          });
        })
      )
      .subscribe((trades) => {
        this.dataSource.data = trades ?? [];
      });

    this.pairs$.subscribe((pairs) => {
      const tickerNames = pairs?.map((pair) => pair.name);
      if (tickerNames?.length) {
        this.store.dispatch(tradeActions.getAssetsRates({ tickerNames }));
      }
    });

    this.assetRates$ = this.store.select(selectAssets);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  getResultTypeChipStyle(resultType: ResultType) {
    const backgroundColor = this.getResultTypeColor(resultType);
    const color = resultType === ResultType.Pending ? 'black' : 'white';
    return {
      backgroundColor,
      color,
    };
  }

  getProfitChipStyle(profit: number) {
    const backgroundColor = profit >= 0 ? 'green' : 'red';
    return {
      backgroundColor,
      color: 'white',
    };
  }

  getResultTypeColor(resultType: ResultType): string {
    switch (resultType) {
      case ResultType.Take:
        return 'green';
      case ResultType.Stop:
        return 'red';
      case ResultType.EarlyExit:
        return 'lightblue';
      case ResultType.BreakEven:
        return 'violet';
      case ResultType.Pending:
        return 'yellow';
      default:
        return '';
    }
  }

  getDirectionTypeIcon(directionType: DirectionType): string {
    switch (directionType) {
      case DirectionType.Trend:
        return 'arrow_upward';
      case DirectionType.Countertrend:
        return 'arrow_downward';
      case DirectionType.Range:
        return 'swap_horiz';
      default:
        return '';
    }
  }

  openEditDialog(trade: Trade): void {
    this.dialog.open(AddEditTradeComponent, {
      width: '600px',
      data: trade,
    });
  }

  onAdd(): void {
    this.dialog.open(AddEditTradeComponent, {
      width: '600px',
      data: null,
    });
  }

  openDeleteDialog(trade: Trade): void {
    const dialogRef = this.dialog.open(ConfirmDeleteTradeComponent, {
      width: '300px',
      data: { id: trade.id },
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.store.dispatch(tradeActions.deleteTrade({ tradeId: trade.id }));
      }
    });
  }

  refreshAssetRates(): void {
    this.pairs$.subscribe((pairs) => {
      const tickerNames = pairs?.map((pair) => pair.name);
      if (tickerNames?.length) {
        this.store.dispatch(tradeActions.getAssetsRates({ tickerNames }));
      }
    });
  }
}
