import { Injectable, Output } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { BaseService } from "./base.service";
import { ConfigService } from '../utils/config.service';

@Injectable()
export class ProductPropertyService extends BaseService{
    apiUrl: string = '';
    constructor(private http: Http, private configService: ConfigService) {
        super();
        this.apiUrl = configService.getApiURI() + "/ProductProperty";
    }
    GetProductProperties(id) {
        return this.http.get(this.apiUrl + "/GetProperty/" + id).map(res => res.json()).catch(this.handleError);
    }
    SaveChanges(model) {
        return this.http.post(this.apiUrl + "/SaveChanges", JSON.stringify(model));
    }
    getById(id) {
        return this.http.get(this.getbyidurl(id)).map(res => res.json()).catch(this.handleError);
    }
    add(model) {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this.apiUrl, JSON.stringify(model), { headers });
    }
    update(model) {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.put(this.getbyidurl(model.Id), JSON.stringify(model), { headers });
    }
    delete(id) {
        return this.http.delete(this.getbyidurl(id));
    }
    private getbyidurl(id) {
        return this.apiUrl + "/" + id
    }
}
