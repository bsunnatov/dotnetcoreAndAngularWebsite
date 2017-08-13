import { Component, OnInit } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Rx';
import { fadeAnimate, slideToBottom } from '../../router.animations';

@Component({
  selector: 'app-product-category',
  templateUrl: './product-category.component.html',
  styleUrls: ['./product-category.component.scss'],
  animations: [fadeAnimate()]
})
export class ProductCategoryComponent implements OnInit {
    private gridData: any[]=[];
    public view: Observable<GridDataResult>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
  constructor() { }

  ngOnInit() {
  }

}
