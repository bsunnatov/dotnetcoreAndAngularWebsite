import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private translate: TranslateService) {
        translate.addLangs(['uz', 'ru']);
        translate.setDefaultLang('uz');
        //const browserLang = translate.getBrowserLang();
        // translate.use(browserLang.match(/en|ru|uz/) ? browserLang : 'uz');
        translate.use("ru");
    }
}
