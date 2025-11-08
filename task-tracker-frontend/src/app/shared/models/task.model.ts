export interface Task {
  id: number;
  title: string;
  description: string;
  status: 'Pending' | 'InProgress' | 'Completed';
  assignedUser?: string;
  dueDate?: string;
  createdAt?: string;
}
