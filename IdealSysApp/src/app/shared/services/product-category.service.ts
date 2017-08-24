import { Injectable,Output } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { BaseService } from "./base.service";
import { ConfigService } from '../utils/config.service';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class ProductCategoryService extends BaseService  {

    apiUrl: string = '';
    constructor(private http: Http, private configService: ConfigService) {
        super();
        this.apiUrl = configService.getApiURI()+"/ProductCategory";
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
