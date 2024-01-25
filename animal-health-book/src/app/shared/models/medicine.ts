import { Procedure } from "./procedure";

export interface Medicine {
    id: string;
    name: string;
    description: string | null;
    lotNumber: string | null;
    procedureId: string;
    expirationDate: string | null;
    procedure: Procedure;
}