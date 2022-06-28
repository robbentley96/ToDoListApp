import { Component, OnInit, Input } from '@angular/core';
import { TaskComponent } from '../task/task.component';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {

  constructor(private httpService: HttpService) { }
  ngOnInit(): void {
    
  }
  
  @Input() todoId=0;
  @Input() todoName = "";
  @Input() taskList=[{id:0,name:""}];
  newTaskName: string = '';

  deleteToDo(){
    setTimeout(()=> this.httpService.deleteToDoItem('{"id":'+this.todoId+'}').subscribe(response => {
      window.location.reload();
    })
    )
  }

  createTask(){
    setTimeout(()=> this.httpService.createTaskItem('{"name":"'+this.newTaskName+'","toDoItemId":'+this.todoId+'}').subscribe(response => {
      window.location.reload();
    })
    )
  }
}
