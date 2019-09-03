import { ErrorHandler, Injectable } from '@angular/core';
import { AppConfig } from '../configs/app.config';

@Injectable()
export class CustomErrorHandler implements ErrorHandler {

  handleError(error) {
    throw error;
  }
}
