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
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Observable, combineLatest } from 'rxjs';
import { DirectionType, ResultType, Trade } from '../../types/trade.interface';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import {
  selectErrors,
  selectIsLoading,
  selectTrades,
} from '../../store/reducers';

import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { tradeActions } from '../../store/actions';
import { EditTradeComponent } from '../edit-trade/edit-trade.component';
import { ConfirmDeleteTradeComponent } from '../confirm-delete-trade/confirm-delete-trade.component';

@Component({
  selector: 'tm-trades',
  templateUrl: './trades.component.html',
  standalone: true,
  imports: [
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
  ],
  styleUrl: './trades.component.css',
})
export class TradesComponent {
  trades$!: Observable<Trade[] | null>;

  data$ = combineLatest({
    isLoading: this.store.select(selectIsLoading),
    errors: this.store.select(selectErrors),
  });

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

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private store: Store,
    private fb: FormBuilder,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.store.dispatch(tradeActions.getAllTrades());
    this.trades$ = this.store.select(selectTrades);
    this.trades$.subscribe((trades) => {
      if (trades) {
        this.dataSource.data = trades;
      }
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
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
    this.dialog.open(EditTradeComponent, {
      width: '600px',
      data: trade,
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
}