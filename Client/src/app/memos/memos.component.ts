import { Component, OnInit, Input } from '@angular/core';
import { MemosService } from '../Services/memos.service';
import { memo } from '../Models/memos';
import swal from 'sweetalert2'
import { of } from 'rxjs';

@Component({
  selector: 'app-memos',
  templateUrl: './memos.component.html',
  styleUrls: ['./memos.component.scss']
})
export class MemosComponent implements OnInit {
  constructor(private memo: MemosService) { }
  memoList: memo[] = [];
  ngOnInit() {
    this.getMemos();
  }

  getMemos() {
    this.memo.GetMemo().subscribe(data => this.memoList = data);
  }

  openMemoBox() {
    swal.fire({
      title: 'sOMe tHIng tO REmeMBer',
      input: 'text',
      inputValue: name,
      showCancelButton: true,
      heightAuto: false,
      inputValidator: (value) => {
        if (!value) {
          return 'You need to write something!'
        }
        this.newMemos(value);
      }
    })
  }

  delete(id:number) {
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
        this.memo.DeleteMemo(id).subscribe(result => {
          if (result) {
            this.memoList = this.memoList.filter(each => each.id !== id)
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


  newMemos(text: string) {
    var _memo = new memo();
    _memo.content = text;
    this.memo.NewMemo(_memo).subscribe(data => this.memoList.push(data))
  }


}
