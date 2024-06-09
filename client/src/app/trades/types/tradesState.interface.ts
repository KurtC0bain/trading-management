import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { AssetRateResponse } from './asset-rate.interface';
import { Trade } from './trade.interface';

export interface TradesStateInterface {
  trades: Trade[] | null;
  assets: AssetRateResponse[] | null;
  trade: Trade | null;
  isLoading: boolean;
  errors: ErrorResponse | null;
}
