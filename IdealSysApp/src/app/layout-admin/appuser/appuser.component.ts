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
        this.gridData = new Array<AppUser>();
        this.userService.list().subscribe((users: Array<AppUser>) => { this.gridData = users });
        console.log(this.gridData)
       
  }
}
