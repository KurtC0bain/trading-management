import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { Trade } from './trade.interface';

export interface TradesStateInterface {
  trades: Trade[] | null;
  trade: Trade | null;
  isLoading: boolean;
  errors: ErrorResponse | null;
}
