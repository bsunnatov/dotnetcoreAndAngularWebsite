import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppuserRoutingModule } from './appuser-routing.module';
import { AppuserComponent } from './appuser.component';
import { PageHeaderModule } from './../../shared/modules';

@NgModule({
    imports: [
        CommonModule,
        AppuserRoutingModule,
        PageHeaderModule
    ],
    declarations: [AppuserComponent]
})
export class AppuserModule { }