import { AnimalType } from '../models/animalType';
import { Breed } from '../models/breed';

export interface AnimalCreationDto {
  id?: string;
  name: string;
  breed?: Breed;
  breedId: string;
  animalGenderId: number;
  birthDate: Date;
  coatColor?: string | null;
  coatType?: string | null;
  animalTypeId: string;
  animalType?: AnimalType;
  userId?: string;
  isCastrated: boolean;
  microchipNumber?: string | null;
}
