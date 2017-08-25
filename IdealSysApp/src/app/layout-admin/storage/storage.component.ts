import { Component, OnInit } from '@angular/core';
import { GridDataResult,RowClassArgs } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Rx';
import { fadeAnimate, slideToBottom } from '../../router.animations';
import { Storage } from './model';
import { StorageService } from '../../shared/services/storage.service';

@Component({
  selector: 'app-storage',
  templateUrl: './storage.component.html',
  styleUrls: ['./storage.component.scss'],
  animations: [fadeAnimate()]
})
export class StorageComponent implements OnInit {
    private isNew: boolean;
    private gridData: Observable<GridDataResult>;
    private _sender: any;
    private _rowIndex: number;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 8,
       
    };
    constructor(private service: StorageService) {
        this.gridData = service.getAll(this.gridState);
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
  private editDataItem: Storage;
  public addHandler() {
      this.editDataItem = new Storage();
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

  public saveHandler(model: Storage) {
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
}
