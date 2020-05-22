import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TodoService } from '../Services/todo.service';
import { Todo } from '../Models/Todo';

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
    if (name === "") {
      return;
    }
    const newTodo = new Todo();
    newTodo.boardId = boardId;
    newTodo.todoName = name;
    this.todo.NewTodo(newTodo).subscribe(data => this.NewTodoEvent.emit(data));
  }

}
