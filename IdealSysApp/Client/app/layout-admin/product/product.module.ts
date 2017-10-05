import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridModule } from '@progress/kendo-angular-grid';
import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';
import { ProductService } from '../../shared/services/product.service';
import { MySelect2Component } from '../../shared/components/myselect2/myselect2.component';
import { ProductCategoryService } from '../../shared/services/product-category.service';
import { DynamicPropertyService } from '../../shared/services/dynamicProperty.service';
import { DynamicPropertyValueService } from '../../shared/services/dynamicPropertyValue.service';
import { ProductPropertyService } from '../../shared/services/productproperty.service';
import { PageHeaderModule } from './../../shared/modules';
import { TranslateModule } from '@ngx-translate/core';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { ProductEditFormComponent } from './edit-form.component';
import { FileUploadModule } from 'primeng/primeng';
import { DynamicPropertyModelModule } from '../dynamic-property/dynamic-property-model.module';
//import { DynamicPropertyValueComponent } from '../dynamic-property-value/dynamic-property-value.component';
import { NavbarComponent } from './navbar.component';
import { Select2Module } from 'ng2-select2';


@NgModule({
    imports: [
        CommonModule,
        ProductRoutingModule,
        PageHeaderModule,
        TranslateModule,
        GridModule,
        DialogModule,
        ReactiveFormsModule,
        DropDownsModule,
        FileUploadModule,
        Select2Module,
        DynamicPropertyModelModule,
GridModule
    ],
    declarations: [ProductComponent, ProductEditFormComponent,  NavbarComponent, MySelect2Component],
    providers: [ProductService, ProductCategoryService, DynamicPropertyService, DynamicPropertyValueService, ProductPropertyService]
    })
export class ProductModule { }
