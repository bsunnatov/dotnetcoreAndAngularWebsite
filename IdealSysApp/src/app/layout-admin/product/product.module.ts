import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridModule } from '@progress/kendo-angular-grid';
import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';
import { ProductService } from '../../shared/services/product.service';
import { ProductCategoryService } from '../../shared/services/product-category.service';
import { DynamicPropertyService } from '../../shared/services/dynamicProperty.service';
import { DynamicPropertyValueService } from '../../shared/services/dynamicPropertyValue.service';
import { PageHeaderModule } from './../../shared/modules';
import { TranslateModule } from '@ngx-translate/core';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { ProductEditFormComponent } from './edit-form.component';
import { FileUploadModule } from 'primeng/primeng';
import { DynamicPropertyComponent } from '../dynamic-property/dynamic-property.component';
import { DynamicPropertyValueComponent } from '../dynamic-property-value/dynamic-property-value.component';
import { NavbarComponent } from './navbar.component';

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
        FileUploadModule
        
    ],
    declarations: [ProductComponent, ProductEditFormComponent, DynamicPropertyComponent, NavbarComponent, DynamicPropertyValueComponent],
    providers: [ProductService, ProductCategoryService, DynamicPropertyService, DynamicPropertyValueService]
    })
export class ProductModule { }