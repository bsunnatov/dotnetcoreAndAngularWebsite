import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridRoutingModule } from './grid-routing.module';
import { GridComponent } from './grid.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { PageHeaderModule } from './../../shared/modules';
@NgModule({
  imports: [
      CommonModule,
      PageHeaderModule,
      GridRoutingModule,
      GridModule
  ],
  declarations: [GridComponent]
})
export class GridsModule { }
