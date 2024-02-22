import { AsyncPipe } from '@angular/common';
import { Component, OnInit, Inject } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ApiRequestService } from '../../services/api-request.service';
import { Animal } from '../../models/animal';

@Component({
  selector: 'app-file-upload-dialog',
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
    MatIconModule,
  ],
  templateUrl: './file-upload-dialog.component.html',
  styleUrl: './file-upload-dialog.component.scss',
})
export class FileUploadDialogComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<FileUploadDialogComponent>,
    private apiRequestService: ApiRequestService,
    @Inject(MAT_DIALOG_DATA) public data: { animal: Animal; type: string }
  ) {}
  uploadedFileName: string = null as any;
  file: File = null as any;

  ngOnInit(): void {}

  onFileNameChanged(newFileName: string) {
    this.uploadedFileName = newFileName;
  }

  onFileSelected(event: any) {
    this.file = event.target.files[0];
  }

  onSubmit() {
    const formData: FormData = new FormData();

    formData.append('Name', this.uploadedFileName);

    formData.append('FormFile', this.file);

    if (this.data.type === 'main') {
      this.postMainImage(formData);
    } else {
      this.postProfileImage(formData);
    }
  }

  postMainImage(formData: FormData) {
    this.apiRequestService
      .postMainImage(this.data.animal.id, formData)
      .subscribe(
        (res) => {
          this.dialogRef.close();
        },
        (err) => {
          console.log(err);
        }
      );
  }

  postProfileImage(formData: FormData) {
    this.apiRequestService
      .postProfileImage(this.data.animal.id, formData)
      .subscribe(
        (res) => {
          this.dialogRef.close();
        },
        (err) => {
          console.log(err);
        }
      );
  }

  onCloseClick(): void {
    this.dialogRef.close();
  }
}
