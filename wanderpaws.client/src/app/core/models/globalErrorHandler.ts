// @Injectable()
// export class GlobalErrorHandler implements ErrorHandler {

//     // Error handling is important and needs to be loaded first.
//     // Because of this we should manually inject the services with Injector.
//     constructor(private injector: Injector) { }

//     handleError(error: Error | HttpErrorResponse) {
//         const errorService = this.injector.get(ErrorService);
//         const notifier = this.injector.get(NotificationService);

//         let message;
//         let stackTrace;

//         if (error instanceof HttpErrorResponse) {
//             // Server Error (e.g., validation errors)
//       if (error.status === 422) {
//         message = `Validation Error: ${error.error.message || 'Invalid data provided.'}`;
//         stackTrace = errorService.getServerStack(error);
//         notifier.showError(message);
//       } else {
//         message = errorService.getServerMessage(error);
//         stackTrace = errorService.getServerStack(error);
//         notifier.showError(message);
//       }
//         } else {
//             // Client Error
//             console.error("Handling client error");
//             message = errorService.getClientMessage(error);
//             stackTrace = errorService.getClientStack(error);
//             notifier.showError(message);
//         }

//         // Always log errors
//         //logger.logError(message, stackTrace);
//         console.error("PointCheck");
//         console.error(error);
//     }
// }
import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../services/notification.service';
import { ErrorService } from '../services/error.service';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
    constructor(private injector: Injector) { }

    handleError(error: Error | HttpErrorResponse) {
        const errorService = this.injector.get(ErrorService);
        const notifier = this.injector.get(NotificationService);

        let message = '';

        if (error instanceof HttpErrorResponse) {
            // Server-side error
            message = errorService.getServerMessage(error);
        } else {
            // Client-side error
            message = errorService.getClientMessage(error);
        }

        // Show the toast notification with the error message
        notifier.showError(message);

        // Optionally log the error for debugging purposes
        //console.error('For debugging purposes' + error);
    }
}
