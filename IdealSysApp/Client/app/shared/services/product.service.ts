import { Injectable,Output } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { BaseService } from "./base.service";
import { ConfigService } from '../utils/config.service';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class ProductService extends BaseService  {

    apiUrl: string = '';
    constructor(private http: Http, private configService: ConfigService) {
        super();
        this.apiUrl = configService.getApiURI()+"/Product";
    }
    getAll(filter?: any): Observable<GridDataResult> {
        return this.http.get(this.apiUrl + "?filter=" + JSON.stringify(filter)).map(res => res.json())
            .map(response => (<GridDataResult>{
                data: response.Data,
                total: response.Total
            }))
            .catch(this.handleError);
    }

    getById(id) {
        return this.http.get(this.getbyidurl(id)).map(res => res.json()).catch(this.handleError);
    }
    add(model) {
        return this.http.post(this.apiUrl, JSON.stringify(model));
    }
    update(model) {
        return this.http.put(this.getbyidurl(model.Id), JSON.stringify(model));
    }
    delete(id) {
        return this.http.delete(this.getbyidurl(id));
    }
    private getbyidurl(id) {
        return this.apiUrl + "/" + id
    }
}
