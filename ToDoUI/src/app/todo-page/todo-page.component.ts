import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-todo-page',
  templateUrl: './todo-page.component.html',
  styleUrls: ['./todo-page.component.css']
})
export class TodoPageComponent implements OnInit {

  constructor(private httpService: HttpService, private router: Router) { }

  ngOnInit(): void {
    this.getToDoItems();
  }
  newToDoName: string = '';

  todoList: {id:number, name:string, taskItems:{id: number, name: string}[]}[] = [
]

getToDoItems(){
  setTimeout(()=> this.httpService.getToDoItems().subscribe(response => {
    if(response.status == 200){
      if(response.body){
        this.todoList = JSON.parse(response.body.toString());
        console.log(response.body.toString())
      }
    }
  })
  )
  
}

createToDo(){
  setTimeout(()=> {this.httpService.createToDoItem('{"name":"'+this.newToDoName+'"}').subscribe(response => {
    window.location.reload();
  })
  
})
  
}
}
