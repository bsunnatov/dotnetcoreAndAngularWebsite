import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { UserService } from '../../services/user.service';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
    private currentUserName: string = "";
    constructor(private translate: TranslateService, public router: Router, private userService: UserService) {
        this.router.events.subscribe((val) => {
            if (val instanceof NavigationEnd && window.innerWidth <= 992) {
                this.toggleSidebar();
            }
        });
        this.currentUserName = userService.currentUserName;
    }

  ngOnInit() {
  }
  toggleSidebar() {
      const dom: any = document.querySelector('body');
      dom.classList.toggle('push-right');
  }
  onLoggedout() {
      this.userService.logout();
  }

  changeLang(language: string) {
      this.translate.use(language);
  }
}
