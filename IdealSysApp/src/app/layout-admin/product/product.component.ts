import { Component, OnInit, ViewChild} from '@angular/core';
import { GridDataResult, RowClassArgs } from '@progress/kendo-angular-grid';
import { Country, DataService } from '../../shared/services/data.service';
import { State, process } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Rx';
import { fadeAnimate, slideToBottom } from '../../router.animations';
import { Product } from './model';
import { ProductService } from '../../shared/services/product.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IqSelect2Item, IqSelect2Component } from 'ng2-iq-select2';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
  animations: [fadeAnimate()]
})
export class ProductComponent implements OnInit {
    public form: FormGroup;
    public listItems: (term: string) => Observable<Country[]>;
    public listItemsMax: (term: string) => Observable<Country[]>;
    public getItems: (ids: string[]) => Observable<Country[]>;
    public entityToIqSelect2Item: (entity: Country) => IqSelect2Item;
    public count: number;
   // @ViewChild('countrySingle') countrySingle: IqSelect2Component<Country>;
 
    public items: Array<string> = ['Amsterdam', 'Antwerp', 'Athens', 'Barcelona',
        'Berlin', 'Birmingham', 'Bradford', 'Bremen', 'Brussels', 'Bucharest',
        'Budapest', 'Cologne', 'Copenhagen', 'Dortmund', 'Dresden', 'Dublin', 'Düsseldorf',
        'Essen', 'Frankfurt', 'Genoa', 'Glasgow', 'Gothenburg', 'Hamburg', 'Hannover',
        'Helsinki', 'Leeds', 'Leipzig', 'Lisbon', 'Łódź', 'London', 'Kraków', 'Madrid',
        'Málaga', 'Manchester', 'Marseille', 'Milan', 'Munich', 'Naples', 'Palermo',
        'Paris', 'Poznań', 'Prague', 'Riga', 'Rome', 'Rotterdam', 'Seville', 'Sheffield',
        'Sofia', 'Stockholm', 'Stuttgart', 'The Hague', 'Turin', 'Valencia', 'Vienna',
        'Vilnius', 'Warsaw', 'Wrocław', 'Zagreb', 'Zaragoza'];

    private value: any = ['Athens'];
    private _disabledV: string = '0';
    private disabled: boolean = false;

    private get disabledV(): string {
        return this._disabledV;
    }

    private set disabledV(value: string) {
        this._disabledV = value;
        this.disabled = this._disabledV === '1';
    }

    public selected(value: any): void {
        console.log('Selected value is: ', value);
    }

    public removed(value: any): void {
        console.log('Removed value is: ', value);
    }

    public refreshValue(value: any): void {
        this.value = value;
    }

    public itemsToString(value: Array<any> = []): string {
        return value
            .map((item: any) => {
                return item.text;
            }).join(',');
    }
    private isNew: boolean;
    private gridData: Observable<GridDataResult>;
    private _sender: any;
    private _rowIndex: number;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 8,
       
    };
    constructor(private service: ProductService, private dataService: DataService,
        private formBuilder: FormBuilder) {
        this.gridData = service.getAll(this.gridState);
    }
    rowCallback(context: RowClassArgs) {
        const isEven = context.index % 2 == 0;
        return {
            even: isEven,
            odd: !isEven
        };
    }

    ngOnInit() {
        this.form = this.formBuilder.group({
            firstname: {
                value: '',
                disabled: true
            },
            lastname: new FormControl(''),
            option: new FormControl(''),
            countrySingle: [{
                id: '16',
                name: 'Argentina',
                code: 'AR',
                color: '#c1ee5b'
            }, Validators.required],
            countryMultiple: null,
            countryMultipleDisabled: new FormControl({
                value: [{
                    id: '16',
                    name: 'Argentina',
                    code: 'AR',
                    color: '#c1ee5b'
                }, {
                    id: '17',
                    name: 'Indonesia',
                    code: 'ID',
                    color: '#19f77a'
                }],
                disabled: true
            }),
            countrySingleMin0: null,
            countryMultipleMin0: [[{
                id: '16',
                name: 'Argentina',
                code: 'AR',
                color: '#c1ee5b'
            }]],
            countryMin0Count: null,
            habilitado: true
        });
        this.initializeCountryIqSelect2();
        this.form.valueChanges.subscribe(() => {
            // console.log('-->' + this.form.controls['countrySingle'].value);
        });

    }
    private initializeCountryIqSelect2() {
        this.listItems = (term: string) => this.dataService.listData(term);
        this.listItemsMax = (term: string) =>
            this.dataService.listDataMax(term, 3).map((response) => {
                this.count = response.count;
                return response.results;
            });
        this.getItems = (ids: string[]) => this.dataService.getItems(ids);
        this.entityToIqSelect2Item = (entity: any) => {
            return {
                id: entity.id,
                text: entity.name,
                entity: entity
            };
        };
    }

    send(formJson: string) {
        // console.log(formJson);
    }

    onSelect(item: IqSelect2Item) {
        // console.log('Item selected: ' + item.text);
    }

    onRemove(item: IqSelect2Item) {
        // console.log('Item removed: ' + item.text);
    }

    reset2() {
        // console.log('Resetting form');
        this.form.reset();
    }
  private editDataItem: Product;
  public addHandler() {
      this.editDataItem = new Product();
      this.isNew = true;
  }

  public editHandler({sender, rowIndex, dataItem, isNew}) {
      this.editDataItem = dataItem;
      this._sender = sender;
      this.isNew = false;
      this._rowIndex = rowIndex;
  }

  public cancelHandler() {
      this.editDataItem = undefined;
  }

  public saveHandler(model: Product) {
      if (this.isNew)
          this.service.add(model).subscribe(s => { this.reset(this.gridState) });
      else
          this.service.update(model).subscribe(s => {
              this._sender.data["data"][this._rowIndex - this.gridState.skip] = s.json()
          });
      this.editDataItem = undefined;
     
  }
  private reset(filter) {
      this.gridData= this.service.getAll(filter);
}
  public removeHandler({rowIndex, dataItem}) {
      if (confirm("Удалить?"))
          this.service.delete(dataItem.Id).subscribe(s => {
              this.gridData.subscribe(s => { s.data.splice(rowIndex, 1); });
      });
  }
  public onStateChange(e) {
      this.gridState = e;
      this.reset(e);
  }
}
