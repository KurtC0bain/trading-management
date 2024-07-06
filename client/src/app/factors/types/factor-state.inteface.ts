import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { Factor } from './factor.interface';

export interface FactorStateInterface {
  factors: Factor[] | null;
  factor: Factor | null;
  isFactorsLoading: boolean;
  errors: ErrorResponse | null;
}
