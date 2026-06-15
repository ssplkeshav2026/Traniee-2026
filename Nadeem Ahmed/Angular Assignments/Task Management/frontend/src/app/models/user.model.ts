import { User } from "./auth.model";

export interface Employee {

  id: number;

  username: string;

  email: string;

}

export interface EmployeesResponse {

  success: boolean;

  data: Employee[];

}

export interface UsersResponse {

  success: boolean;

  data: User[];

}

export interface UserResponse {
    success:boolean;
    data:User;
}

export interface UpdateUserRequest {

  username: string;

  email: string;

  roleId: number;

}