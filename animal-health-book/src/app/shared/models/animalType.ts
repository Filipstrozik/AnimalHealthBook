import { Breed } from './breed';

export interface AnimalType {
  id: string;
  name: string;
  breeds: Breed[];
}
