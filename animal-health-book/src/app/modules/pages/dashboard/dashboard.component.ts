import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AnimalCardComponent } from 'src/app/shared/components/animal-card/animal-card.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [AnimalCardComponent, CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {

}
