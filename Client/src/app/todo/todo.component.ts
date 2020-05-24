import { Todo } from './../Models/Todo';
import { Component, OnInit, Input } from '@angular/core';
import { TodoService } from '../Services/todo.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TodoDetailComponent } from '../todo-detail/todo-detail.component';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.scss']
})
export class TodoComponent implements OnInit {

  @Input() Id: number
  constructor(private todo: TodoService, public dialog: MatDialog) { }

  todos: Todo[] = []

  ngOnInit() {
    this.Todos(this.Id);
  }

  Todos(Id: number) {
    this.todo.Todos(Id).subscribe(data => this.todos = data);
  }

  OpenDetail(toSend: Todo) {
    const dialogRef = this.dialog.open(TodoDetailComponent, {
      data: toSend,
      width: "80vw",
      height: "80vh"
    })
    dialogRef.afterClosed().subscribe(data => {
      if (typeof (data) === "number") {
        this.todos = this.todos.filter(each => each.id !== data)
      }
      else if (typeof (data) === "object") {
        this.todos.filter(each => {
          if (each.id = data.id) {
            each.todoName = data.todoName
          }
        })
      }
    })
  }

  ReceivedNewTodo($event: Todo) {
    this.todos.push($event)
  }
}
