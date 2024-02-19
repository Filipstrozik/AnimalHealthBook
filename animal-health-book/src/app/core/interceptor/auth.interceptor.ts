import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';

export class AuthInterceptor implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // set url
    const url = 'http://localhost:5278';
    req = req.clone({
      url: url + req.url,
    });
    // set headers
    const headers = req.headers.set('Content-Type', 'application/json');
    req = req.clone({
      headers,
    });

    // set token
    const token = localStorage.getItem('token');
    if (token) {
      req = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + token),
      });
    }

    return next.handle(req);
  }
}
