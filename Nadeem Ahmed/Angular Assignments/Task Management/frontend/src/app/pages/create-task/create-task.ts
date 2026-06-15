import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { TaskService } from '../../services/task.service';
import { UserService } from '../../services/user.service';
import { Employee } from '../../models/user.model';
import { TaskCreateRequest } from '../../models/task.model';

@Component({
  selector: 'app-create-task',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './create-task.html',
  styleUrl: './create-task.css',
})
export class CreateTask implements OnInit {
  private fb = inject(FormBuilder);
  private taskService = inject(TaskService);
  private userService = inject(UserService);

  employees = signal<Employee[]>([]);

  taskForm = this.fb.group(
    {
      title: [
        '',
        Validators.required
      ],

      description: [
        '',
        Validators.required
      ],

      assignedToUserId: [
        '',
        Validators.required
      ],

      dueDate: [
        '',
        Validators.required
      ],
    });

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.userService
      .getEmployees()
      .subscribe({
        next: (
          response
        ) => {
          this.employees.set(
            response.data
          );
        }
      })
  }

  createTask(): void {

    if (this.taskForm.invalid) {
      return;
    }

    const taskData: TaskCreateRequest = {

      title:
        this.taskForm.value.title!,

      description:
        this.taskForm.value.description!,

      assignedToUserId:
        Number(
          this.taskForm.value
            .assignedToUserId
        ),

      dueDate:
        this.taskForm.value.dueDate!

    };

    this.taskService
      .createTask(taskData)
      .subscribe({

        next: () => {

          alert(
            'Task Created'
          );

          this.taskForm.reset();

        },

        error: (error) => {

          console.log(error);

          console.log(error.status);

          console.log(error.error);

        }

      });

  }



}
