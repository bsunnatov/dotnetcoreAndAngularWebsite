import { Component, OnInit, Inject, ElementRef, ViewChild, Input} from '@angular/core';
import { GridDataResult, RowClassArgs } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Rx';
import { State, process } from '@progress/kendo-data-query';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DynamicPropertyValueService } from '../../shared/services/dynamicPropertyValue.service';
import { DynamicPropertyValueViewModel } from '../../shared/models/entityViewModels';
import { AddEvent, EditEvent, GridComponent } from '@progress/kendo-angular-grid';
const formGroup = dataItem => new FormGroup({
    'Id': new FormControl(dataItem.Id),
    'Key': new FormControl(dataItem.Key, Validators.required),
    'Value': new FormControl(dataItem.Value),
});
@Component({
  selector: 'dynamic-property-value',
  templateUrl: './dynamic-property-value.component.html',
  styleUrls: ['./dynamic-property-value.component.scss']
})
export class DynamicPropertyValueComponent implements OnInit {
    public view: Observable<GridDataResult>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 4
    };
    public formGroup: FormGroup;

    private editedRowIndex: number;
    @Input() public dynamicProperty: any;
    constructor(private editService: DynamicPropertyValueService) {
      
    }

    public ngOnInit(): void {
        this.view = this.editService.queryForDynamicProperty(this.dynamicProperty,this.gridState);

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
        const product: DynamicPropertyValueViewModel = formGroup.value;
        product.DynamicPropertyId = this.dynamicProperty.Id;
        isNew ? this.editService.add(product).subscribe(s => { this.load() }) : this.editService.update(product).subscribe(s => { this.load() });

        sender.closeRow(rowIndex);
    }
    private load() {
        this.view = this.editService.queryForDynamicProperty(this.dynamicProperty, this.gridState);
    }
    protected removeHandler({dataItem}) {
        if (confirm("Удалить?"))
        this.editService.delete(dataItem.Id).subscribe(s => { this.load() });;
    }
}
