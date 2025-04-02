// export class ErrorService {
//   // Subjects to hold error data
//   private validationErrorsSubject = new Subject<{ [key: string]: string[] }>();
//   validationErrors$ = this.validationErrorsSubject.asObservable();

//   private genericErrorSubject = new Subject<string>();
//   genericError$ = this.genericErrorSubject.asObservable();

//   // Handle validation errors and send them to the component
//   handleValidationErrors(errors: { [key: string]: string[] }): void {
//     console.log("ErrorService handles ValidationErrors", errors);
//     this.validationErrorsSubject.next(errors);
//   }

//   // Handle generic errors (e.g., 500, 404) and send them to the component
//   handleGenericError(error: any): void {
//     const errorMessage = error.message || 'An unknown error occurred.';
//     console.log("ErrorService handles GenericError", errorMessage);
//     this.genericErrorSubject.next(errorMessage);
//   }


import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  getClientMessage(error: Error): string {
    console.log(1) // invalid username or password enters here
    console.log(error);
    if (!navigator.onLine) {
      return 'No Internet Connection';
    }
    return error.message ? error.message : error.toString();
  }

  getClientStack(error: Error): string {
    console.log(2)
    return error.stack || 'No stack trace available';
  }

  getServerMessage(error: HttpErrorResponse): string {
    console.log(3)
    switch (error.status) {
      case 400:
        return 'Bad Request. Please check the request and try again.';
      case 401:
        return 'Unauthorized. Please log in to continue.';
      case 500:
        return 'Internal Server Error. Please try again later.';
      case 422:
        return `Validation failed: ${error.error.message || 'Unknown validation error'}`;
      default:
        return error.message || 'An unexpected error occurred.';
    }
  }

  getServerStack(error: HttpErrorResponse): string {
    // handle stack trace
    return 'stack';
  }
}
