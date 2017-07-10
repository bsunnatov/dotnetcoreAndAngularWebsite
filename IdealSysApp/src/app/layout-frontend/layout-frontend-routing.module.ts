import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LayoutFrontendComponent } from './layout-frontend.component';
import { AboutComponent } from './about/about.component';
const routes: Routes = [
    {
        path: '', component: LayoutFrontendComponent,
        children: [
            {
                path: 'about', component: AboutComponent
            },
            //{ path: 'charts', loadChildren: './charts/charts.module#ChartsModule' },
            //{ path: 'tables', loadChildren: './tables/tables.module#TablesModule' },
            //{ path: 'forms', loadChildren: './form/form.module#FormModule' },
            //{ path: 'bs-element', loadChildren: './bs-element/bs-element.module#BsElementModule' },
            //{ path: 'grid', loadChildren: './grid/grid.module#GridModule' },
            //{ path: 'components', loadChildren: './bs-component/bs-component.module#BsComponentModule' },
            //{ path: 'blank-page', loadChildren: './blank-page/blank-page.module#BlankPageModule' },
        ]
    }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LayoutFrontendRoutingModule { }
