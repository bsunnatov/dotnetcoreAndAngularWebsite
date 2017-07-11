import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridRoutingModule } from './grid-routing.module';
import { GridComponent } from './grid.component';

import { PageHeaderModule } from './../../shared/modules';
@NgModule({
  imports: [
      CommonModule,
      PageHeaderModule,
      GridRoutingModule
  ],
  declarations: [GridComponent]
})
export class GridModule { }
