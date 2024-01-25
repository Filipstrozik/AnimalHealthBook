import { Vet } from "./vet";
import { Appointment } from "./appointment";

export interface Clinic {
    id: string;
    name: string;
    phoneNumber: string;
    email: string;
    description: string;
    vets: Vet[];
    appointments: Appointment[];
}