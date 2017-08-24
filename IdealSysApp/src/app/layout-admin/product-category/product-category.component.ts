import { Component, OnInit } from '@angular/core';
import { GridDataResult,RowClassArgs } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Rx';
import { fadeAnimate, slideToBottom } from '../../router.animations';
import { ProductCategory } from './productCategory';
import { ProductCategoryService } from '../../shared/services/product-category.service';

@Component({
  selector: 'app-product-category',
  templateUrl: './product-category.component.html',
  styleUrls: ['./product-category.component.scss'],
  animations: [fadeAnimate()]
})
export class ProductCategoryComponent implements OnInit {
    private isNew: boolean;
    private gridData: Observable<GridDataResult>;
    private _sender: any;
    private _rowIndex: number;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10,
       
    };
    constructor(private service: ProductCategoryService) {
        this.gridData = service.getAll(this.gridState);
       // this.gridData.subscribe();
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
  private editDataItem: ProductCategory;
  public addHandler() {
      this.editDataItem = new ProductCategory();
      this.isNew = true;
  }

  public editHandler({sender, rowIndex, dataItem, isNew}) {
      this.editDataItem = dataItem;
      this._sender = sender;
      this.isNew = false;
    
  }

  public cancelHandler() {
      this.editDataItem = undefined;
  }

  public saveHandler(model: ProductCategory) {
      if (this.isNew)
          this.service.add(model).subscribe(s => { this.reset(this.gridState) });
      else
          this.service.update(model).subscribe(s => { this._sender.editRow(this._rowIndex, model); console.log(this._sender) });
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
}
