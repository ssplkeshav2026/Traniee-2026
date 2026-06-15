import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Task, TaskCreateRequest, TasksResponse, TaskUpdateRequest } from '../models/task.model';

@Injectable({
  providedIn: 'root',
})
export class TaskService {

  private http = inject(HttpClient);

  getTasks() {
    return this.http.get<Task[]>(
      `${environment.apiUrl}/tasks`
    )
  }

  getTask(id: number) {
    return this.http.get<Task>(
      `${environment.apiUrl}/tasks/${id}`
    );
  }

  createTask(data: TaskCreateRequest) {

    return this.http.post<TasksResponse>(
      `${environment.apiUrl}/tasks`,
      data
    );

  }

  getMyTasks(): Observable<TasksResponse> {
    return this.http.get<TasksResponse>(
      `${environment.apiUrl}/tasks`
    );
  }

  updateTask(
  id: number,
  data: TaskUpdateRequest
) {

  return this.http.put(
    `${environment.apiUrl}/tasks/${id}`,
    data
  );

}

  updateTaskStatus(
    id: number,
    status:string
  ) {

    return this.http.patch<TasksResponse>(
      `${environment.apiUrl}/tasks/${id}`,
      {status}
    );
  }

  getAllTasks(): Observable<TasksResponse> {

  return this.http.get<TasksResponse>(
    `${environment.apiUrl}/tasks/all`
  );

}
}
