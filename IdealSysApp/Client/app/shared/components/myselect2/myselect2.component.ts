import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Select2OptionData } from 'ng2-select2';
import{Http} from '@angular/http';
import { ConfigService } from '../../utils/config.service';
@Component({
    selector: 'app-myselect2',
    templateUrl: './myselect2.component.html',
    styleUrls: ['./myselect2.component.scss']
})
export class MySelect2Component implements OnInit {
    public exampleData: Array<Select2OptionData>;
    public options: Select2Options;

    private baseUrl = "";
    private selectedItem: any;
    @Input() public url: string = "";
    @Input() public opt: any = {};
    @Input() public value: number=0;
    @Output() private onChange = new EventEmitter();
    constructor(private configService: ConfigService, public http: Http) {
        this.baseUrl = this.configService.getApiURI();

    }

    ngOnInit() {



        this.initOpt();

    }
    initOpt() {
        this.options = {
            multiple: false,
            allowClear: true,
            minimumInputLength: 0,
            disabled: false,
            placeholder: { id: -1, text: "выберите" },
            width: "100%",
            ajax: {
                headers: {
                    "Authorization": "Bearer " + sessionStorage.getItem('auth_token'),
                    "Content-Type": "application/json",
                },
                url: this.baseUrl + this.url,
                dataType: 'json',
                delay: 0,
                data: function (params) {

                    return "filter=" + JSON.stringify({

                        term: params.term, // search term
                        take: 10,
                        skip: (params.page ? params.page * 10 : 0),
                        ParentId: 0,
                        AsSelect2: true
                    }

                    );
                },
                processResults: function (data, params) {
                    // parse the results into the format expected by Select2
                    // since we are using custom formatting functions we do not need to
                    // alter the remote JSON data, except to indicate that infinite
                    // scrolling can be used
                    params.page = params.page || 1;
                    return {

                        results: data.Data,
                        pagination: {
                            more: (params.page * 10) < data["Total"]
                        }
                    };
                },
                cache: false,

            },
            initSelection: (e, callback) => {
                if (this.value > 0)
                    this.http.get(this.baseUrl + this.url + `/${this.value}`)
                        .subscribe((r) => { let item = r.json(); callback({ id: item.Id, text: item.Name }) });
            },
            escapeMarkup: function (markup) { return markup; }, // let our custom formatter work

            templateResult: function (item: any) { if (item.children) return `<span class='text text-info fa fa-circle'> ${item.text}<span>`; else return item.text; }, // omitted for brevity, see the source of this page
            templateSelection: function (item) { return item.text } // omitted for brevity, see the source of this page

        }
    }
 
    changed(item) {
        this.selectedItem = item;
        this.onChange.emit(item);
    }

}
