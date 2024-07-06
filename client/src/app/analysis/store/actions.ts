import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { AssetsIncome, SetupsEfficiency } from '../types/analysis.interface';
import { AssetsIncomeResponse } from '../types/assetsIncome-response.interface';
import { SetupsEfficiencyResponse } from '../types/setupsEfficiency-response.interface';

export const analysisActions = createActionGroup({
  source: 'analysis',
  events: {
    GetAssetsIncome: emptyProps(),
    'GetAssetsIncome Success': props<{ response: AssetsIncomeResponse }>(),
    'GetAssetsIncome Failure': props<{ errors: ErrorResponse }>(),

    GetSetupsEfficiency: emptyProps(),
    'GetSetupsEfficiency Success': props<{
      response: SetupsEfficiencyResponse;
    }>(),
    'GetSetupsEfficiency Failure': props<{ errors: ErrorResponse }>(),
  },
});
