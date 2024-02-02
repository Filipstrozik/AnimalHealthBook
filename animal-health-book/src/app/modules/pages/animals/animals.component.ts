import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AnimalCardComponent } from '../../../shared/components/animal-card/animal-card.component';
import { RouterModule } from '@angular/router';
import { ApiRequestService } from '../../../shared/services/api-request.service';
import { Animal } from '../../../shared/models/animal';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { AnimalCreationDto } from '../../../shared/dto/animalDto';
import { AnimalDialogComponent } from '../../../shared/components/animal-dialog/animal-dialog.component';
import { MatDialog } from '@angular/material/dialog';

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
    private apiService: ApiRequestService,
    public dialog: MatDialog
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
