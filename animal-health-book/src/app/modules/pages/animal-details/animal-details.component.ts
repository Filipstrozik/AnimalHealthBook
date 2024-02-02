import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Animal } from '../../../shared/models/animal';
import { ApiRequestService } from '../../../shared/services/api-request.service';
import { CommonModule } from '@angular/common';
import {MatTabsModule} from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';
import { MatDialog } from '@angular/material/dialog';
import { AnimalCreationDto } from '../../../shared/dto/animalDto';
import { AnimalDialogComponent } from '../../../shared/components/animal-dialog/animal-dialog.component';
@Component({
  selector: 'app-animal-details',
  standalone: true,
  imports: [CommonModule, MatTabsModule, MatButtonModule, MatGridListModule],
  templateUrl: './animal-details.component.html',
  styleUrl: './animal-details.component.scss'
})
export class AnimalDetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
  animalId: string = this.route.snapshot.paramMap.get('id')!;
  
  animal: Animal = null as any;

  constructor(
    private apiService: ApiRequestService,
    private dialog: MatDialog
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

  openAnimalDiaglog(animal?: AnimalCreationDto): void { 


    const dialogRef = this.dialog.open(AnimalDialogComponent, {
      data: animal,
      hasBackdrop: true,
      disableClose: true,
      closeOnNavigation: true,
  });

  dialogRef.afterClosed().subscribe(result => {
    // Handle the result (edited or newly created animal)
    if (result) {
      // TODO: Add logic to save the result
    }
  });
  }
}

