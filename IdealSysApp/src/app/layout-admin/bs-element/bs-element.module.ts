import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BsElementRoutingModule } from './bs-element-routing.module';
import { BsElementComponent } from './bs-element.component';
import { PageHeaderModule } from './../../shared/modules';

@NgModule({
    imports: [
        CommonModule,
        BsElementRoutingModule,
        PageHeaderModule
    ],
    declarations: [BsElementComponent]
})
export class BsElementModule { }