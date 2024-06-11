export interface CreateTradeRequest {
  userId: string;
  setupId: string;
  pairId: string;
  date: Date;
  initialDeposit: number;
  priceEntry: number;
  priceStop: number;
  priceTake: number;
  depositRisk: number;
  positionType: string;
  directionType: string;
  rating: number;
}
