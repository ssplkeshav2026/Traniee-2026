import {
  Component,
  OnInit,
  inject,
  signal
} from '@angular/core';

import {
  CommonModule
} from '@angular/common';

import {
  ActivatedRoute
} from '@angular/router';

import {
  UserService
} from '../../services/user.service';
import { User } from '../../models/auth.model';


@Component({
  selector: 'app-view-user',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './view-user.html',
  styleUrl: './view-user.css'
})
export class ViewUser implements OnInit {

  private route =
    inject(ActivatedRoute);

  private userService =
    inject(UserService);

  user =
    signal<User| null>(null);

  ngOnInit(): void {

    const id =
      Number(
        this.route
          .snapshot
          .paramMap
          .get('id')
      );

    this.userService
      .getUser(id)
      .subscribe({

        next: (response) => {

          this.user.set(
            response.data
          );

        }

      });

  }

}