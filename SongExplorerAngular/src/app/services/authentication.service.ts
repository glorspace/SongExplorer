import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { RegistrationData } from '../models/registration';

@Injectable()
export class AuthenticationService {
    constructor(private http: HttpClient) { }

    register(registrationData: RegistrationData) {
        return this.http.post('http://localhost:65336/api/Account/Register', registrationData);
    }

    login(username: string, password: string) {
        let postBodyPlain = {
            'username': username,
            'password': password,
            'grant_type': 'password'
        };

        let postBodyEncoded = Object.keys(postBodyPlain).map(k => `${encodeURIComponent(k)}=${encodeURIComponent(postBodyPlain[k])}`).join('&');
        
        let httpHeaders = {
            headers: new HttpHeaders({
                'Content-Type': 'application/x-www-form-urlencoded'
            })
        };

        return this.http.post<any>(`http://localhost:65336/token`, postBodyEncoded, httpHeaders )
            .pipe(map(jwt => {
                // login successful if there's a jwt token in the response
                if (jwt) {// && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(jwt));
                }

                return jwt;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');

        // log user out from server
        return this.http.post('http://localhost:65336/api/account/Logout', {})
        .pipe(map(data => {

        }));
    }
}