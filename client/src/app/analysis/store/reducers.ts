import { createFeature, createReducer, on } from '@ngrx/store';
import { analysisActions } from './actions';
import { AnalysisState } from '../types/analysis.state';

const initialState: AnalysisState = {
  setupEfficiency: null,
  assetsIncome: null,
  loading: false,
  errors: null,
};

export const analysisFeature = createFeature({
  name: 'analysis',
  reducer: createReducer(
    initialState,
    on(analysisActions.getAssetsIncome, (state) => ({
      ...state,
      loading: true,
      errors: null,
    })),
    on(analysisActions.getAssetsIncomeSuccess, (state, action) => ({
      ...state,
      loading: false,
      errors: null,
      assetsIncome: action.response,
    })),
    on(analysisActions.getAssetsIncomeFailure, (state, action) => ({
      ...state,
      loading: false,
      errors: action.errors,
    })),

    on(analysisActions.getSetupsEfficiency, (state) => ({
      ...state,
      loading: true,
      errors: null,
    })),
    on(analysisActions.getSetupsEfficiencySuccess, (state, action) => ({
      ...state,
      loading: false,
      errors: null,
      setupEfficiency: action.response,
    })),
    on(analysisActions.getSetupsEfficiencyFailure, (state, action) => ({
      ...state,
      loading: false,
      errors: action.errors,
    }))
  ),
});

export const {
  name: analysisFeatureKey,
  reducer: analysisReducer,
  selectSetupEfficiency,
  selectAssetsIncome,
  selectErrors,
  selectLoading,
} = analysisFeature;
