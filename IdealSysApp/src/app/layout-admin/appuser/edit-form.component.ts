import { Component, Input, Output, EventEmitter} from '@angular/core';
import { Validators, FormGroup, FormControl } from '@angular/forms';
import { AppUser } from '../../shared/models/appuser';
@Component({
    selector: 'kendo-grid-edit-form',
  templateUrl: './edit-form.component.html',
  styleUrls: ['./edit-form.component.scss']
})
export class EditFormComponent  {

    private editForm = new FormGroup({
        'FirstName': new FormControl("", Validators.required),
        'LastName': new FormControl("", Validators.required),
        'IsBlocked': new FormControl(false),
        'Id': new FormControl()
    });
    private active: boolean = false;
    @Input() public isNew: boolean = false;

    @Input() public set model(user: AppUser) {
        this.editForm.reset(user);
        this.active = user !== undefined;
    }

    @Output() cancel: EventEmitter<any> = new EventEmitter();
    @Output() save: EventEmitter<AppUser> = new EventEmitter();

    public onSave(e): void {
        e.preventDefault();
        this.save.emit(this.editForm.value);
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
}
