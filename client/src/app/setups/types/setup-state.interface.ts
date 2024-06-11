import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { Setup } from './setup.interface';

export interface SetupStateInterface {
  setups: Setup[] | null;
  setup: Setup | null;
  isSetupsLoading: boolean;
  errors: ErrorResponse | null;
}
