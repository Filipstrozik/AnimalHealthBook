import { Component } from '@angular/core';
import { ApiRequestService } from './shared/services/api-request.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private apiRequestService: ApiRequestService) { 
  }

  title = 'animal-health-book';
  showFiller = false;
}
