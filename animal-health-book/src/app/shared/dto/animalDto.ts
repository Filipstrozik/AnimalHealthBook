import { AnimalType } from '../models/animalType';
import { Breed } from '../models/breed';
import { CoatColor } from '../models/coatColor';
import { CoatType } from '../models/coatType';

export interface AnimalCreationDto {
  id?: string;
  name: string;
  breed?: Breed;
  breedId: string;
  animalGenderId: number;
  birthDate: Date;
  coatColorId: string;
  coatColor?: CoatColor;
  coatTypeId: string;
  coatType?: CoatType;
  animalTypeId: string;
  animalType?: AnimalType;
  userId?: string;
  isCastrated: boolean;
  microchipNumber?: string | null;
}
