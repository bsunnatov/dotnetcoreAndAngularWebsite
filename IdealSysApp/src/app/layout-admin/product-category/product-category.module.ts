﻿import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridModule } from '@progress/kendo-angular-grid';
import { ProductCategoryRoutingModule } from './product-category-routing.module';
import { ProductCategoryComponent } from './product-category.component';
import { ProductCategoryService } from '../../shared/services/product-category.service';
import { EditFormComponent } from './edit-form.component';
import { PageHeaderModule } from './../../shared/modules';
import { TranslateModule } from '@ngx-translate/core';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
@NgModule({
    imports: [
        CommonModule,
        ProductCategoryRoutingModule,
        PageHeaderModule,
        TranslateModule,
        GridModule,
        DialogModule,
        ReactiveFormsModule,
        DropDownsModule
    ],
    declarations: [ProductCategoryComponent, EditFormComponent],
    providers: [ProductCategoryService]
    })
export class ProductCategoryModule { }