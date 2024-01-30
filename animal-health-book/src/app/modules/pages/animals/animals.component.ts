import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AnimalCardComponent } from '../../../shared/components/animal-card/animal-card.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-animals',
  standalone: true,
  imports: [AnimalCardComponent, CommonModule, RouterModule],
  templateUrl: './animals.component.html',
  styleUrl: './animals.component.scss'
})
export class AnimalsComponent {

}
