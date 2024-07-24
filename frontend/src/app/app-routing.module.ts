
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskListComponent } from './components/task-list/task-list.component';
import { AddTaskComponent } from './components/add-task/add-task.component';


const routes: Routes = [
    { path: 'tasks', component: TaskListComponent },
    { path: 'add-task', component: AddTaskComponent },
    { path: '', redirectTo: '/tasks', pathMatch: 'full' }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
