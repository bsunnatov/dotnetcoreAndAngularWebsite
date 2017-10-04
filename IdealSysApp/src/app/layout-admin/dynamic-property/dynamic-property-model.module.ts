import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DynamicPropertyComponent } from './dynamic-property.component';
import { DynamicPropertyValueComponent } from '../dynamic-property-value/dynamic-property-value.component'
import { GridModule } from '@progress/kendo-angular-grid';
@NgModule({
  imports: [
    CommonModule,
GridModule
    ],
    declarations: [DynamicPropertyComponent, DynamicPropertyValueComponent]
  
})
export class DynamicPropertyModelModule { }
