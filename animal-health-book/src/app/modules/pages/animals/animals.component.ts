import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AnimalCardComponent } from '../../../shared/components/animal-card/animal-card.component';
import { RouterModule } from '@angular/router';
import { ApiRequestService } from '../../../shared/services/api-request.service';
import { Animal } from '../../../shared/models/animal';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-animals',
  standalone: true,
  imports: [AnimalCardComponent, CommonModule, RouterModule, MatIconModule, MatButtonModule],
  templateUrl: './animals.component.html',
  styleUrl: './animals.component.scss'
})
export class AnimalsComponent implements OnInit{

  //animals array
  public animals: Animal[] = [];

  constructor(
    private apiService: ApiRequestService
  ) { }
  
  ngOnInit(): void {
    this.apiService.getAnimals().subscribe(
      (res) => {
        this.animals = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
  
}
