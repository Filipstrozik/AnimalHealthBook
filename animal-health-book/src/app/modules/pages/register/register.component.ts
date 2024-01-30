import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { ApiRequestService } from '../../../shared/services/api-request.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports:
    [
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
    CommonModule
    ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';
  hide = true;

  register() {
    console.log(`First Name: ${this.firstName} Last Name: ${this.lastName} Email: ${this.email} Password: ${this.password} Confirm Password: ${this.confirmPassword}`);
    const registerData = {
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.email,
      password: this.password
    }

    this.apiService.register(registerData).subscribe((response: any) => {
      console.log(response);
    });
  }

  constructor(
    private apiService: ApiRequestService,
  ) { }
}
