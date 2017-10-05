import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LayoutAdminComponent } from './layout-admin.component';
const routes: Routes = [
    {
        path: '', component: LayoutAdminComponent,
        children: [
            { path: 'bs-element', loadChildren: './bs-element/bs-element.module#BsElementModule' },
            { path: 'grid', loadChildren: './grid/grid.module#GridsModule' },
            //start
            { path: 'dashboard', loadChildren: './dashboard/dashboard.module#DashboardModule' },
            { path: 'appusers', loadChildren: './appuser/appuser.module#AppuserModule' },
            { path: 'productCategory', loadChildren: './product-category/product-category.module#ProductCategoryModule' },
            { path: 'storage', loadChildren: './storage/storage.module#StorageModule' },
            { path: 'product', loadChildren: './product/product.module#ProductModule' },
            { path: 'customer', loadChildren: './customer/customer.module#CustomerModule' },
        ]
    }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LayoutAdminRoutingModule { }
