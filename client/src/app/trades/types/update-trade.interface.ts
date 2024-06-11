import { CreateTradeRequest } from './create-trade.interface';

export interface UpdateTradeRequest extends CreateTradeRequest {
  id: string;
  resultType: string;
  profit: number;
}
