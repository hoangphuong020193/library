import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app',
  encapsulation: ViewEncapsulation.None,
  templateUrl: 'app.component.html'
})

export class AppComponent implements OnInit {
  constructor() { }

  public ngOnInit(): void { }
}