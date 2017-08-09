import { Component, OnInit } from '@angular/core';
import { fadeAnimate, slideToBottom } from '../../router.animations';
@Component({
  selector: 'app-product-category',
  templateUrl: './product-category.component.html',
  styleUrls: ['./product-category.component.scss'],
  animations: [fadeAnimate()]
})
export class ProductCategoryComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
