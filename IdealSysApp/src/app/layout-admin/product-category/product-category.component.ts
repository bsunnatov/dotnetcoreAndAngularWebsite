import { Component, OnInit } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';
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
    private gridData: any[]=[];
    public view: Observable<GridDataResult>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    constructor(private service: ProductCategoryService) { }

  ngOnInit() {
  }
  private editDataItem: ProductCategory;
  public addHandler() {
      this.editDataItem = new ProductCategory();
      this.isNew = true;
  }

  public editHandler({dataItem}) {
      this.editDataItem = dataItem;
      this.isNew = false;
  }

  public cancelHandler() {
      this.editDataItem = undefined;
  }

  public saveHandler(model: ProductCategory) {
      if (this.isNew)
          this.service.add(model).subscribe();
      else
          this.service.update(model);
      this.editDataItem = undefined;
  }

  public removeHandler({dataItem}) {
      this.service.delete(dataItem.Id)
  }
}
