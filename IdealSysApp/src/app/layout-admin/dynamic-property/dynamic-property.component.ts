import { Component, OnInit,Inject, ElementRef, ViewChild,Input} from '@angular/core';
import { GridDataResult, RowClassArgs, SelectionEvent} from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Rx';
import { State, process } from '@progress/kendo-data-query';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DynamicPropertyService } from '../../shared/services/dynamicProperty.service';
import { DynamicPropertyViewModel } from '../../shared/models/entityViewModels';

import { AddEvent, EditEvent, GridComponent } from '@progress/kendo-angular-grid';
const formGroup = dataItem => new FormGroup({
    'Id': new FormControl(dataItem.Id),
    'Key': new FormControl(dataItem.Key, Validators.required),
    'Value': new FormControl(dataItem.Value),
});
@Component({
  selector: 'app-dynamic-property',
  templateUrl: './dynamic-property.component.html',
  styleUrls: ['./dynamic-property.component.scss']
})
export class DynamicPropertyComponent implements OnInit {
    @Input() public AsSelect: boolean = false;
    private mySelection = [1, 3, 5];

    public view: Observable<GridDataResult>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 4
    };
    public formGroup: FormGroup;

    private editedRowIndex: number;

    constructor(private editService: DynamicPropertyService) {
      
    }

    public ngOnInit(): void {
        this.view = this.editService.getAll(this.gridState);

    }

    public onStateChange(state: State) {
        this.gridState = state;
        this.load();
    }

    protected addHandler({sender}) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'Key': new FormControl(),
            'Value': new FormControl("", Validators.required),
           
        });

        sender.addRow(this.formGroup);
    }

    protected editHandler({sender, rowIndex, dataItem}) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'Id': new FormControl(dataItem.Id),
            'Key': new FormControl(dataItem.Key, Validators.required),
            'Value': new FormControl(dataItem.Value),
          
        });

        this.editedRowIndex = rowIndex;

        sender.editRow(rowIndex, this.formGroup);
    }

    protected cancelHandler({sender, rowIndex}) {
        this.closeEditor(sender, rowIndex);
    }

    private closeEditor(grid, rowIndex = this.editedRowIndex) {
        grid.closeRow(rowIndex);
        this.editedRowIndex = undefined;
        this.formGroup = undefined;
    }

    protected saveHandler({sender, rowIndex, formGroup, isNew}) {
        const product: DynamicPropertyViewModel = formGroup.value;
        isNew ? this.editService.add(product).subscribe(s => { this.load() }) : this.editService.update(product).subscribe(s => { this.load() });

        sender.closeRow(rowIndex);
    }
    private load() {
        this.view = this.editService.getAll(this.gridState);
    }
    protected removeHandler({dataItem}) {
        if (confirm("Удалить?"))
        this.editService.delete(dataItem.Id).subscribe(s => { this.load() });
    }
    public onSelectionChange(e: SelectionEvent) {
        console.log(e.selectedRows);
    }
}
