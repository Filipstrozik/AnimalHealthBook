export interface AnimalCreationDto {
  id?: string;
  name: string;
  breedId: string;
  animalGenderId: number;
  birthDate: Date;
  coatColor?: string | null;
  coatType?: string | null;
  animalTypeId: string;
  userId?: string;
  isCastrated: boolean;
  microchipNumber?: string | null;
}
