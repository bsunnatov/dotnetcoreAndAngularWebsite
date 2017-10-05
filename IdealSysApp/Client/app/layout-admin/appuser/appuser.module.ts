﻿import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridModule } from '@progress/kendo-angular-grid';
import { AppuserRoutingModule } from './appuser-routing.module';
import { AppuserComponent } from './appuser.component';
import { EditFormComponent } from './edit-form.component';
import { PageHeaderModule } from './../../shared/modules';
import { TranslateModule } from '@ngx-translate/core';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { RoleComponent } from '../role/role.component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
@NgModule({
    imports: [
        CommonModule,
        AppuserRoutingModule,
        PageHeaderModule,
        TranslateModule,
        GridModule,
        DialogModule,
        ReactiveFormsModule,
        DropDownsModule
    ],
    declarations: [AppuserComponent, EditFormComponent,RoleComponent]
})
export class AppuserModule { }