import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { AssetRateResponse } from './asset-rate.interface';
import { PairResponse } from './pair.interface';
import { Trade } from './trade.interface';

export interface TradesStateInterface {
  trades: Trade[] | null;
  assets: AssetRateResponse[] | null;
  pairs: PairResponse[] | null;
  trade: Trade | null;
  isLoading: boolean;
  isAssetsLoading: boolean;
  isPairsLoading: boolean;
  errors: ErrorResponse | null;
}
