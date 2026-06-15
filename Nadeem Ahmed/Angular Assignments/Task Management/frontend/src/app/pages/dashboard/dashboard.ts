import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TaskService } from '../../services/task.service';

import { DashboardStats }
  from '../../models/dashboard.model';

import {
  Task,
  TasksResponse
} from '../../models/task.model';

import { StoredUser } from '../../models/auth.model';
import { Router, RouterLink } from "@angular/router";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard implements OnInit {
  private taskService = inject(TaskService);
  private router = inject(Router)

  tasks = signal<Task[]>([])

  stats = signal<DashboardStats>({
    totalTasks: 0,
    pendingTasks: 0,
    inProgressTasks: 0,
    completedTasks: 0
  });

  userName = signal('');
  userRole = signal('');



  ngOnInit(): void {

    const userString =
      localStorage.getItem('user');

    if (userString) {

      const user: StoredUser =
        JSON.parse(userString);

      this.userName.set(user.username)

      this.userRole.set(
        user.Role?.name ??
        'Employee'
      );
    }

    this.loadTasks();
  }

  loadTasks(): void {

    switch (this.userRole()) {

      case 'Admin':

        this.taskService
          .getAllTasks()
          .subscribe({
            next: response => {
              this.calculateStats(
                response.data
              );
            }
          });

        break;

      case 'Manager':

        this.taskService
          .getAllTasks()
          .subscribe({
            next: response => {
              this.calculateStats(
                response.data
              );
            }
          });

        break;

      case 'Employee':

        this.taskService
          .getMyTasks()
          .subscribe({
            next: response => {
              this.calculateStats(
                response.data
              );
            }
          });

        break;
    }
  }
  private calculateStats(
    tasks: Task[]
  ): void {

    this.stats.set({

      totalTasks:
        tasks.length,

      pendingTasks:
        tasks.filter(
          task =>
            task.status ===
            'Pending'
        ).length,

      inProgressTasks:
        tasks.filter(
          task =>
            task.status ===
            'In Progress'
        ).length,

      completedTasks:
        tasks.filter(
          task =>
            task.status ===
            'Completed'
        ).length

    });

  }

  logout(): void {

    localStorage.removeItem('token');

    localStorage.removeItem('user');

    this.router.navigate(['/login']);

  }
}