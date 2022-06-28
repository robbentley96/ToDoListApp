import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  createToDoItem(body: string){
    return this.http.post(environment.CreateToDoItemUrl, body, {responseType:'text' as 'json', observe: 'response'});
  }

  createTaskItem(body: string){
    return this.http.post(environment.CreateTaskItemUrl, body, {responseType:'text' as 'json', observe: 'response'});
  }

  deleteToDoItem(body: string){
    return this.http.post(environment.DeleteToDoItemUrl, body, {responseType:'text' as 'json', observe: 'response'});
  }

  deleteTaskItem(body: string){
    return this.http.post(environment.DeleteTaskItemUrl, body, {responseType:'text' as 'json', observe: 'response'});
  }

  getToDoItems(){
    return this.http.get(environment.GetToDoItemsUrl, {responseType:'text' as 'json', observe: 'response'});
  }
}


