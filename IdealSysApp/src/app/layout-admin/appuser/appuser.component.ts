import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/services/user.service';
import { AppUser } from '../../shared/models/appuser';

@Component({
    selector: 'app-appuser',
    templateUrl: './appuser.component.html',
    styleUrls: ['./appuser.component.scss']
})
export class AppuserComponent implements OnInit {
    private gridData: Array<AppUser>;
    constructor(private userService: UserService) { }

    ngOnInit() {

        this.getUserList();

    }

    getUserList() {
         this.userService.list().subscribe((users: Array<AppUser>) => { this.gridData = users;});

    }
    protected editHandler({sender, rowIndex, dataItem}) {
        // define all editable fields validators and default values
        //const group = new FormGroup({
        //    'ProductID': new FormControl(dataItem.ProductID),
        //    'ProductName': new FormControl(dataItem.ProductName, Validators.required),
        //    'UnitPrice': new FormControl(dataItem.UnitPrice),
        //    'UnitsInStock': new FormControl(dataItem.UnitsInStock, Validators.compose([Validators.required, Validators.pattern('^[0-9]{1,2}')])),
        //    'Discontinued': new FormControl(dataItem.Discontinued)
        //});

        // put the row in edit mode, with the `FormGroup` build above
        //sender.editRow(rowIndex, group);
    }
}
