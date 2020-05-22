import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Todo } from '../Models/Todo';
import { ItemService } from '../Services/item.service';
import { Item } from '../Models/Item';


@Component({
  selector: 'app-todo-detail',
  templateUrl: './todo-detail.component.html',
  styleUrls: ['./todo-detail.component.scss']
})
export class TodoDetailComponent implements OnInit {

  constructor(
    public diaglogRef: MatDialogRef<TodoDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Todo
  ) { }


  ngOnInit() {
    
  }

 

}
