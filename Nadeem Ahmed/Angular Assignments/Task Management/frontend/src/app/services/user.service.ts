import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { EmployeesResponse, UpdateUserRequest, UserResponse, UsersResponse } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  private http = inject(HttpClient)

  getEmployees() {
    return this.http.get<EmployeesResponse>(
      `${environment.apiUrl}/users/employees`
    )
  }

  getAllUsers() {

    return this.http.get<UsersResponse>(
      `${environment.apiUrl}/users`
    );

  }

  getUser(id: number) {

    return this.http.get<UserResponse>(
      `${environment.apiUrl}/users/${id}`
    );

  }

  updateUser(
    id: number,
    data: UpdateUserRequest
  ) {

    return this.http.put<UserResponse>(
      `${environment.apiUrl}/users/${id}`,
      data
    );
  }

  deleteUser(
    id: number
  ) {

    return this.http.delete(
      `${environment.apiUrl}/users/${id}`
    );

  }
}