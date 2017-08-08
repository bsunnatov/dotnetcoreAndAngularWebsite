import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Validators, FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms';
import { AppUser } from '../../shared/models/appuser';
import { RoleService } from '../../shared/services/role.service';
@Component({
    selector: 'kendo-grid-edit-form',
    templateUrl: './edit-form.component.html',
    styleUrls: ['./edit-form.component.scss']
})
export class EditFormComponent {
    // The order retrieved from the server

    private roleIds: any[]=[];
    private roles: any[] = [];
  
    constructor(private roleService: RoleService, private fb: FormBuilder) {
        this.roleService.list().subscribe((d) => {
            this.roles = d;
        });

    }
    editForm = new FormGroup({
        'FirstName': new FormControl("", Validators.required),
        'LastName': new FormControl("", Validators.required),
        'IsBlocked': new FormControl(false),
        'Id': new FormControl(),
        'OldSelectedRoles': this.fb.array([]),
        'SelectedRoles': this.fb.array([])
    });
    setSelectedRoles() {
        (<FormArray>this.editForm.controls['OldSelectedRoles']).controls=[];
        this.roles.forEach((m, i) => {
            var hasRole = hasRole = this.roleIds.find(x => x == m.id);
            (<FormArray>this.editForm.controls['OldSelectedRoles']).push(new FormControl(hasRole ? true : false));
        });

        
    }
    getSelectedRoles() {
        var r = [];
        var selRoles = (<FormArray>this.editForm.controls['OldSelectedRoles']).controls;
        selRoles.map((s, i) => { if (s.value) { r.push(this.roles[i]) } });
        return r;
    }
    private active: boolean = false;
    @Input() public isNew: boolean = false;

    @Input() public set model(user: AppUser) {
        this.editForm.reset(user);
        if (user) {

            this.roleIds = user.RoleIds ? user.RoleIds:[];

            this.setSelectedRoles();
        }
       
        this.active = user !== undefined;

    }

    @Output() cancel: EventEmitter<any> = new EventEmitter();
    @Output() save: EventEmitter<AppUser> = new EventEmitter();
    public onSave(e): void {
        e.preventDefault();
        var u = <AppUser>this.editForm.value;
        u.SelectedRoles = this.getSelectedRoles();
        this.save.emit(u);
        this.active = false;
    }
    public onCancel(e): void {
        e.preventDefault();
        this.closeForm();
    }

    private closeForm(): void {
        this.active = false;
        this.cancel.emit();
    }
    public onValueChanged(v) {

    }

}
