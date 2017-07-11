import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LayoutAdminComponent } from './layout-admin.component';
const routes: Routes = [
    {
        path: '', component: LayoutAdminComponent,
        children: [
            { path: 'dashboard', loadChildren: './dashboard/dashboard.module#DashboardModule' },
            //{ path: 'charts', loadChildren: './charts/charts.module#ChartsModule' },
            //{ path: 'tables', loadChildren: './tables/tables.module#TablesModule' },
            //{ path: 'forms', loadChildren: './form/form.module#FormModule' },
            { path: 'bs-element', loadChildren: './bs-element/bs-element.module#BsElementModule' },
            { path: 'grid', loadChildren: './grid/grid.module#GridModule' },
            //{ path: 'components', loadChildren: './bs-component/bs-component.module#BsComponentModule' },
            //{ path: 'blank-page', loadChildren: './blank-page/blank-page.module#BlankPageModule' },
        ]
    }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LayoutAdminRoutingModule { }
