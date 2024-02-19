import { Component, HostBinding, HostListener, OnInit } from '@angular/core';
import { ApiRequestService } from './shared/services/api-request.service';
import { Router } from '@angular/router';
import { AuthService } from './shared/services/auth.service';
import { OverlayContainer } from '@angular/cdk/overlay';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  public isLogged = false;
  public isMobile = false;
  public darkMode = true;

  public switchTheme = new FormControl(false);
  @HostBinding('class') className = '';
  darkClass = 'dark-theme';
  lightClass = 'light-theme';

  constructor(
    private apiRequestService: ApiRequestService,
    private router: Router,
    private authService: AuthService,
    private overlay: OverlayContainer
  ) {}

  ngOnInit(): void {
    this.isLogged = this.authService.getIsLoggedIn();
    this.authService.isLoggedInChanged.subscribe((isLoggedIn: boolean) => {
      this.isLogged = isLoggedIn;
    });

    this.isMobile = window.innerWidth < 768;
    this.applyTheme(this.darkMode);
  }

  toggleSideNav(): void {
    this.isMobile = !this.isMobile;
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any): void {
    this.isMobile = event.target.innerWidth < 768;
    console.log(this.isMobile ? 'mobile' : 'desktop');
  }

  private applyTheme(isDarkMode: boolean): void {
    this.className = isDarkMode ? this.darkClass : this.lightClass;
    const containerElement = this.overlay.getContainerElement();

    if (isDarkMode) {
      containerElement.classList.add(this.className);
    } else {
      containerElement.classList.remove(this.className);
    }
  }

  toggleDarkMode(): void {
    this.darkMode = !this.darkMode;
    this.applyTheme(this.darkMode);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
