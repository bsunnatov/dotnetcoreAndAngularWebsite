import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Validators, FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms';
import { Storage } from './model';
import { GlobalValidator } from '../../shared/utils/validators';
@Component({
    selector: 'kendo-grid-edit-form-storage',
    templateUrl: './edit-form.component.html',
    styleUrls: ['./edit-form.component.scss']
})
export class StorageEditFormComponent {
    // The order retrieved from the server
  
    constructor() {
    }
    editForm = new FormGroup({
        'Name': new FormControl("", Validators.required),
        'Description': new FormControl(""),
        'Id': new FormControl(0),
    });


    private active: boolean = false;
    @Input() public isNew: boolean = false;

    @Input() public set model(model: Storage) {
        this.editForm.reset(model);
        this.active = model !== undefined;

    }

    @Output() cancel: EventEmitter<any> = new EventEmitter();
    @Output() save: EventEmitter<Storage> = new EventEmitter();
    public onSave(e): void {
        e.preventDefault();
        var u = <Storage>this.editForm.value;
        this.save.emit(u);
        this.active = false;
    }
    public onCancel(e): void {
        e.preventDefault();
        this.closeForm();
    }

    private closeForm(): void {
        this.active = false;
        this.cancel.emit();
    }
    public onValueChanged(v) {

    }

}
