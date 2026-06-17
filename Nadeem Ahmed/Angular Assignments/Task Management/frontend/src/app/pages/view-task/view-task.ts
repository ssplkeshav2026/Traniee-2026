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
  TaskService
} from '../../services/task.service';

import {
  Task
} from '../../models/task.model';

@Component({
  selector: 'app-view-task',

  standalone: true,

  imports: [
    CommonModule
  ],

  templateUrl:
    './view-task.html',

  styleUrls: [
    './view-task.css'
  ]
})
export class ViewTask
implements OnInit {

  private taskService =
    inject(TaskService);

  private route =
    inject(ActivatedRoute);

  task =
    signal<Task | null>(
      null
    );

  ngOnInit(): void {

    const id =
      Number(
        this.route
          .snapshot
          .paramMap
          .get('id')
      );

    this.taskService
      .getTask(id)
      .subscribe({

        next: (
          response: any
        ) => {

          this.task.set(
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

}