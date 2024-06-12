export interface CreateTradeRequest {
  userID: string;
  setupID: string;
  pairID: string;
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
