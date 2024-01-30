import { Component, Input, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatRippleModule } from '@angular/material/core';
import { ActivatedRoute } from '@angular/router';
import { Animal } from '../../models/animal';

@Component({
  selector: 'app-animal-card',
  standalone: true,
  imports: [
    MatCardModule,
    MatButtonModule,
    MatRippleModule
  ],
  templateUrl: './animal-card.component.html',
  styleUrl: './animal-card.component.scss'
})
export class AnimalCardComponent {

  @Input() animal: Animal = null as any;

  constructor(
    private route: ActivatedRoute
  ) { }
  
}
