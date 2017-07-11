import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login.component';
import { RegFormComponent } from './reg-form/reg-form.component';
const routes: Routes = [
    { path: '', component: LoginComponent },
    { path: 'signup', component: RegFormComponent }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LoginRoutingModule { }
