import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutFrontendRoutingModule } from './layout-frontend-routing.module';
import { LayoutFrontendComponent } from './layout-frontend.component';
import { AboutComponent } from './about/about.component';
import { TopbarComponent } from './topbar/topbar.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  imports: [
      CommonModule,
      LayoutFrontendRoutingModule,
      TranslateModule,
      NgbDropdownModule.forRoot(),
    ],
  declarations: [LayoutFrontendComponent, AboutComponent, TopbarComponent, NavbarComponent, FooterComponent, HomeComponent]
})
export class LayoutFrontendModule { }
