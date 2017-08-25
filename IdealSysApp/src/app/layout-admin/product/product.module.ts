import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridModule } from '@progress/kendo-angular-grid';
import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';
import { ProductService } from '../../shared/services/product.service';
import { PageHeaderModule } from './../../shared/modules';
import { TranslateModule } from '@ngx-translate/core';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { ProductEditFormComponent } from './edit-form.component';
import { SelectModule } from 'ng2-select';
import { IqSelect2Module } from 'ng2-iq-select2';
import {  DataService } from '../../shared/services/data.service';
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
        IqSelect2Module
        
    ],
    declarations: [ProductComponent, ProductEditFormComponent],
    providers: [ProductService, DataService]
    })
export class ProductModule { }