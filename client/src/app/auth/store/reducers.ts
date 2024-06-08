import { createFeature, createReducer, on } from '@ngrx/store';
import { AuthStateInterface } from '../types/authState.interface';
import { authActions } from './actions';

const initialState: AuthStateInterface = {
  isSubmitting: false,
  isLoading: false,
  validationErrors: null,
  isAuthorized: false,
};

export const authFeature = createFeature({
  name: 'auth',
  reducer: createReducer(
    initialState,
    on(authActions.register, (state) => ({
      ...state,
      isSubmitting: true,
      validationErrors: null,
    })),
    on(authActions.registerSuccess, (state, action) => ({
      ...state,
      isSubmitting: false,
      validationErrors: null,
    })),
    on(authActions.registerFailure, (state, action) => ({
      ...state,
      isSubmitting: false,
      validationErrors: action.errors,
    })),

    on(authActions.login, (state) => ({
      ...state,
      isSubmitting: false,
      validationErrors: null,
      isAuthorized: false,
    })),
    on(authActions.loginSuccess, (state, action) => ({
      ...state,
      isSubmitting: false,
      validationErrors: null,
      isAuthorized: true,
    })),
    on(authActions.loginFailure, (state, action) => ({
      ...state,
      isSubmitting: false,
      validationErrors: action.errors,
    })),

    on(authActions.logout, (state) => ({
      ...state,
      isSubmitting: false,
      validationErrors: null,
    })),
    on(authActions.logoutSuccess, (state) => ({
      ...state,
      isSubmitting: false,
      validationErrors: null,
      isAuthorized: false,
    })),
    on(authActions.logoutFailure, (state, action) => ({
      ...state,
      isSubmitting: false,
      validationErrors: action.errors,
    })),
    on(authActions.checkAuthSuccess, (state) => ({
      ...state,
      isAuthorized: true,
    })),
    on(authActions.checkAuthFailure, (state) => ({
      ...state,
      isAuthorized: false,
    }))
  ),
});

export const {
  name: authFeatureKey,
  reducer: authReducer,
  selectIsSubmitting,
  selectIsLoading,
  selectValidationErrors,
  selectIsAuthorized,
} = authFeature;
