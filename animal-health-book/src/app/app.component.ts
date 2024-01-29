import { Component, HostListener } from '@angular/core';
import { ApiRequestService } from './shared/services/api-request.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public isMobile: boolean = false;

  public toggleSideNav() {
    this.isMobile = !this.isMobile;
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    if (event.target.innerWidth < 768) {
      this.isMobile = true;
      console.log('mobile');
    } else {
      this.isMobile = false;
      console.log('desktop');
    }
  }

  constructor(private apiRequestService: ApiRequestService) { 
  }

  onInit() {
  }


  title = 'animal-health-book';
  showFiller = false;
}
