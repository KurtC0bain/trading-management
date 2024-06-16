import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { AssetsIncome, SetupsEfficiency } from './analysis.interface';

export interface AnalysisState {
  setupEfficiency: SetupsEfficiency[] | null;
  assetsIncome: AssetsIncome[] | null;
  loading: boolean;
  errors: ErrorResponse | null;
}
