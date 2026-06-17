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
  RouterLink
} from '@angular/router';

import {
  TaskService
} from '../../services/task.service';

import {
  Task
} from '../../models/task.model';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink
  ],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css'
})
export class TaskList
implements OnInit {

  private taskService =
    inject(TaskService);

  tasks =
    signal<Task[]>([]);

  ngOnInit(): void {

    this.loadTasks();

  }

  loadTasks(): void {

    this.taskService
      .getAllTasks()
      .subscribe({

        next: (response) => {

          this.tasks.set(
            response.data
          );

        },

        error: (error) => {

          console.error(
            error
          );

        }

      });

  }

}