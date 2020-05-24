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
  percentOfFinished: number;
  // numberofitem = 0;
  // numberOfItemFinished = 0;
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
    var count = 0;
    this.checkList.forEach(element => {
      if (element.isfinished) {
        count = count + 1;
      }
    });
    this.percentOfFinished = count / this.checkList.length * 100

    // this.percentOfFinished = this.numberOfItemFinished/this.numberofitem*100
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



  UpdateStatus(name: string, id: number, status: boolean) {
    const item2 = new Item();
    item2.id = id;
    item2.itemName = name;
    item2.isfinished = status;
    // console.log(`${JSON.stringify(item2)}`)
    this.item.ModItem(item2).subscribe(result => this.checkList.filter(each => {
      if (each.id === item2.id) {
        each.isfinished = !each.isfinished;
        this.CalculatePercent();
      }
    }))

  }


}
