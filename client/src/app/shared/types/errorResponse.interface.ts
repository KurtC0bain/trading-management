export interface ErrorResponse {
  message: string;
  status: number;
  details?: string;
  errors?: string[];
}
