import { Component, OnInit,Inject, ElementRef, ViewChild} from '@angular/core';
import { GridDataResult, RowClassArgs } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Rx';
import { State, process } from '@progress/kendo-data-query';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DynamicPropertyService } from '../../shared/services/dynamicProperty.service';
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
    private gridState: State = {
        sort: [],
        skip: 0,
        take: 8,

    };
    public view: any[];
    public formGroup: FormGroup;
    private editedRowIndex: number;

    public get isInEditingMode(): boolean {
        return this.editedRowIndex !== undefined || this.isNew;
    }

    private isNew: boolean = false;

    @ViewChild(GridComponent) private grid: GridComponent;


    constructor(private service: DynamicPropertyService) { }

    ngOnInit() {
        this.view = [{Key:"asas",Value:"asas",Id:1}];
            //= this.service.getAll(this.gridState);
    }
    public addHandler({ sender, dataItem }: AddEvent): void {
        this.closeEditor(sender);

        this.formGroup = formGroup({
            Key: "",
            Value: ""
        });

        this.isNew = true;
        sender.addRow(this.formGroup);
        this.saveRow();
    }

    public editHandler({ sender, rowIndex, dataItem, isNew }: EditEvent): void {
        if (this.formGroup && !this.formGroup.valid ) {
            return;
        }
        this.saveRow();

        this.formGroup = formGroup(dataItem);

        this.editedRowIndex = rowIndex;

        sender.editRow(rowIndex, this.formGroup);
    }

    public cancelHandler(): void {
        this.closeEditor(this.grid, this.editedRowIndex);
    }

    public editClick(rowIndex: number): void {
        this.editHandler({
            sender: this.grid,
            rowIndex: rowIndex,
            dataItem: this.view[rowIndex],
            isNew: this.isNew
        });
    }

    public saveClick(rowIndex: number): void {
        if (this.formGroup && !this.formGroup.valid) {
            return;
        }

        this.saveRow();
    }

    private closeEditor(grid: GridComponent, rowIndex: number = this.editedRowIndex): void {
        this.isNew = false;
        grid.closeRow(rowIndex);
        this.editedRowIndex = undefined;
        this.formGroup = undefined;
    }

    private saveRow(): void {
   
        if (this.isInEditingMode) {
            this.isNew ? this.service.add(this.formGroup.value) : this.service.update(this.formGroup.value);
        }

        this.closeEditor(this.grid);
    }
    public onStateChange(e) {
        this.gridState = e;
    }
}
