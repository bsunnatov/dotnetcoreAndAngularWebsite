import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Validators, FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms';
import { Product } from './model';
import { GlobalValidator } from '../../shared/utils/validators';
import { ProductCategoryService } from '../../shared/services/product-category.service';
@Component({
    selector: 'kendo-grid-edit-form-product',
    templateUrl: './edit-form.component.html',
    styleUrls: ['./edit-form.component.scss']
})
export class ProductEditFormComponent {
    // The order retrieved from the server
    private categoryItems: Array<any>;
    constructor(private productCategoryService: ProductCategoryService) {
        productCategoryService.getAll({}).subscribe(s => { this.categoryItems = s.data });  
    }
    editForm = new FormGroup({
        'Name': new FormControl("", Validators.required),
        'Description': new FormControl(""),
        'Id': new FormControl(0),
        'ProductCategoryId': new FormControl(1)
    });


    private active: boolean = false;
    @Input() public isNew: boolean = false;

    @Input() public set model(model: Product) {
        this.editForm.reset(model);
        this.active = model !== undefined;

    }

    @Output() cancel: EventEmitter<any> = new EventEmitter();
    @Output() save: EventEmitter<Product> = new EventEmitter();
    public onSave(e): void {
        e.preventDefault();
        var u = <Product>this.editForm.value;
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
