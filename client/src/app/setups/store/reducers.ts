import { createFeature, createReducer, on } from '@ngrx/store';
import { setupActions } from './actions';
import { SetupStateInterface } from '../types/setup-state.interface';

const initialState: SetupStateInterface = {
  isSetupsLoading: false,
  errors: null,
  setups: null,
  setup: null,
};

export const setupFeature = createFeature({
  name: 'setups',
  reducer: createReducer(
    initialState,
    on(setupActions.getAllSetups, (state) => ({
      ...state,
      isSetupsLoading: true,
      errors: null,
    })),
    on(setupActions.getAllSetupsSuccess, (state, action) => ({
      ...state,
      isSetupsLoading: false,
      errors: null,
      setups: action.response,
    })),
    on(setupActions.getAllSetupsFailure, (state, action) => ({
      ...state,
      isSetupsLoading: false,
      errors: action.errors,
    })),

    on(setupActions.getSetupById, (state) => ({
      ...state,
      isSetupsLoading: true,
      errors: null,
    })),
    on(setupActions.getSetupByIdSuccess, (state, action) => ({
      ...state,
      isSetupsLoading: false,
      errors: null,
      setup: action.response,
    })),
    on(setupActions.getSetupByIdFailure, (state, action) => ({
      ...state,
      isSetupsLoading: false,
      errors: action.errors,
    })),

    on(setupActions.deleteSetup, (state) => ({
      ...state,
      isSetupsLoading: true,
      errors: null,
    })),
    on(setupActions.deleteSetupSuccess, (state, action) => ({
      ...state,
      isSetupsLoading: false,
      errors: null,
      setup: action.response,
    })),
    on(setupActions.deleteSetupFailure, (state, action) => ({
      ...state,
      isSetupsLoading: false,
      errors: action.errors,
    })),

    on(setupActions.createSetup, (state) => ({
      ...state,
      isSetupsLoading: true,
      errors: null,
    })),
    on(setupActions.createSetupSuccess, (state, action) => ({
      ...state,
      isSetupsLoading: false,
      errors: null,
      setup: action.response,
    })),
    on(setupActions.createSetupFailure, (state, action) => ({
      ...state,
      isSetupsLoading: false,
      errors: action.errors,
    })),

    on(setupActions.updateSetup, (state) => ({
      ...state,
      isSetupsLoading: true,
      errors: null,
    })),
    on(setupActions.updateSetupSuccess, (state, action) => ({
      ...state,
      isSetupsLoading: false,
      errors: null,
      setup: action.response,
    })),
    on(setupActions.updateSetupFailure, (state, action) => ({
      ...state,
      isSetupsLoading: false,
      errors: action.errors,
    }))
  ),
});

export const {
  name: setupFeatureKey,
  reducer: setupReducer,
  selectSetups,
  selectIsSetupsLoading,
  selectErrors,
  selectSetup,
} = setupFeature;
