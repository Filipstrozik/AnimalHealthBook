import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedIn: boolean = false;
  public isLoggedInChanged: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() { }

  login(token: string): void {
    localStorage.setItem('token', token);
    this.isLoggedIn = true;
    this.isLoggedInChanged.emit(this.isLoggedIn);
  }

  logout(): void {
    localStorage.removeItem('token');
    this.isLoggedIn = false;
    this.isLoggedInChanged.emit(this.isLoggedIn);
  }

  getIsLoggedIn(): boolean {
    const token = localStorage.getItem('token');
    if (token) {
      this.isLoggedIn = true;
    } else {
      this.isLoggedIn = false;
    }
    return this.isLoggedIn;
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getUserId(): string | null {
    const token = localStorage.getItem('token');
    if (token) {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload.unique_name;
    } else {
      return null;
    }
  }
}
