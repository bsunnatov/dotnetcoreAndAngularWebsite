import { Component, OnInit } from '@angular/core';
import { RoleService } from '../../shared/services/role.service';
@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})
export class RoleComponent implements OnInit {

    public events: string[] = [];
    public source: Array<string> = [];
    public data: Array<string>;
    private log(event: string, arg?: any): void {
        this.events.push(`${event}`);
    }
    constructor(private roleService: RoleService) {
        this.roleService.list().subscribe(p => this.data = p);
    }

    public valueChange(value: any): void {
        this.log("valueChange", value);
    }

    public selectionChange(value: any): void {
        this.log("selectionChange", value);
    }

    public filterChange(filter: any): void {
        this.log("filterChange", filter);
        this.data = this.source.filter((s) => s.toLowerCase().indexOf(filter.toLowerCase()) !== -1);
    }

    public open(): void {
        this.log("open");
    }

    public close(): void {
        this.log("close");
    }

    public focus(): void {
        this.log("focus");
    }

    public blur(): void {
        this.log("blur");
    }

   

  ngOnInit() {
  }

}
