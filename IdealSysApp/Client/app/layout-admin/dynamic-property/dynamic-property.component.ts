import { Component, OnInit,Inject, ElementRef, ViewChild,Input,Output,EventEmitter} from '@angular/core';
import { GridDataResult, RowClassArgs, SelectionEvent,RowArgs} from '@progress/kendo-angular-grid';
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
    @Output() private addToProductCategory=new EventEmitter<any>();
    @Input() private selectedPropIds: number[] = [];
    public view: Observable<GridDataResult>; 
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public formGroup: FormGroup;

    private editedRowIndex: number;
    public isRowSelected = (e: RowArgs) => this.selectedPropIds.indexOf(e.dataItem.Id) >= 0;
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
            'Id':new FormControl(0),
            'Key': new FormControl("",Validators.required),
        });

        sender.addRow(this.formGroup);
    }

    protected editHandler({sender, rowIndex, dataItem}) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'Id': new FormControl(dataItem.Id),
            'Key': new FormControl(dataItem.Key, Validators.required),
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
    public onSelectionChange(e:SelectionEvent) {
        if(e.selected)
       console.log(e.selected,e.selectedRows[0].dataItem.Id);
       else
       console.log(e.selected,e.deselectedRows[0].dataItem.Id);
    }
    saveSelectedProps(){
        this.addToProductCategory.emit(this.selectedPropIds);
    }
}
