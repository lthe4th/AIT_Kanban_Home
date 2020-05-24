import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, OnInit, Inject } from '@angular/core';
import { CC } from '../Models/ConfirmFormCase';
import { Board } from '../Models/Board';
import { BoardService } from '../Services/board.service';
import { Todo } from '../Models/Todo';

export interface data {
  CC : CC
  board : Board
  todo : Todo
}

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.scss']
})
export class ConfirmDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private board  : BoardService
  ) { }

  ngOnInit() {
  }

  result = true;
  boardWithNewnName : Board;


  ModName(name : string){
    if(name === this.data.board.boardName || name === ""){
      return;
    }
    var newboard = new Board();
    newboard.boardName = name;
    newboard.id = this.data.board.id;
    this.board.ModBoard(newboard).subscribe(modedBoard => {
    this.dialogRef.close(modedBoard);
    });

  }

}
