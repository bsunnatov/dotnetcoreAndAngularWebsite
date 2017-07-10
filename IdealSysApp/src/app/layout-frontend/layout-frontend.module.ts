import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutFrontendRoutingModule } from './layout-frontend-routing.module';
import { LayoutFrontendComponent } from './layout-frontend.component';
import { AboutComponent } from './about/about.component';
@NgModule({
  imports: [
      CommonModule,
      LayoutFrontendRoutingModule,
    ],
  declarations: [LayoutFrontendComponent, AboutComponent]
})
export class LayoutFrontendModule { }
