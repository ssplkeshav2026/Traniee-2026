export interface Task {
  id: number;
  title: string;
  description: string;
  status:
    | 'Pending'
    | 'In Progress'
    | 'Completed';

  dueDate: string;

  assignedToUserId: number;

  assignedByUserId: number;

  createdAt: string;

  updatedAt: string;

}

export interface TaskCreateRequest {

  title: string;

  description: string;

  assignedToUserId: number;

  dueDate: string;

}

export interface TaskUpdateRequest {

  title: string;

  description: string;

  assignedToUserId: number;

  status: string;

  dueDate: string;

}

export interface TasksResponse {
  success: boolean;

  message: string;
  
  data: Task[];
}