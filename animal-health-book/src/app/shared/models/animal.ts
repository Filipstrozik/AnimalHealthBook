import { Gender } from "./gender";
import { AnimalType } from "./animalType";
import { User } from "./user";
import { Appointment } from "./appointment";
import { HealthNote } from "./healthNote";

export interface Animal {
    id: string;
    name: string;
    breed: string;
    animalGenderId: number;
    animalGender: Gender;
    birthDate: Date;
    coatColor: string | null;
    coatType: string | null;
    animalTypeId: string;
    animalType: AnimalType;
    users: User[];
    isCastrated: boolean;
    microchipNumber: string | null;
    appointments: Appointment[];
    healthNotes: HealthNote[];
}