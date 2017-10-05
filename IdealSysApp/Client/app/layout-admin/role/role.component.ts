import { Component, OnInit,Input,Output,EventEmitter } from '@angular/core';
import { RoleService } from '../../shared/services/role.service';
@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})
export class RoleComponent implements OnInit {

    public data: Array<any> = [];
    @Output() onValueChange: EventEmitter<any> = new EventEmitter();
    @Output() onSelectionChange: EventEmitter<any> = new EventEmitter();
    constructor(private roleService: RoleService) {
        this.roleService.list().subscribe(p => this.data = p);
    }

    public valueChange(value: any): void {
        this.onValueChange.emit(value);
    }

    public selectionChange(value: any): void {
        this.onSelectionChange.emit(value);
    }

    public filterChange(filter: any): void {
       
    }

    public open(): void {
    }

    public close(): void {
    }

    public focus(): void {
    }

    public blur(): void {
    }

   

  ngOnInit() {
  }

}
