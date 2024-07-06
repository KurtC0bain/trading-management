import { RegisterErrorsInterface } from './registerError.interface';

export interface AuthStateInterface {
  isSubmitting: boolean;
  isLoading: boolean;
  validationErrors: RegisterErrorsInterface | null;
  isAuthorized: boolean;
}
