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
    const newBoard = new Board();
    newBoard.boardName = name;
    this.board.NewBoard(newBoard).subscribe(NewBoard => this.boards.push(NewBoard));
    // this.board.NewBoard(newBoard);
  }

  DeleteBoard(Id: number) {
    this.CC.Id = 1;
    const dialogRef = this.diaglog.open(ConfirmDialogComponent, {
      width: "500px",
      height: "400px",
      data: this.CC
    })
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.board.DeleteBoard(Id).subscribe(result => this.boards = this.boards.filter(eachboard => eachboard.id !== Id));
      }
    })
  }



}
