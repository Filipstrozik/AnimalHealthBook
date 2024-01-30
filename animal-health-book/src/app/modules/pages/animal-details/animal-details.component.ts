import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Animal } from '../../../shared/models/animal';
import { ApiRequestService } from '../../../shared/services/api-request.service';
import { CommonModule } from '@angular/common';
import {MatTabsModule} from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
@Component({
  selector: 'app-animal-details',
  standalone: true,
  imports: [CommonModule, MatTabsModule, MatButtonModule],
  templateUrl: './animal-details.component.html',
  styleUrl: './animal-details.component.scss'
})
export class AnimalDetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
  animalId: string = this.route.snapshot.paramMap.get('id')!;
  
  animal: Animal = null as any;

  constructor(
    private apiService: ApiRequestService
  ) { }

  ngOnInit(): void {
    this.apiService.getAnimal(this.animalId).subscribe(
      (res) => {
        this.animal = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}

