export interface Trade {
  id: string;
  userId: string;
  setupId: string;
  pairId: string;
  date?: Date;
  initialDeposit: number;
  riskAmount: number;
  priceEntry: number;
  priceStop: number;
  priceTake: number;
  profit: number;
  depositRisk: number;
  riskRewardRatio: number;
  positionType: PositionType;
  directionType: DirectionType;
  resultType?: ResultType;
  rating: number;
}

export enum PositionType {
  Long = 'Long',
  Short = 'Short',
  Market = 'Market',
}

export enum DirectionType {
  Trend = 'Trend',
  Countertrend = 'Countertrend',
  Range = 'Range',
}

export enum ResultType {
  Take = 'Take',
  Stop = 'Stop',
  EarlyExit = 'EarlyExit',
  BreakEven = 'BreakEven',
  Pending = 'Pending',
}
