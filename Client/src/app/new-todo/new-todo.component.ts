import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TodoService } from '../Services/todo.service';
import { Todo } from '../Models/Todo';
import swal from 'sweetalert2'
@Component({
  selector: 'app-new-todo',
  templateUrl: './new-todo.component.html',
  styleUrls: ['./new-todo.component.scss']
})
export class NewTodoComponent implements OnInit {
  @Input() BoardId: number;
  @Output() NewTodoEvent = new EventEmitter<Todo>();

  constructor(private todo: TodoService) { }

  ngOnInit() {
  }

  newTodo(name: string, boardId: number) {
    if (name.trim() === "") {
      swal.fire(
        {
          title: "Uh oh,We need a name for that",
          input: 'text',
          inputValue: name,
          showCancelButton: true,
          icon: "warning",
          heightAuto: false,
          inputValidator: (value) => {
            if (!value) {
              return 'You need to write something!'
            }
            if (value.trim() === "") {
              return 'You need to write something!'
            }
            else {
              var newTodo = new Todo()
              newTodo.boardId = boardId;
              newTodo.todoName = value;
              this.todo.NewTodo(newTodo).subscribe(data => this.NewTodoEvent.emit(data));
            }
          }

        }
      )
      return;
    }
    const newTodo = new Todo();
    newTodo.boardId = boardId;
    newTodo.todoName = name;
    this.todo.NewTodo(newTodo).subscribe(data => this.NewTodoEvent.emit(data));
  }

}
