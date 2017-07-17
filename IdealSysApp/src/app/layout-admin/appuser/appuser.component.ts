import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-appuser',
  templateUrl: './appuser.component.html',
  styleUrls: ['./appuser.component.scss']
})
export class AppuserComponent implements OnInit {

    constructor(private userService: UserService) { }

    ngOnInit() {
      
        //alert('sasa');
       
  }

    getUserList() {

        this.userService.list().subscribe(s => { console.log(s) });
       
  }
}
