import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductComponent } from './product.component';
import { DynamicPropertyComponent } from '../dynamic-property/dynamic-property.component';
const routes: Routes = [
    { path: '', component: ProductComponent },
    { path: 'property', component: DynamicPropertyComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProductRoutingModule { }