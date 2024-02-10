import {
  Component,
  ElementRef,
  Inject,
  OnInit,
  ViewChild,
} from '@angular/core';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
  MatDialogTitle,
} from '@angular/material/dialog';
import { AnimalCreationDto } from '../../dto/animalDto';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MatNativeDateModule } from '@angular/material/core';
import { ApiRequestService } from '../../services/api-request.service';
import { AnimalType } from '../../models/animalType';
import { AuthService } from '../../services/auth.service';
import { Breed } from '../../models/breed';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { Observable, map, of, startWith } from 'rxjs';
import { AsyncPipe } from '@angular/common';

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
    MatSelectModule,
    MatAutocompleteModule,
    FormsModule,
    ReactiveFormsModule,
    AsyncPipe,
  ],
  templateUrl: './animal-dialog.component.html',
  styleUrl: './animal-dialog.component.scss',
})
export class AnimalDialogComponent implements OnInit {
  animal: AnimalCreationDto = {} as AnimalCreationDto;
  animalTypes: AnimalType[] = [];
  breeds: Breed[] = [];
  myControl = new FormControl();
  filteredBreeds: Observable<Breed[]> = new Observable<Breed[]>();
  @ViewChild('input') input: ElementRef<HTMLInputElement> =
    {} as ElementRef<HTMLInputElement>;

  constructor(
    public dialogRef: MatDialogRef<AnimalDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AnimalCreationDto,
    private apiService: ApiRequestService,
    private authService: AuthService
  ) {
    if (data) {
      this.animal = { ...data };
      debugger;
      this.breeds = this.animal.animalType!.breeds;
      this.myControl.setValue(data.breed);
    }
    this.apiService.getAnimalTypes().subscribe((res) => {
      this.animalTypes = res;
      this.breeds = this.animalTypes.find(
        (a) => a.id === this.animal.animalTypeId
      )!.breeds;
    });
  }

  ngOnInit() {
    this.filteredBreeds = this.myControl.valueChanges.pipe(
      startWith(''),
      map((value: string) => this._filter(value))
    );
  }

  onTypeChange(arg0: any) {
    const selectedAnimalType = this.animalTypes.find(
      (x) => x.id === this.animal.animalTypeId
    );
    if (selectedAnimalType) {
      this.breeds = selectedAnimalType.breeds;
      this.filteredBreeds = this.myControl.valueChanges.pipe(
        startWith(''),
        map((value: string) => this._filter(value))
      );
    }
  }

  public _filter(value: any): Breed[] {
    if (typeof value === 'string') {
      const filterValue = value.toLowerCase();

      return this.breeds.filter((breed) =>
        breed.name.toLowerCase().includes(filterValue)
      );
    }
    return this.breeds;
  }

  public filter(): void {
    const filterValue = this.input.nativeElement.value;
    debugger;
    this._filter(filterValue);
  }

  breedDisplayFn(breed: Breed): string {
    return breed && breed.name ? breed.name : '';
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  onSaveClick(): void {
    const userId = this.authService.getUserId();
    if (userId) {
      this.animal.userId = userId;
      debugger;
      this.animal.breedId = this.myControl.value.id;
      this.apiService.createAnimal(this.animal).subscribe((res) => {
        console.log(res);
      });
    } else {
      // show allert or something
      return;
    }

    this.dialogRef.close(this.animal);
  }
}
