import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridModule } from '@progress/kendo-angular-grid';
import { StorageRoutingModule } from './storage-routing.module';
import { StorageComponent } from './storage.component';
import { StorageService } from '../../shared/services/storage.service';
import { StorageEditFormComponent } from './edit-form.component';
import { PageHeaderModule } from './../../shared/modules';
import { TranslateModule } from '@ngx-translate/core';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
@NgModule({
    imports: [
        CommonModule,
        StorageRoutingModule,
        PageHeaderModule,
        TranslateModule,
        GridModule,
        DialogModule,
        ReactiveFormsModule,
        DropDownsModule
    ],
    declarations: [StorageComponent, StorageEditFormComponent],
    providers: [StorageService]
    })
export class StorageModule { }