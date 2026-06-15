import { Component, inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule
} from '@angular/forms';

import {
  Router,
  RouterLink
} from '@angular/router';

import {
  AuthService
} from '../../services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {

  private authService =
    inject(AuthService);

  private router =
    inject(Router);

  registerForm!: FormGroup;

  constructor(
    private fb: FormBuilder
  ) {

    this.registerForm =
      this.fb.group({

        username: [
          '',
          Validators.required
        ],

        email: [
          '',
          [
            Validators.required,
            Validators.email
          ]
        ],

        password: [
          '',
          Validators.required
        ],

        confirmPassword: [
          '',
          Validators.required
        ]

      });

  }

  register(): void {

    if (
      this.registerForm.invalid
    ) {
      return;
    }

    const {
      username,
      email,
      password,
      confirmPassword
    } = this.registerForm.value;

    if (
      password !==
      confirmPassword
    ) {

      alert(
        'Passwords do not match'
      );

      return;
    }

    this.authService
      .register({

        username,

        email,

        password

      })
      .subscribe({

        next: (response) => {

          console.log(
            'Registration Success',
            response
          );

          alert(
            response.message
          );

          this.registerForm.reset();

          this.router.navigate([
            '/login'
          ]);

        },

        error: (error) => {

          console.error(
            'Registration Failed',
            error
          );

          alert(
            error.error.message
          );

        }

      });

  }

}