import { Component, inject } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
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
import { DocumentsComponent } from '../../../shared/components/documents/documents.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FileUploadDialogComponent } from '../../../shared/components/file-upload-dialog/file-upload-dialog.component';

@Component({
  selector: 'app-animal-details',
  standalone: true,
  templateUrl: './animal-details.component.html',
  styleUrl: './animal-details.component.scss',
  providers: [NativeDateAdapter],
  imports: [
    CommonModule,
    MatTabsModule,
    MatButtonModule,
    MatGridListModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatDatepickerModule,
    DocumentsComponent,
  ],
})
export class AnimalDetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
  animalId: string = this.route.snapshot.paramMap.get('id')!;

  mainImageUrl: string = '';
  profileImageUrl: string = '';

  animal: Animal = null as any;
  selected: Date = null as any;

  constructor(
    private apiService: ApiRequestService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadAnimal();
  }

  loadAnimal(): void {
    this.apiService.getAnimal(this.animalId).subscribe(
      (res) => {
        this.animal = res;
        this.loadImage();
      },
      (err) => {
        console.log(err);
      }
    );
  }

  loadImage(): void {
    if (!this.animal.mainImageId) return;
    this.apiService.getImage(this.animal.mainImageId).subscribe(
      (data: Blob) => {
        const reader = new FileReader();
        reader.onloadend = () => {
          this.mainImageUrl = reader.result as string;
        };
        reader.readAsDataURL(data);
      },
      (error) => {
        console.error('Failed to load image', error);
      }
    );

    if (this.animal.profileImageId) {
      this.apiService.getImage(this.animal.profileImageId).subscribe(
        (data: Blob) => {
          const reader = new FileReader();
          reader.onloadend = () => {
            this.profileImageUrl = reader.result as string;
          };
          reader.readAsDataURL(data);
        },
        (error) => {
          console.error('Failed to load image', error);
        }
      );
    }
  }

  openAnimalDiaglog(): void {
    if (this.animal) {
      const animalCreationDto: AnimalCreationDto = {
        id: this.animal.id,
        name: this.animal.name,
        breedId: this.animal.breed.id,
        breed: this.animal.breed,
        birthDate: this.animal.birthDate,
        coatColorId: this.animal.coatColorId,
        coatTypeId: this.animal.coatTypeId,
        animalGenderId: this.animal.animalGenderId,
        animalTypeId: this.animal.animalTypeId,
        animalType: this.animal.animalType,
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
        if (result) {
          this.apiService.getAnimal(this.animalId).subscribe(
            (res) => {
              this.animal = res;
            },
            (err) => {
              console.log(err);
            }
          );
        }
      });
    }
  }

  deleteAnimal(): void {
    this.apiService.deleteAnimal(this.animalId).subscribe(
      (res) => {
        this.router.navigate(['/animals']);

        this.snackBar.open('Animal deleted', 'Close', {
          duration: 5000,
        });
      },
      (err) => {
        console.log(err);
      }
    );
  }

  openFileUploadDialog(type: string): void {
    const dialogRef = this.dialog.open(FileUploadDialogComponent, {
      width: 'auto', // adjust the width as needed
      data: {
        animal: this.animal,
        type: type,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.loadAnimal();
    });
  }
}
