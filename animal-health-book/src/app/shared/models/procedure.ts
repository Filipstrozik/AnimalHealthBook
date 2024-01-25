import { Medicine } from "./medicine";
import { Appointment } from "./appointment";

export interface Procedure {
    id: string;
    procedureType: string;
    description: string;
    date: string;
    medicines: Medicine[] | null;
    appointmentId: string;
    appointment: Appointment;
}