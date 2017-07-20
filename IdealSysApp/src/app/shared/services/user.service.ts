import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { BaseService } from "./base.service";
import { UserRegistration } from '../models/user-registration';
import { AppUser } from '../models/appuser'
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';
import '../../rxjs-operators';

@Injectable()
export class UserService extends BaseService {

    baseUrl: string = '';
    gridSource: Observable<AppUser>;
    // Observable navItem source
    private _authNavStatusSource = new BehaviorSubject<boolean>(false);
    // Observable navItem stream
    authNavStatus$ = this._authNavStatusSource.asObservable();

    private loggedIn = false;

    constructor(private http: Http, private configService: ConfigService) {
        super();
        let authToken = localStorage.getItem('auth_token');
        this.loggedIn = !!authToken;
        // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
        // header component resulting in authed user nav links disappearing despite the fact user is still logged in
        this._authNavStatusSource.next(this.loggedIn);
        this.baseUrl = configService.getApiURI();
    }

    private data: any[] = [];

    register(email: string, password: string, firstName: string, lastName: string, location: string): Observable<UserRegistration> {
        let body = JSON.stringify({ email, password, firstName, lastName, location });
       // let headers = new Headers({ 'Content-Type': 'application/json' });
        //let options = new RequestOptions({ headers: headers });

        return this.http.post(this.baseUrl + "/accounts", body)
            .map(res => true)
            .catch(this.handleError);
    }  
    login(userName, password) {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let postData = JSON.stringify({ userName, password });
        return this.http
            .post(
            this.baseUrl + '/auth/login',
            postData, { headers }
            )
            .map(res => res.json())
            .map(res => {
                localStorage.setItem('auth_token', res.auth_token);
                this.loggedIn = true;
                this._authNavStatusSource.next(true);
                return true;
            })
            .catch(this.handleError);
    }

    logout() {
        localStorage.removeItem('auth_token');
        this.loggedIn = false;
        this._authNavStatusSource.next(false);
    }

    isLoggedIn() {
        return this.loggedIn;
    }  
    list() {
        return this.http
            .get(this.baseUrl + '/Accounts/GetUserList'
            )
            .map(res => res.json())
           .catch(this.handleError);
     
    }

}
