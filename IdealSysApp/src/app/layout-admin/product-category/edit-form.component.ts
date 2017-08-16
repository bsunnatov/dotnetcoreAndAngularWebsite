import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Validators, FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms';
import { ProductCategory } from './productCategory';
import { GlobalValidator } from '../../shared/utils/validators';
import { RoleService } from '../../shared/services/role.service';
@Component({
    selector: 'kendo-grid-edit-form',
    templateUrl: './edit-form.component.html',
    styleUrls: ['./edit-form.component.scss']
})
export class EditFormComponent {
    // The order retrieved from the server
  
    constructor() {
    }
    editForm = new FormGroup({
        'Name': new FormControl("", Validators.required),
        'Id': new FormControl(0),
    });


    private active: boolean = false;
    @Input() public isNew: boolean = false;

    @Input() public set model(model: ProductCategory) {
        this.editForm.reset(model);
        this.active = model !== undefined;

    }

    @Output() cancel: EventEmitter<any> = new EventEmitter();
    @Output() save: EventEmitter<ProductCategory> = new EventEmitter();
    public onSave(e): void {
        e.preventDefault();
        var u = <ProductCategory>this.editForm.value;
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
