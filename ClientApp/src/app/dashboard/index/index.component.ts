import { Component, OnInit } from '@angular/core';
import { User } from '../../../Entities/User';
import { DataService } from '../../services/data.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
  public user?: User
  public data?: any
  displayedColumns: string[] = ['name', 'quantity', 'age', 'distributorName'];
  constructor(public userService: UserService, public dataService: DataService) {

  }
  ngOnInit(): void {
    this.userService.user().subscribe(user => {
      this.user = user
      console.log(user)
    })
    this.getData()
    }
  AddData(data: Array<any>) {
    this.dataService.create(data).subscribe(rez => {
      console.log(rez);
      if (!rez.status) {
        alert("Validation Failed. Please Ensure you filled every field");
      }
      else {
        alert("Data added succesfully");
        this.getData();
      }
    })
  }
  getData() {
    this.dataService.get().subscribe(rez => {
      console.log(rez);
      this.data = rez;
    })
    }
}
