import { BrowserModule } from '@angular/platform-browser';
import { Http, HttpModule, XHRBackend } from '@angular/http';
import { NgModule } from '@angular/core';
import { UserService } from './shared/services/user.service';
import { RoleService } from './shared/services/role.service';
import { ConfigService } from './shared/utils/config.service';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthGuard } from './shared/auth.guard';
import { SharedModule } from './shared/modules/shared.module';
import { CoreModule } from './core/core.module';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { AuthenticateXHRBackend } from './authenticate-xhr.backend';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { GridModule } from '@progress/kendo-angular-grid';
export function HttpLoaderFactory(http: Http) {
    //     for development
    //     return new TranslateHttpLoader(http, '/start-angular/SB-Admin-BS4-Angular-4/master/dist/assets/i18n/', '.json');
    return new TranslateHttpLoader(http, '/assets/i18n/', '.json');
}

@NgModule({
    declarations: [
        AppComponent

    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        HttpModule,
        AppRoutingModule,
        NgbModalModule.forRoot(),
        SharedModule.forRoot(),
        CoreModule.forRoot(),
        GridModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [Http]
            }
        }),


    ],
    exports:[CoreModule],
    providers: [AuthGuard, UserService, ConfigService, RoleService, {
        provide: XHRBackend,
        useClass: AuthenticateXHRBackend
    }],
    bootstrap: [AppComponent]
})
export class AppModule { }