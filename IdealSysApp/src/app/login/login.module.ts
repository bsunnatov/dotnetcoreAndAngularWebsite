import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
//import { UserService } from '../shared/services/user.service';
import { SharedModule } from '../shared/modules/shared.module';
import { EmailValidator } from '../directives/email-validator.directive';
import { FormsModule } from '@angular/forms';
import { RegFormComponent } from './reg-form/reg-form.component';
@NgModule({
    imports: [
        CommonModule,
        LoginRoutingModule,
        SharedModule,
        FormsModule
    ],
    declarations: [LoginComponent, EmailValidator, RegFormComponent],
    providers: []
})
export class LoginModule { }
