import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Animal } from '../../../shared/models/animal';
import { ApiRequestService } from '../../../shared/services/api-request.service';
import { CommonModule } from '@angular/common';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDialog } from '@angular/material/dialog';
import { AnimalCreationDto } from '../../../shared/dto/animalDto';
import { AnimalDialogComponent } from '../../../shared/components/animal-dialog/animal-dialog.component';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NativeDateAdapter } from '@angular/material/core';
@Component({
  selector: 'app-animal-details',
  standalone: true,
  imports: [
    CommonModule,
    MatTabsModule,
    MatButtonModule,
    MatGridListModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatDatepickerModule,
  ],
  templateUrl: './animal-details.component.html',
  styleUrl: './animal-details.component.scss',
  providers: [NativeDateAdapter],
})
export class AnimalDetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
  animalId: string = this.route.snapshot.paramMap.get('id')!;

  animal: Animal = null as any;
  selected: Date | null = null;

  constructor(
    private apiService: ApiRequestService,
    private dialog: MatDialog
  ) {}

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

  openAnimalDiaglog(): void {
    if (this.animal) {
      const animalCreationDto: AnimalCreationDto = {
        id: this.animal.id,
        name: this.animal.name,
        breedId: this.animal.breed,
        birthDate: this.animal.birthDate,
        coatColor: this.animal.coatColor,
        coatType: this.animal.coatType,
        animalGenderId: this.animal.animalGenderId,
        animalTypeId: this.animal.animalTypeId,
        isCastrated: this.animal.isCastrated,
        microchipNumber: this.animal.microchipNumber,
      };

      const dialogRef = this.dialog.open(AnimalDialogComponent, {
        data: animalCreationDto,
        hasBackdrop: true,
        disableClose: true,
        closeOnNavigation: true,
      });

      dialogRef.afterClosed().subscribe((result) => {
        // Handle the result (edited or newly created animal)
        if (result) {
          // TODO: Add logic to save the result
        }
      });
    }
  }
}
