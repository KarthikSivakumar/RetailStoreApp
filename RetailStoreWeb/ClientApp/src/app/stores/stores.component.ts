import { Component } from '@angular/core';

@Component({
  selector: 'app-stores-component',
  templateUrl: './stores.component.html'
})
export class StoresComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
