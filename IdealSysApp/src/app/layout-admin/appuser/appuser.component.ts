import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from '../../shared/services/user.service';
import { AppUser } from '../../shared/models/appuser';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Rx';
@Component({
    selector: 'app-appuser',
    templateUrl: './appuser.component.html',
    styleUrls: ['./appuser.component.scss']
})
export class AppuserComponent implements OnInit {
    private gridData: any[];
    public view: Observable<GridDataResult>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    private editService: UserService;
    private editDataItem: AppUser;
    private isNew: boolean;
    constructor(private userService: UserService) {
        this.editService = userService;
    }

    public ngOnInit(): void {
        this.editService.list().subscribe(s => this.gridData = s);

        //this.editService.read();
    }

    public onStateChange(state: State) {
        this.gridState = state;

        //this.editService.read();
    }

    public addHandler() {
        this.editDataItem = new AppUser();
        this.isNew = true;
    }

    public editHandler({dataItem}) {
        this.editDataItem = dataItem;
        this.isNew = false;
    }

    public cancelHandler() {
        this.editDataItem = undefined;
    }

    public saveHandler(user: AppUser) {
        this.editService.save(user, this.isNew);
        this.editDataItem = undefined;
    }
 
    public removeHandler({dataItem}) {
        //this.editService.remove(dataItem);
    }

}
