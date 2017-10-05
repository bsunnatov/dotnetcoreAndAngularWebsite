import { Injectable,Output } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { BaseService } from "./base.service";
import { ConfigService } from '../utils/config.service';
@Injectable()
export class RoleService extends BaseService  {

    baseUrl: string = '';
    constructor(private http: Http, private configService: ConfigService) {
        super();
        this.baseUrl = configService.getApiURI();
    }

    list() {
        return this.http
            .get(this.baseUrl + '/Role'
            )
            .map(res => res.json())
           .catch(this.handleError);
     
    }

  
  
}
