import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridModule } from '@progress/kendo-angular-grid';
import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';
import { ProductService } from '../../shared/services/product.service';
import { ProductCategoryService } from '../../shared/services/product-category.service';
import { DynamicPropertyService } from '../../shared/services/dynamicProperty.service';
import { PageHeaderModule } from './../../shared/modules';
import { TranslateModule } from '@ngx-translate/core';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { ProductEditFormComponent } from './edit-form.component';
import { SelectModule } from 'ng2-select';
import { IqSelect2Module } from 'ng2-iq-select2';
import {  DataService } from '../../shared/services/data.service';
import { FileUploadModule } from 'primeng/primeng';
import { DynamicPropertyComponent } from '../dynamic-property/dynamic-property.component';
import { NavbarComponent } from './navbar.component';
import { RowClickDirective } from '../../shared/directives/row-click';
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
        SelectModule,
        IqSelect2Module,
        FileUploadModule
        
    ],
    declarations: [ProductComponent, ProductEditFormComponent, DynamicPropertyComponent, NavbarComponent, RowClickDirective],
    providers: [ProductService, DataService, ProductCategoryService, DynamicPropertyService]
    })
export class ProductModule { }