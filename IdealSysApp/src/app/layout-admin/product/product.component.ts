import { Component, OnInit, ViewChild} from '@angular/core';
import { GridDataResult, RowClassArgs } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Rx';
import { fadeAnimate, slideToBottom } from '../../router.animations';
import { Product } from './model';
import { ProductService } from '../../shared/services/product.service';
import { ConfigService } from '../../shared/utils/config.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
  animations: [fadeAnimate()]
})
export class ProductComponent implements OnInit {
    private isNew: boolean;
    private gridData: Observable<GridDataResult>;
    private _sender: any;
    private _rowIndex: number;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 8,
       
    };
    private baseUrl = ""; 
    constructor(private service: ProductService, private configService: ConfigService) {
        this.gridData = service.getAll(this.gridState);
        this.baseUrl = this.configService.getApiURI();
    }
    rowCallback(context: RowClassArgs) {
        const isEven = context.index % 2 == 0;
        return {
            even: isEven,
            odd: !isEven
        };
    }

    ngOnInit() {
       

    }
  private editDataItem: Product;
  public addHandler() {
      this.editDataItem = new Product();
      this.isNew = true;
  }

  public editHandler({sender, rowIndex, dataItem, isNew}) {
      this.editDataItem = dataItem;
      this._sender = sender;
      this.isNew = false;
      this._rowIndex = rowIndex;
  }

  public cancelHandler() {
      this.editDataItem = undefined;
  }

  public saveHandler(model: Product) {
      if (this.isNew)
          this.service.add(model).subscribe(s => { this.reset(this.gridState) });
      else
          this.service.update(model).subscribe(s => {
              this._sender.data["data"][this._rowIndex - this.gridState.skip] = s.json()
          });
      this.editDataItem = undefined;
     
  }
  private reset(filter) {
      this.gridData= this.service.getAll(filter);
}
  public removeHandler({rowIndex, dataItem}) {
      if (confirm("Удалить?"))
          this.service.delete(dataItem.Id).subscribe(s => {
              this.gridData.subscribe(s => { s.data.splice(rowIndex, 1); });
      });
  }
  public onStateChange(e) {
      this.gridState = e;
      this.reset(e);
  }
  private selectedItem: any;
  public gridProductSelectionChange (gridProduct, selection) {
      this.selectedItem = gridProduct.data.data[selection.index];
  }
  private onBeforeSend(event) {
      event.xhr.setRequestHeader("Authorization", "Bearer " + sessionStorage.getItem("auth_token"));

  }
  private onUpload(res) {
      console.log(res);
  }
}
