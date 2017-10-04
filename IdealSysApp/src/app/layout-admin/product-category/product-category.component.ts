import { Component, OnInit, Input, ViewChild, TemplateRef } from '@angular/core';
import { GridDataResult,RowClassArgs } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Rx';
import { fadeAnimate, slideToBottom } from '../../router.animations';
import { ProductCategory } from './model';
import { ProductCategoryService } from '../../shared/services/product-category.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-product-category',
  templateUrl: './product-category.component.html',
  styleUrls: ['./product-category.component.scss'],
  animations: [fadeAnimate()]
})
export class ProductCategoryComponent implements OnInit {
    closeResult: string;
    private isNew: boolean;
    private gridData: Observable<GridDataResult>;
    private _sender: any;
    private _rowIndex: number;
    public gridState = {
        sort: [],
        skip: 0,
        take: 20,
        ParentId:0
       
    };
    private selectedDataItem: ProductCategory;
    @ViewChild('content') template1: TemplateRef<null>;
    @Input() public parentItem: ProductCategory = new ProductCategory();
    constructor(
        private service: ProductCategoryService,
        private modalService: NgbModal
    ) { }
    open(content) {
        console.log(content);
            this.modalService.open(content).result.then((result) => {
                this.closeResult = `Closed with: ${result}`;
            }, (reason) => {
                this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
            });
        }

    private getDismissReason(reason: any): string {
        if (reason === ModalDismissReasons.ESC) {
            return 'by pressing ESC';
        } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
            return 'by clicking on a backdrop';
        } else {
            return `with: ${reason}`;
        }
    }
    rowCallback(context: RowClassArgs) {
        const isEven = context.index % 2 == 0;
        return {
            even: isEven,
            odd: !isEven
        };
    }

    ngOnInit() {
        this.reset();
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
      this._rowIndex = rowIndex;
  }

  public cancelHandler() {
      this.editDataItem = undefined;
  }

  public saveHandler(model: ProductCategory) {
     
      if (this.isNew) {
          model.ParentId = this.parentItem.Id > 0 ? this.parentItem.Id : null;
          this.service.add(model).subscribe(s => { this.reset() });
      }
      else
          this.service.update(model).subscribe(s => {
              this._sender.data["data"][this._rowIndex - this.gridState.skip] = s.json()
          });
      this.editDataItem = undefined;
     
  }
  private reset() {
      this.gridState.ParentId = this.parentItem.Id;
      this.gridData = this.service.queryForChild(this.parentItem, this.gridState);
}
  public removeHandler({rowIndex, dataItem}) {
      if (confirm("Удалить?"))
          this.service.delete(dataItem.Id).subscribe(s => {
              this.gridData.subscribe(s => { s.data.splice(rowIndex, 1); });
      });
  }
  public onStateChange(e) {
      Object.assign(this.gridState,e);
      this.reset();
  }
  openPropsModal(dataItem) {
      this.selectedDataItem = dataItem;
      this.open(this.template1);
  }
}
