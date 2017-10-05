import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Validators, FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms';
import { GlobalValidator } from '../../../shared/utils/validators';
@Component({
    selector: 'kendo-grid-edit-form',
    templateUrl: './edit-form.component.html',
    styleUrls: ['./edit-form.component.scss']
})
export class KendoEditFormComponent {
  
    constructor() {
    }
    editForm = new FormGroup({
        'Name': new FormControl("", Validators.required),
        'PhoneNumber': new FormControl(""),
        'AddressDetails': new FormControl(""),
        'INN': new FormControl(""),
        'PassportNumber': new FormControl(""),
        'PassportSeria': new FormControl(""),
        'PersonType': new FormControl(""),
        'Id': new FormControl(0),
    });


    private active: boolean = false;
    @Input() public isNew: boolean = false;

    @Input() public set model(model: any) {
        this.editForm.reset(model);
        this.active = model !== undefined;

    }

    @Output() cancel: EventEmitter<any> = new EventEmitter();
    @Output() save: EventEmitter<any> = new EventEmitter();
    public onSave(e): void {
        e.preventDefault();
        var u = <any>this.editForm.value;
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
