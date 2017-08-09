import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutAdminRoutingModule } from './layout-admin-routing.module';
import { LayoutAdminComponent } from './layout-admin.component';
import { HeaderComponent } from '../shared/components/header/header.component';
import { TranslateModule } from '@ngx-translate/core';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { AdminSidebarComponent } from '../shared/components/admin-sidebar/admin-sidebar.component';
import { ProductCategoryComponent } from './product-category/product-category.component';


//import { UserService } from '../shared/services/user.service';

@NgModule({
  imports: [
      CommonModule,
      LayoutAdminRoutingModule,
      TranslateModule,
      NgbDropdownModule.forRoot(),
      
    ],
  declarations: [LayoutAdminComponent, HeaderComponent, AdminSidebarComponent, ProductCategoryComponent],
  providers: []
})
export class LayoutAdminModule { }
