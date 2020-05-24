import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { Todo } from '../Models/Todo';
import { ItemService } from '../Services/item.service';
import { Item } from '../Models/Item';
import { TodoService } from '../Services/todo.service';
import { CC } from '../Models/ConfirmFormCase';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';


@Component({
  selector: 'app-todo-detail',
  templateUrl: './todo-detail.component.html',
  styleUrls: ['./todo-detail.component.scss']
})
export class TodoDetailComponent implements OnInit {
  CC = new CC()
  constructor(
    public diaglogRef: MatDialogRef<TodoDetailComponent>,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public data: Todo,
    private todo: TodoService
  ) { }

  ngOnInit() {

  }

  deleteThisTask() {
    this.CC.Id = 1;
    const DialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: "400px",
      height: "300px",
      data: { CC: this.CC, board: null, todo: this.data }
    })
    DialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.todo.deleteTodo(this.data.id).subscribe(result => {
          this.diaglogRef.close(this.data.id)
        })
      }
    })
  }

  changeTodoName(name: string) {
    if(name === ""){
      return;
    }
    var modTodo = new Todo();
    modTodo.id = this.data.id;
    modTodo.todoName = name;
    modTodo.prio = this.data.prio;
    modTodo.deadline = this.data.deadline;
    modTodo.deadLineStatus = this.data.deadLineStatus;
    modTodo.boardId = this.data.boardId;
    this.todo.ModTodo(modTodo).subscribe(data => {
      this.diaglogRef.close(data);
    })
  }


}
