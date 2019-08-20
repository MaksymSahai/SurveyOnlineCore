import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { MustMatch } from 'src/app/Helpers/MustMatch';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})

export class RegistrationComponent implements OnInit {

  registerForm: FormGroup;
  loading = false;
  submitted = false;
  error: string;

  constructor(
      private formBuilder: FormBuilder,
      private router: Router,
      private authenticationService: AuthenticationService,
  ) {
      // redirect to home if already logged in
      if (this.authenticationService.currentUserValue) {
          this.router.navigate(['/']);
      }
  }

  ngOnInit() {
      this.registerForm = this.formBuilder.group({
        CustomerName: ['', Validators.required],
          CustomerEmail: ['', [Validators.required, Validators.email]],
          CustomerPassword: ['', [Validators.required, Validators.minLength(6)]],
          confirmPassword: ['', Validators.required],
      },{
        validator: MustMatch('CustomerPassword', 'confirmPassword')
    }
      );
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
      this.submitted = true;

      // reset alerts on submit

      // stop here if form is invalid
      if (this.registerForm.invalid) {
          return;
      }

      this.loading = true;
      this.authenticationService.register(this.registerForm.value)
          .pipe(first())
          .subscribe(
              data => {
                  this.router.navigate(['/login']);
              },
              error => {
                  this.error = "Customer with this name already exists";
                  this.loading = false;
              });
  }

  onReset() {
    this.submitted = false;
    this.registerForm.reset();
}
}
