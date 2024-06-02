import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { RegisterRequestInterface } from '../types/registerRequest.interface';
import { RegisterErrorsInterface } from '../types/registerError.interface';
import { AuthResponseInterface } from '../types/authResponse.interface';

export const authActions = createActionGroup({
  source: 'auth',
  events: {
    Register: props<{ request: RegisterRequestInterface }>(),
    'Register Success': emptyProps(),
    'Register Failure': props<{ errors: RegisterErrorsInterface }>(),

    Login: props<{ request: RegisterRequestInterface }>(),
    'Login Success': props<{ response: AuthResponseInterface }>(),
    'Login Failure': props<{ errors: RegisterErrorsInterface }>(),

    Logout: emptyProps(),
    'Logout Success': emptyProps(),
    'Logout Failure': props<{ errors: RegisterErrorsInterface }>(),
  },
});
