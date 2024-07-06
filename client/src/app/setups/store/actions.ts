import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { Setup } from '../types/setup.interface';

export const setupActions = createActionGroup({
  source: 'setups',
  events: {
    GetAllSetups: emptyProps(),
    'GetAllSetups Success': props<{ response: Setup[] }>(),
    'GetAllSetups Failure': props<{ errors: ErrorResponse }>(),

    GetSetupById: props<{ setupId: string }>(),
    'GetSetupById Success': props<{ response: Setup }>(),
    'GetSetupById Failure': props<{ errors: ErrorResponse }>(),

    DeleteSetup: props<{ setupId: string }>(),
    'DeleteSetup Success': props<{ response: Setup }>(),
    'DeleteSetup Failure': props<{ errors: ErrorResponse }>(),

    CreateSetup: props<{ setup: Setup }>(),
    'CreateSetup Success': props<{ response: Setup }>(),
    'CreateSetup Failure': props<{ errors: ErrorResponse }>(),

    UpdateSetup: props<{ setup: Setup }>(),
    'UpdateSetup Success': props<{ response: Setup }>(),
    'UpdateSetup Failure': props<{ errors: ErrorResponse }>(),
  },
});
