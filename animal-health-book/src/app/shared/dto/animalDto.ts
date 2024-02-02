export interface AnimalCreationDto {
  name: string;
  breed: string;
  animalGenderId: number;
  birthDate: Date;
  coatColor?: string | null;
  coatType?: string | null;
  animalTypeId: string;
  userId: string;
  isCastrated: boolean;
  microchipNumber?: string | null;
}
