import { Component, HostListener } from '@angular/core';
import { ApiRequestService } from './shared/services/api-request.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public isLogged: boolean = false;
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

  constructor(private apiRequestService: ApiRequestService, private router: Router) { 
    const token = localStorage.getItem('token');
    if (token) {
      this.isLogged = true;
    } else {
      //route to login page
      this.router.navigate(['/login']);
    }
  }

  logout():void {
    localStorage.removeItem('token');
    this.isLogged = false;
    this.router.navigate(['/login']);
  }

  title = 'animal-health-book';
  showFiller = false;
}
