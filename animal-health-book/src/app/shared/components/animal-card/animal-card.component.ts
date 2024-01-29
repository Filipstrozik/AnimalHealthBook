import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-animal-card',
  standalone: true,
  imports: [MatCardModule, MatButtonModule],
  templateUrl: './animal-card.component.html',
  styleUrl: './animal-card.component.scss'
})
export class AnimalCardComponent {

}
