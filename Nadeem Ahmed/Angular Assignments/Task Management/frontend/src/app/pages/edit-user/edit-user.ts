import {
  Component,
  OnInit,
  inject
} from '@angular/core';

import {
  CommonModule
} from '@angular/common';

import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import {
  ActivatedRoute,
  Router
} from '@angular/router';

import {
  UserService
} from '../../services/user.service';

import {
  UpdateUserRequest
} from '../../models/user.model';

@Component({
  selector: 'app-edit-user',

  standalone: true,

  imports: [
    CommonModule,
    ReactiveFormsModule
  ],

  templateUrl: './edit-user.html',

  styleUrl: './edit-user.css'
})
export class EditUser
implements OnInit {

  private fb =
    inject(FormBuilder);

  private route =
    inject(ActivatedRoute);

  private router =
    inject(Router);

  private userService =
    inject(UserService);

  userId = 0;

  userForm =
    this.fb.nonNullable.group({

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

      roleId: [
        3,
        Validators.required
      ]

    });

  ngOnInit(): void {

    this.userId =
      Number(
        this.route
          .snapshot
          .paramMap
          .get('id')
      );

    this.loadUser();

  }

  loadUser(): void {

    this.userService
      .getUser(
        this.userId
      )
      .subscribe({

        next: (
          response
        ) => {

          const user =
            response.data;

          this.userForm.patchValue({

            username:
              user.username,

            email:
              user.email,


          });

        }

      });

  }

  updateUser(): void {

    if (
      this.userForm.invalid
    ) {
      return;
    }

    const data:
      UpdateUserRequest = {

      username:
        this.userForm
          .getRawValue()
          .username,

      email:
        this.userForm
          .getRawValue()
          .email,

      roleId:
        this.userForm
          .getRawValue()
          .roleId

    };

    this.userService
      .updateUser(
        this.userId,
        data
      )
      .subscribe({

        next: () => {

          alert(
            'User Updated Successfully'
          );

          this.router.navigate([
            '/users'
          ]);

        },

        error: (
          error
        ) => {

          console.error(
            error
          );

        }

      });

  }

}