import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-layout-frontend',
  templateUrl: './layout-frontend.component.html',
  styleUrls: ['./layout-frontend.component.css']
})
export class LayoutFrontendComponent implements OnInit {

    constructor(public router: Router) { }

  ngOnInit() {
      if (this.router.url === '/') {
          this.router.navigate(['/admin']);
      }
  }

}
