import {
  Component,
  OnInit,
  inject,
  signal
} from '@angular/core';

import { CommonModule, NgFor } from '@angular/common';

import { TaskService } from '../../services/task.service';

import { Task, TasksResponse } from '../../models/task.model';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-my-tasks',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './my-tasks.html',
  styleUrls: ['./my-tasks.css']
})
export class MyTasks implements OnInit {

  private taskService =
    inject(TaskService);

  tasks = signal<Task[]>([])
  constructor() {

  console.log(
    'MY TASKS COMPONENT CREATED'
  );

}

  ngOnInit(): void {
      console.log(
    'MY TASKS ONINIT'
  );

    this.loadTasks();

  }

  loadTasks(): void {

    this.taskService
      .getMyTasks()
      .subscribe({

        next: (response) => {


          this.tasks.set(response.data)

          console.log('Before Assign');
          console.log(this.tasks);

    


        },

        error: (error) => {

          console.error(error);

        }

      });

  }
  changeStatus(
    taskId: number,
    status: string
  ): void {

    this.taskService
      .updateTaskStatus(
        taskId,
        status
      )
      .subscribe({

        next: () => {

          this.loadTasks();

        },

        error: (error) => {

          console.error(
            error
          );

        }

      });

  }

  onStatusChange(
    event: Event,
    taskId: number
  ): void {

    const target =
      event.target as HTMLSelectElement;

    this.changeStatus(
      taskId,
      target.value
    );

  }

}