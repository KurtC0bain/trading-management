import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { AssetsIncome, SetupsEfficiency } from '../types/analysis.interface';

export const analysisActions = createActionGroup({
  source: 'analysis',
  events: {
    GetAssetsIncome: emptyProps(),
    'GetAssetsIncome Success': props<{ response: AssetsIncome[] }>(),
    'GetAssetsIncome Failure': props<{ errors: ErrorResponse }>(),

    GetSetupsEfficiency: emptyProps(),
    'GetSetupsEfficiency Success': props<{ response: SetupsEfficiency[] }>(),
    'GetSetupsEfficiency Failure': props<{ errors: ErrorResponse }>(),
  },
});
