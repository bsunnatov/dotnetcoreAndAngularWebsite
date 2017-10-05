import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DynamicPropertyComponent } from './dynamic-property.component';
import { DynamicPropertyValueComponent } from '../dynamic-property-value/dynamic-property-value.component'
import { GridModule } from '@progress/kendo-angular-grid';
import { DynamicPropertyService } from '../../shared/services/dynamicProperty.service';
import { DynamicPropertyValueService } from '../../shared/services/dynamicPropertyValue.service';
@NgModule({
    imports: [
        CommonModule,
        GridModule
    ],
    declarations: [DynamicPropertyComponent, DynamicPropertyValueComponent],
    exports:[DynamicPropertyComponent],
    providers:[DynamicPropertyService,DynamicPropertyValueService]

})
export class DynamicPropertyModelModule { }
