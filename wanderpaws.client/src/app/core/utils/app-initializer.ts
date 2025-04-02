import { Observable } from 'rxjs';
import { AuthService } from '../../features/auth/services/auth.service';

export function appInitializer(
    authService: AuthService
): () => Observable<any> {
    return () => authService.refreshToken();
}