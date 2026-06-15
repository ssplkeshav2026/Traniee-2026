import {
  Component,
  inject,
  OnInit
} from '@angular/core';

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
  TaskService
} from '../../services/task.service';

import {
  CommonModule
} from '@angular/common';

@Component({
  selector: 'app-edit-task',

  standalone: true,

  imports: [
    CommonModule,
    ReactiveFormsModule
  ],

  templateUrl:
    './edit-task.html'
})
export class EditTask
implements OnInit {

  private fb =
    inject(FormBuilder);

  private taskService =
    inject(TaskService);

  private route =
    inject(ActivatedRoute);

  private router =
    inject(Router);

  taskId = 0;

  taskForm =
    this.fb.nonNullable.group({

      title: [
        '',
        Validators.required
      ],

      description: [
        '',
        Validators.required
      ],

      assignedToUserId: [
        0,
        Validators.required
      ],

      status: [
        'Pending'
      ],

      dueDate: [
        '',
        Validators.required
      ]

    });

  ngOnInit(): void {

    this.taskId =
      Number(
        this.route
          .snapshot
          .paramMap
          .get('id')
      );

    this.loadTask();

  }

  loadTask(): void {

    this.taskService
      .getTask(
        this.taskId
      )
      .subscribe({

        next: (
          response: any
        ) => {

          const task =
            response.data;

          this.taskForm
            .patchValue({

              title:
                task.title,

              description:
                task.description,

              assignedToUserId:
                task.assignedToUserId,

              status:
                task.status,

              dueDate:
                task.dueDate
                  .split('T')[0]

            });

        }

      });

  }

  updateTask(): void {

    if (
      this.taskForm.invalid
    ) {
      return;
    }

    this.taskService
      .updateTask(
        this.taskId,
        this.taskForm
          .getRawValue()
      )
      .subscribe({

        next: () => {

          alert(
            'Task Updated Successfully!'
          );

          this.router
            .navigate([
              '/tasks'
            ]);

        }

      });

  }

}