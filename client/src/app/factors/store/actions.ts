import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { Factor } from '../types/factor.interface';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';

export const factorActions = createActionGroup({
  source: 'factors',
  events: {
    GetAllFactors: emptyProps(),
    'GetAllFactors Success': props<{ response: Factor[] }>(),
    'GetAllFactors Failure': props<{ errors: ErrorResponse }>(),

    GetFactorById: props<{ factorId: string }>(),
    'GetFactorById Success': props<{ response: Factor }>(),
    'GetFactorById Failure': props<{ errors: ErrorResponse }>(),

    DeleteFactor: props<{ factorId: string }>(),
    'DeleteFactor Success': props<{ response: Factor }>(),
    'DeleteFactor Failure': props<{ errors: ErrorResponse }>(),

    CreateFactor: props<{ factor: Factor }>(),
    'CreateFactor Success': props<{ response: Factor }>(),
    'CreateFactor Failure': props<{ errors: ErrorResponse }>(),

    UpdateFactor: props<{ factor: Factor }>(),
    'UpdateFactor Success': props<{ response: Factor }>(),
    'UpdateFactor Failure': props<{ errors: ErrorResponse }>(),
  },
});
