import { Component, OnInit } from '@angular/core';
import { UsersServiceService } from '../../../services/users-service.service'
import { Users } from '../../models/Users';


@Component({
  selector: 'app-list-item',
  templateUrl: './list-item.component.html',
  styleUrls: ['./list-item.component.css']
})
export class ListItemComponent implements OnInit {

  _users: Users[];


  constructor(private userService: UsersServiceService) { }

  ngOnInit() {
    this.userService.getUsers().subscribe(users => {
      this._users = users;
    });
  }

}
