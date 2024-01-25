import { Animal } from "./animal";

export interface HealthNote {
    id: string;
    description: string;
    date: string;
    animalId: string;
    animal: Animal;
}