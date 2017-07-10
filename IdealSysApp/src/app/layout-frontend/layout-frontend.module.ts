import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutFrontendRoutingModule } from './layout-frontend-routing.module';
import { LayoutFrontendComponent } from './layout-frontend.component';
import { AboutComponent } from './about/about.component';
import { TopbarComponent } from './topbar/topbar.component';
@NgModule({
  imports: [
      CommonModule,
      LayoutFrontendRoutingModule,
    ],
  declarations: [LayoutFrontendComponent, AboutComponent, TopbarComponent]
})
export class LayoutFrontendModule { }
