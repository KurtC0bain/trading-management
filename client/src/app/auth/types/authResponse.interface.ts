export interface AuthResponseInterface {
  headers: any;
  tokenType: string;
  accessToken: string;
  expiresIn: Number;
  refreshToken: string;
}
