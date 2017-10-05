import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../../router.animations';
import { UserRegistration } from '../../shared/models/user-registration';
import { UserService } from '../../shared/services/user.service';

@Component({
    selector: 'app-registration-form',
    templateUrl: './reg-form.component.html',
    styleUrls: ['./reg-form.component.scss'],
    animations: [routerTransition()]
})
export class RegFormComponent implements OnInit {
    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;
    constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
  }
  registerUser({ value, valid }: { value: UserRegistration, valid: boolean }) {
      this.submitted = true;
      this.isRequesting = true;
      this.errors = '';
      if (valid) {
          this.userService.register(value.email, value.password, value.firstName, value.lastName, value.location)
              .finally(() => this.isRequesting = false)
              .subscribe(
              result => {
                  if (result) {
                      this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
                  }
              },
              errors => this.errors = errors);
      }
  }  
}
