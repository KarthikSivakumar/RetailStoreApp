import { Component } from '@angular/core';
import { ModalService } from 'src/services/modal/modal.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(protected modalService:ModalService){}
}
