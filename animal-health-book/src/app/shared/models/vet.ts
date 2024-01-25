import { Clinic } from "./clinic";
import { Appointment } from "./appointment";
import { User } from "./user";

export interface Vet extends User {
    clinicId: string;
    clinic: Clinic;
    description: string;
    appointments: Appointment[];
}