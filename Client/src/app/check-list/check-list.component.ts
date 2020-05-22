import { Component, OnInit, Input } from '@angular/core';
import { ItemService } from '../Services/item.service';
import { Item } from '../Models/Item';

@Component({
  selector: 'app-check-list',
  templateUrl: './check-list.component.html',
  styleUrls: ['./check-list.component.scss']
})
export class CheckListComponent implements OnInit {

  @Input() todoId: number
  constructor(private item: ItemService) { }
  checkList: Item[] = [];
  Percent: number;
  numberofitem = 0;
  numberOfItemFinished = 0;
  ngOnInit() {
    this.Items(this.todoId);
  }

  Items(Id: number) {
    this.item.GetItems(Id).subscribe(data => {
      this.checkList = data;
      this.CalculatePercent();
    });
  }

  CalculatePercent() {
    this.getNumberOfFinishedItem();
    this.getNumbersOfItem();
    this.Percent = this.numberOfItemFinished / this.numberofitem * 100
  }

  getNumberOfFinishedItem() {
    this.checkList.forEach(item => {
      if (item.isfinished) {
        this.numberOfItemFinished += 1;
      }
    });
  }

  getNumbersOfItem() {
    this.numberofitem = this.checkList.length
  }

  NewItem(Id: number, name: string) {
    if (name === "") {
      return;
    }
    const newItem = new Item();
    newItem.todoid = Id;
    newItem.itemName = name;
    this.item.NewItem(newItem).subscribe(newItem => {
      this.checkList.push(newItem);
      this.CalculatePercent();
    });
  }



  UpdateStatus(Id: number) {

  }


}
