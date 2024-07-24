import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TaskService } from '../../services/task.service'; // Ensure the correct path
import { Task } from '../../models/task.model'; // Ensure the correct path
import { DatePipe } from '@angular/common';
import { CommonModule } from '@angular/common'; // Import CommonModule for *ngFor

@Component({
  selector: 'app-task-list',
  standalone: true,
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
  imports: [CommonModule],  // Import CommonModule here
  providers: [DatePipe]     // Provide DatePipe here
})
export class TaskListComponent implements OnInit {
  tasks: Task[] = [];

  constructor(
    private taskService: TaskService, 
    private router: Router,
    private datePipe: DatePipe // Inject DatePipe here
  ) {}

  ngOnInit() {
    this.loadTasks();
  }

  loadTasks() {
    this.taskService.getTasks().subscribe((data: Task[]) => {
      this.tasks = data.sort((b, a) => new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime());
    });
  }

  deleteTask(id: number) {
    this.taskService.deleteTask(id).subscribe(() => {
      this.tasks = this.tasks.filter(task => task.id !== id);
    });
  }

  navigateToAddTask() {
    this.router.navigate(['/add-task']);
  }
}
