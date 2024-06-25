import { HttpEvent, HttpHandlerFn, HttpInterceptorFn, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";

export const authInterceptor: HttpInterceptorFn = (
    req: HttpRequest<any>,
    next: HttpHandlerFn
): Observable<HttpEvent<any>> => {

   
    if (typeof localStorage !== 'undefined') {
    const tokenString = localStorage.getItem('ACCESS_TOKEN');
    if (tokenString !==null) {
        const token = JSON.parse(tokenString).token;
        console.log('🤦‍♀️',token);
        const cloned = req.clone({
            setHeaders: {
                authorization: `Bearer ${token}`,
            },
        });
        
        return next(cloned);
    } else {
        console.log('😢');
        return next(req);
    }
}
else return next(req);
};