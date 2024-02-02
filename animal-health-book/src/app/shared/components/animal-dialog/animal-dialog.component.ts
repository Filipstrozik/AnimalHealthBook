import { Component, Inject  } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogContent, MatDialogActions, MatDialogClose, MatDialogTitle } from '@angular/material/dialog';
import { AnimalCreationDto } from '../../dto/animalDto';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MatNativeDateModule } from '@angular/material/core';
import { ApiRequestService } from '../../services/api-request.service';
import { AnimalType } from '../../models/animalType';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-animal-dialog',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose, 
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule
  ],
  templateUrl: './animal-dialog.component.html',
  styleUrl: './animal-dialog.component.scss'
})
export class AnimalDialogComponent {
  animal: AnimalCreationDto;
  animalTypes: AnimalType[] = [];

  constructor(
    public dialogRef: MatDialogRef<AnimalDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AnimalCreationDto,
    private apiService: ApiRequestService,
    private authService: AuthService
  ) {
    // Clone the data to avoid modifying the original object
    this.animal = { ...data };
    this.apiService.getAnimalTypes().subscribe((res) => {
      this.animalTypes = res;
      });
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  onSaveClick(): void {
    
    // TODO: Add save logic here
    debugger
    const userId = this.authService.getUserId();
    if (userId) {
      this.animal.userId = userId;
      this.apiService.createAnimal(this.animal).subscribe((res) => {
        console.log(res);
      });
    }
    else {
      // show allert or something
      return;
    }

    this.dialogRef.close(this.animal);
  }

}
