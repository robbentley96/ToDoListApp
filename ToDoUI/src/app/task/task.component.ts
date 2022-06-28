import { Component, OnInit, Input } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
  }
  @Input() taskId=0;
  @Input() taskName = "";

  deleteTask(){
    setTimeout(()=> this.httpService.deleteTaskItem('{"id":'+this.taskId+'}').subscribe(response => {
      window.location.reload();
    })
  )
  }
}
