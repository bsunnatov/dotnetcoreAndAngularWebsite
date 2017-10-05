import { Component, OnInit } from '@angular/core';
import { GridDataResult, RowClassArgs } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Rx';
import { fadeAnimate, slideToBottom } from '../../router.animations';
import { DataService } from '../../core/services/data.service';
import { Customer } from './customer.model';
@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss'],
  animations: [fadeAnimate()]
})
export class CustomerComponent implements OnInit {
  private isNew: boolean;
  private gridData: GridDataResult;
  private _sender: any;
  private _rowIndex: number;
  public gridState: State = {
    sort: [],
    skip: 0,
    take: 8,

  };
  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.refreshGrid();
  }
  refreshGrid() {
    this.dataService.get("/api/customer",{filter:JSON.stringify(this.gridState)}).map(m=>(<GridDataResult>{
      data:m.Data,
      total:m.Total
    
    })).subscribe(
      s => {
        
        this.gridData=s
      },

    );
  }
  private editDataItem: Customer;
  public addHandler() {
    this.editDataItem = new Customer();
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

  public saveHandler(model: Customer) {
    if (this.isNew)
      this.dataService.post("/api/Customer", model).subscribe(s => {
        this.refreshGrid();
      });
    else
      this.dataService.put("/api/Customer", model).subscribe(s => {
        this._sender.data["data"][this._rowIndex - this.gridState.skip] = s
      });
    this.editDataItem = undefined;

  }
  public onStateChange(e) {
    this.gridState = e;
    this.refreshGrid();
}

}
