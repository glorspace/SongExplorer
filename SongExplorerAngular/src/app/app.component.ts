import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SongExplorerAngular';
  screenWidth: number = window.innerWidth;

  constructor(){

  }

  ngOnInit() {
    this.screenWidth = window.innerWidth;

    window.onresize = () => { this.windowResize(); };

    this.loadData();
  }

  loadData() {
    this.title='Welcome to the Song Explorer - Angular App!!';
  }

  windowResize(): void {
    this.screenWidth = window.innerWidth;
  }
}
