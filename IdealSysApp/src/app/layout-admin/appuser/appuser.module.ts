import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridModule } from '@progress/kendo-angular-grid';
import { AppuserRoutingModule } from './appuser-routing.module';
import { AppuserComponent } from './appuser.component';
import { PageHeaderModule } from './../../shared/modules';
import { TranslateModule } from '@ngx-translate/core';
@NgModule({
    imports: [
        CommonModule,
        AppuserRoutingModule,
        PageHeaderModule,
        TranslateModule,
        GridModule
    ],
    declarations: [AppuserComponent]
})
export class AppuserModule { }