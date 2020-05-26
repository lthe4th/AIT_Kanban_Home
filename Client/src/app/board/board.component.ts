import { Component, OnInit } from '@angular/core';
import { Board } from '../Models/Board';
import { BoardService } from '../Services/board.service';
import { MatDialog } from '@angular/material/dialog'
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';
import swal from 'sweetalert2'
@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent implements OnInit {

  boards: Board[] = []
  show_mobile_greeting_new_input_filed: true
  constructor(
    private board: BoardService,
    public diaglog: MatDialog,
  ) { }

  ngOnInit() {
    this.Boards();
  }

  Boards(): void {
    this.board.Boards().subscribe(data => {
      this.boards = data;
    });

  }


  NewBoard(name: string) {
    if (name === "") {
      swal.fire(
        { title: "THAT cant\' be empty", text: "type again ?", icon: "warning", heightAuto: false }
      );
      return;
    }
    name.trim();
    var newBoard = new Board()
    newBoard = new Board();
    newBoard.boardName = name;
    this.board.NewBoard(newBoard).subscribe(NewBoard => this.boards.push(NewBoard));
    // this.board.NewBoard(newBoard);
  }

  ModBoard(name: string, id: number) {
    const dialogRef = this.diaglog.open(ConfirmDialogComponent, {
      width: "500px",
      height: "200px",
      data: {name: name, id : id}
    })
    dialogRef.afterClosed().subscribe(modBoard => {
      if (!modBoard) {
        return;
      }
      this.boards.filter(board => {
        if (board.id === modBoard.id) {
          board.boardName = modBoard.boardName;
        }
      })
    })
  }

  DeleteBoard(Id: number) {
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
      if (result.value) {
        this.board.DeleteBoard(Id).subscribe(result => {
          if (result) {
            this.boards = this.boards.filter(each => each.id !== Id)
            swal.fire({
              title: 'Deleted!',
              text: 'Your file has been deleted.',
              icon: 'success',
              heightAuto: false
            })
          }
        })
      }

    })
  }

  DeleteEveryThing() {
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
      if (result.value) {
        this.board.DeleteEverything().subscribe(result => {
          if (result) {
            swal.fire({
              title: 'Deleted!',
              text: 'Your file has been deleted.',
              icon: 'success',
              heightAuto: false
            })
            this.boards = []
          }
        })
      }

    })
  }



}
