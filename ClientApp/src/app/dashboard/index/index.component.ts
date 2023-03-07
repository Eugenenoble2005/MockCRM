import { Component, OnInit } from '@angular/core';
import { User } from '../../../Entities/User';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
  public user?: User
  constructor(public userService: UserService) {

  }
  ngOnInit(): void {
    this.userService.user().subscribe(user => {
      this.user = user
      console.log(user)
    })
    }

}
