import {
  Component,
  OnInit,
  inject,
  signal
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { RouterLink } from '@angular/router';

import { UserService } from '../../services/user.service';

import { User } from '../../models/auth.model';


@Component({
  selector: 'app-user-list',

  standalone: true,

  imports: [CommonModule, RouterLink],

  templateUrl:
    './user-list.html',

  styleUrl:
    './user-list.css'
})
export class UserList implements OnInit {

  currentUserId = 0;

  private userService =
    inject(UserService);

  users =
    signal<User[]>([]);

  ngOnInit(): void {

    const currentUser =
      JSON.parse(
        localStorage.getItem(
          'user'
        )!
      );

    this.currentUserId =
      currentUser.id;

    this.loadUsers();

  }

  loadUsers(): void {

    this.userService
      .getAllUsers()
      .subscribe({

        next: (
          response
        ) => {

          this.users.set(
            response.data
          );

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

  deleteUser(
  id: number
): void {

  const confirmed =
    confirm(
      'Are you sure you want to delete this user?'
    );

  if (!confirmed) {
    return;
  }

  this.userService
    .deleteUser(id)
    .subscribe({

      next: () => {

        alert(
          'User deleted successfully'
        );

        this.loadUsers();

      },

      error: (error) => {

        console.error(
          error
        );

        alert(
          'Failed to delete user'
        );

      }

    });

}

}