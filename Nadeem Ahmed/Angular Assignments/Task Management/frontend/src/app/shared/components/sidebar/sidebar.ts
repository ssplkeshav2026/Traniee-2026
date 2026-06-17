import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  templateUrl: './sidebar.html'
})
export class Sidebar implements OnInit {

  userRole = '';

  ngOnInit(): void {

    const user = JSON.parse(
      localStorage.getItem('user') || '{}'
    );

    this.userRole = user.role;

  }

}