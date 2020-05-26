import { Todo } from './../Models/Todo';
import { Component, OnInit, Input } from '@angular/core';
import { TodoService } from '../Services/todo.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TodoDetailComponent } from '../todo-detail/todo-detail.component';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import swal from 'sweetalert2'

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

  deleteTodo(Id: number) {
    swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
      heightAuto: false
    }).then((result) => {
      if (result.value)
        this.todo.deleteTodo(Id).subscribe(result => {
          this.todos = this.todos.filter(each => each.id !== Id)
          if (result) {
            swal.fire({
              title:'Deleted!',
              text:'Your file has been deleted.',
              icon:'success',
              heightAuto:false
            })
          }
        })

    })
  }

  drop(event: CdkDragDrop<Todo[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
      // console.log(event.previousContainer.data)
      this.moveFilter();
    }
  }

  moveFilter() {
    var movedTodo: Todo;
    this.todos.filter(each => {
      if (each.boardId !== this.Id) {
        movedTodo = each;
      }
    })
    movedTodo.boardId = this.Id;
    this.todo.ModTodo(movedTodo).subscribe();
  }

  getTodoColor(prio: number) {
    var color: string;
    if (prio === 1) {
      color = "warn"
    }
    if (prio === 2) {
      color = "primary"
    }
    return color;
  }

  changeColor(prio: number, id: number) {
    var Tochange: Todo;
    this.todos.filter(each => {
      if (each.id === id) {
        Tochange = each;
        each.prio = prio;
      }
    })
    this.todo.ModTodo(Tochange).subscribe();
  }
}
