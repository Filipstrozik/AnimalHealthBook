import { Gender } from './gender';
import { AnimalType } from './animalType';
import { User } from './user';
import { Appointment } from './appointment';
import { HealthNote } from './healthNote';
import { Breed } from './breed';
import { CoatColor } from './coatColor';
import { CoatType } from './coatType';
import { UploadFile } from './uploadFile';

export interface Animal {
  id: string;
  name: string;
  breedId: string;
  breed: Breed;
  animalGenderId: number;
  animalGender: Gender;
  birthDate: Date;
  coatColorId: string;
  coatColor: CoatColor;
  coatTypeId: string;
  coatType: CoatType;
  animalTypeId: string;
  animalType: AnimalType;
  users: User[];
  isCastrated: boolean;
  microchipNumber: string | null;
  appointments: Appointment[];
  healthNotes: HealthNote[];
  profileImageId?: string;
  profileImage?: UploadFile;
  mainImageId?: string;
  mainImage?: UploadFile;
}
