import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { first } from 'rxjs/operators';
import { Router } from '../../../../node_modules/@angular/router';
import { AlertService } from '../../core/alert/alert.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent implements OnInit {

  constructor(private router: Router, private authenticationService: AuthenticationService, private alertService: AlertService) { }

  ngOnInit() {

  }

  private logout(): void {
    this.authenticationService.logout()
    .pipe(first())
    .subscribe(
      data => {
        this.alertService.success('You have been logged out.  Log back in to access the awesome');
        this.router.navigate(['/login']);
      },
      error => {

      }
    )
  }
}
