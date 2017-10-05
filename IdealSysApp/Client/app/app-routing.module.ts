import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './shared/auth.guard';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'admin',
        pathMatch:'full'
        //loadChildren: './layout-frontend/layout-frontend.module#LayoutFrontendModule',
        // canActivate: [AuthGuard]
    },
    {
        path: 'admin',
        loadChildren: './layout-admin/layout-admin.module#LayoutAdminModule',
        canActivate: [AuthGuard]
    },
    { path: 'login', loadChildren: './login/login.module#LoginModule' },
    //{ path: 'signup', loadChildren: './signup/signup.module#SignupModule' },
    { path: 'not-found', loadChildren: './page-not-found/page-not-found.module#PageNotFoundModule' },
    { path: '**', redirectTo: 'not-found' }
];

@NgModule({
   // declarations: [SpinnerComponent],
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
