import { Injectable,Output } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { BaseService } from "./base.service";
import { ConfigService } from '../utils/config.service';
@Injectable()
export class ProductCategoryService extends BaseService  {

    apiUrl: string = '';
    constructor(private http: Http, private configService: ConfigService) {
        super();
        this.apiUrl = configService.getApiURI()+"/ProductCategory";
    }
    getAll() {
        return this.http.get(this.apiUrl).map(res => res.json()).catch(this.handleError);
    }
    getById(id) {
        return this.http.get(this.getbyidurl(id)).map(res => res.json()).catch(this.handleError);
    }
    add(model) {
        return this.http.post(this.apiUrl, JSON.stringify(model))
            .map(res => res.json()).catch(this.handleError);
    }
    update(model) {
        return this.http.put(this.getbyidurl(model.Id), JSON.stringify(model))
            .map(res => res.json());
    }
    delete(id) {
        return this.http.delete(this.getbyidurl(id))
            .map(res => res.json()).catch(this.handleError);
    }
    private getbyidurl(id) {
        return this.apiUrl + "/" + id
    }
}
