import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import{CustomerComponent} from'./customer.component'
import { CustomerRoutes } from './customer.routing'
import { DialogModule } from '@progress/kendo-angular-dialog';
import { GridModule } from '@progress/kendo-angular-grid';
import { ReactiveFormsModule } from '@angular/forms';
import{KendoEditFormComponent} from './editform/edit-form.component'
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CustomerRoutes),
    GridModule,
    DialogModule,
    ReactiveFormsModule
  ],
  declarations: [CustomerComponent,KendoEditFormComponent]
})
export class CustomerModule { }
