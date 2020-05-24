import { TodoService } from './../Services/todo.service';
import { Component, OnInit } from '@angular/core';
import { Board } from '../Models/Board';
import { BoardService } from '../Services/board.service';
import { MatDialog } from '@angular/material/dialog'
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';
import { CC } from '../Models/ConfirmFormCase';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent implements OnInit {

  boards: Board[] = []
  CC = new CC();
  origin = new Board();
  constructor(
    private board: BoardService,
    public diaglog: MatDialog
  ) { }

  ngOnInit() {
    this.Board();
  }

  Board(): void {
    this.board.Boards().subscribe(data => {
      this.boards = data;
    });
    console.log(`fetched data`);
  }

  NewBoard(name: string) {
    if (name === "") {
      return;
    }
    name.trim();
    this.origin = new Board();
    this.origin.boardName = name;
    this.board.NewBoard(this.origin).subscribe(NewBoard => this.boards.push(NewBoard));
    // this.board.NewBoard(newBoard);
  }

  ModBoard(name: string, id: number) {
    this.origin = new Board();
    this.origin.boardName = name;
    this.origin.id = id

    this.CC.Id = 2;
    const dialogRef = this.diaglog.open(ConfirmDialogComponent, {
      width: "500px",
      height: "400px",
      data: { board: this.origin, CC: this.CC, todo: null }
    })
    dialogRef.afterClosed().subscribe(modBoard =>this.boards.filter(board => {
      if(board.id === modBoard.id){
        board.boardName = modBoard.boardName;
      }
    }))
  }

  DeleteBoard(Id: number) {
    this.CC.Id = 1;
    console.log(Id)
    console.log(this.CC.Id);
    const dialogRef = this.diaglog.open(ConfirmDialogComponent, {
      width: "500px",
      height: "400px",
      data: { CC: this.CC, board: null, todo: null }
    })
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.board.DeleteBoard(Id).subscribe(result => this.boards = this.boards.filter(eachboard => eachboard.id !== Id));
      }
    })
  }



}
