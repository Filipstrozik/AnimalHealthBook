import { Procedure } from "./procedure";
import { Vet } from "./vet";
import { Clinic } from "./clinic";
import { Animal } from "./animal";

export interface Appointment {
    id: string;
    vetId: string;
    clinicId: string;
    animalId: string;
    date: string;
    description: string | null;
    procedures: Procedure[];
    vet: Vet;
    clinic: Clinic;
    animal: Animal;
}