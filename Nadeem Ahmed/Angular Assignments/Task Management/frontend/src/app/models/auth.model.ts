export interface RegisterRequest {
  username: string;
  email: string;
  password: string;
}

export interface RegisterResponse {
  success: boolean;
  message: string;
  data: User;
}

export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  accessToken: string;
  user: User;
  message: string;
}

export interface User {
  id: number;
  username: string;
  email: string;
  isActive: boolean;
}

export interface StoredUser {
  id: number;
  username: string;
  email: string;
  isActive:boolean;
  roleId?: number;

  Role?: {
    id: number;
    name: string;
  };
}

