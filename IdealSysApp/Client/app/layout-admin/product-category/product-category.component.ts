import { Component, OnInit, Input, ViewChild, TemplateRef } from '@angular/core';
import { GridDataResult, RowClassArgs } from '@progress/kendo-angular-grid';
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
        ParentId: 0

    };
    private selectedDataItem: ProductCategory;
    private itemPropsIds: number[] = [];
    @ViewChild('content') template1: TemplateRef<null>;
    @Input() public parentItem: ProductCategory = new ProductCategory();
    constructor(
        private service: ProductCategoryService,
        private modalService: NgbModal
    ) { }
    open(content) {
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
    ngOnInit() {
        this.gridRefresh();
    }
    private editDataItem: ProductCategory;
    public addHandler() {
        this.editDataItem = new ProductCategory();
        this.isNew = true;
    }

    public editHandler({ sender, rowIndex, dataItem, isNew }) {
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
            this.service.add(model).subscribe(s => { this.gridRefresh() });
        }
        else
            this.service.update(model).subscribe(s => {
                this._sender.data["data"][this._rowIndex - this.gridState.skip] = s.json()
            });
        this.editDataItem = undefined;

    }
    private gridRefresh() {
        this.gridState.ParentId = this.parentItem.Id;
        this.gridData = this.service.queryForChild(this.parentItem, this.gridState);
    }
    public removeHandler({ rowIndex, dataItem }) {
        if (confirm("Удалить?"))
            this.service.delete(dataItem.Id).subscribe(s => {
                this.gridData.subscribe(s => { s.data.splice(rowIndex, 1); });
            });
    }
    public onStateChange(e) {
        Object.assign(this.gridState, e);
        this.gridRefresh();
    }
    openPropsModal(dataItem: ProductCategory) {
        this.selectedDataItem = dataItem;
        this.itemPropsIds = dataItem.PropertyInProductCategories.map(s => { return s.DynamicPropertyId });
        this.open(this.template1);
    }
    onAddToProductCategory(propertyIds) {
       this.service.setProps(this.selectedDataItem.Id,propertyIds).subscribe(s=>{
        this.gridRefresh();
       });
    }
}
