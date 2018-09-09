import { Component, OnInit } from '@angular/core';
import { AlertService } from '../core/alert/alert.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private alertService: AlertService) { }

  ngOnInit() {
    this.alertService.success("This is an example of an alert in the system.  It can be dismissed and only displays when there is a message.");
  }

}
