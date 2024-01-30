import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ApiRequestService } from '../../../shared/services/api-request.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
    CommonModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  hide = true;

  // Add the following properties for email and password
  email: string = '';
  password: string = '';

  constructor(
    private apiService: ApiRequestService,
    private router: Router
  ) {}

  login() {
    // Add the following code to the login method
    console.log(`Email: ${this.email} Password: ${this.password}`);
    const loginData = {
      email: this.email,
      password: this.password
    };

    this.apiService.login(loginData).subscribe(
      (res) => {
        console.log(res);
        localStorage.setItem('token', res.token);
        this.router.navigate(['/home']);
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
