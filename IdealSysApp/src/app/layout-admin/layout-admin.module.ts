import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutAdminRoutingModule } from './layout-admin-routing.module';
import { LayoutAdminComponent } from './layout-admin.component';

@NgModule({
  imports: [
      CommonModule,
      LayoutAdminRoutingModule
    ],
    declarations: [LayoutAdminComponent]
})
export class LayoutAdminModule { }
