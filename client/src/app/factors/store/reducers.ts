import { createFeature, createReducer, on } from '@ngrx/store';
import { FactorStateInterface } from '../types/factor-state.inteface';
import { factorActions } from './actions';

const initialState: FactorStateInterface = {
  isFactorsLoading: false,
  errors: null,
  factors: null,
  factor: null,
};

export const factorFeature = createFeature({
  name: 'factors',
  reducer: createReducer(
    initialState,
    on(factorActions.getAllFactors, (state) => ({
      ...state,
      isFactorsLoading: true,
      errors: null,
    })),
    on(factorActions.getAllFactorsSuccess, (state, action) => ({
      ...state,
      isFactorsLoading: false,
      errors: null,
      factors: action.response,
    })),
    on(factorActions.getAllFactorsFailure, (state, action) => ({
      ...state,
      isFactorsLoading: false,
      errors: action.errors,
    })),

    on(factorActions.getFactorById, (state) => ({
      ...state,
      isFactorsLoading: true,
      errors: null,
    })),
    on(factorActions.getFactorByIdSuccess, (state, action) => ({
      ...state,
      isFactorsLoading: false,
      errors: null,
      factor: action.response,
    })),
    on(factorActions.getFactorByIdFailure, (state, action) => ({
      ...state,
      isFactorsLoading: false,
      errors: action.errors,
    })),

    on(factorActions.deleteFactor, (state) => ({
      ...state,
      isFactorsLoading: true,
      errors: null,
    })),
    on(factorActions.deleteFactorSuccess, (state, action) => ({
      ...state,
      isFactorsLoading: false,
      errors: null,
      factor: action.response,
    })),
    on(factorActions.deleteFactorFailure, (state, action) => ({
      ...state,
      isFactorsLoading: false,
      errors: action.errors,
    })),

    on(factorActions.createFactor, (state) => ({
      ...state,
      isFactorsLoading: true,
      errors: null,
    })),
    on(factorActions.createFactorSuccess, (state, action) => ({
      ...state,
      isFactorsLoading: false,
      errors: null,
      factor: action.response,
    })),
    on(factorActions.createFactorFailure, (state, action) => ({
      ...state,
      isFactorsLoading: false,
      errors: action.errors,
    })),

    on(factorActions.updateFactor, (state) => ({
      ...state,
      isFactorsLoading: true,
      errors: null,
    })),
    on(factorActions.updateFactorSuccess, (state, action) => ({
      ...state,
      isFactorsLoading: false,
      errors: null,
      factor: action.response,
    })),
    on(factorActions.updateFactorFailure, (state, action) => ({
      ...state,
      isFactorsLoading: false,
      errors: action.errors,
    }))
  ),
});

export const {
  name: factorFeatureKey,
  reducer: factorReducer,
  selectFactors,
  selectIsFactorsLoading,
  selectErrors,
  selectFactor,
} = factorFeature;
