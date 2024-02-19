import { Component, Input, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatRippleModule } from '@angular/material/core';
import { ActivatedRoute } from '@angular/router';
import { Animal } from '../../models/animal';
import { ApiRequestService } from '../../services/api-request.service';

@Component({
  selector: 'app-animal-card',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, MatRippleModule],
  templateUrl: './animal-card.component.html',
  styleUrl: './animal-card.component.scss',
})
export class AnimalCardComponent {
  @Input() animal: Animal = null as any;
  imageUrl: string = 'YOUR_BACKEND_IMAGE_ENDPOINT';
  profileImageUrl: string = '';

  constructor(
    private route: ActivatedRoute,
    private apiRequestService: ApiRequestService
  ) {}

  ngOnInit(): void {
    this.loadImage();
  }

  loadImage(): void {
    if (!this.animal.mainImageId) return;
    this.apiRequestService.getImage(this.animal.mainImageId).subscribe(
      (data: Blob) => {
        const reader = new FileReader();
        reader.onloadend = () => {
          // Convert the blob to a data URL and set it as the image source
          this.imageUrl = reader.result as string;
        };
        reader.readAsDataURL(data);
      },
      (error) => {
        console.error('Failed to load image', error);
      }
    );

    if (this.animal.profileImageId) {
      this.apiRequestService.getImage(this.animal.profileImageId).subscribe(
        (data: Blob) => {
          const reader = new FileReader();
          reader.onloadend = () => {
            // Convert the blob to a data URL and set it as the image source
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
}
