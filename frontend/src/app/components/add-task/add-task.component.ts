import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router'; // Import Router
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task.model';

@Component({
  selector: 'app-add-task',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent {
  title = '';
  description = '';
  priority: 'High' | 'Medium' | 'Low' = 'Medium';

  constructor(private taskService: TaskService, private router: Router) {} // Inject Router

  onSubmit() {
    if (this.title.trim() === '' || !this.priority) {
      return; // Prevent submission if validation fails
    }

    const newTask: Task = {
      id: 0,
      title: this.title,
      description: this.description,
      priority: this.priority,
      createdAt: new Date()
    };
    this.taskService.addTask(newTask).subscribe(task => {
      console.log('Task added:', task);
      this.router.navigate(['/tasks']); // Navigate to task list after adding
    });

    this.title = '';
    this.description = '';
    this.priority = 'Medium';
  }
}
