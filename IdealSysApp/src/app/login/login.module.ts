import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
//import { UserService } from '../shared/services/user.service';
import { SharedModule } from '../shared/modules/shared.module';
import { EmailValidator } from '../directives/email-validator.directive';
import { FormsModule } from '@angular/forms';
@NgModule({
    imports: [
        CommonModule,
        LoginRoutingModule,
        SharedModule,
        FormsModule
    ],
    declarations: [LoginComponent, EmailValidator],
    providers: []
})
export class LoginModule { }
