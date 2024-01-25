import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Animal } from '../models/animal';
import { HealthNote } from '../models/healthNote';

@Injectable({
  providedIn: 'root'
})
export class ApiRequestService {
  constructor(private http: HttpClient) {
  }
  
  // animals

  getAnimals(): Observable<Animal[]> {
    return this.http.get<Animal[]>('api/animals');
  }

  getAnimal(id: string): Observable<Animal> {
    return this.http.get<Animal>(`api/animals/${id}`);
  }

  createAnimal(animal: Animal): Observable<Animal> {
    return this.http.post<Animal>('api/animals', animal);
  }

  updateAnimal(animal: Animal): Observable<Animal> {
    return this.http.put<Animal>(`api/animals`, animal);
  }

  deleteAnimal(id: string): Observable<Animal> {
    return this.http.delete<Animal>(`api/animals/${id}`);
  }

  // health notes

  getHealthNotes(animalId: string): Observable<HealthNote[]> {
    return this.http.get<HealthNote[]>(`api/animals/${animalId}/healthn otes`);
  }

  getHealthNoteById(id: string): Observable<HealthNote> {
    return this.http.get<HealthNote>(`api/healthNotes/${id}`);
  }

  createHealthNoteForAnimal(animalId: string, healthNote: HealthNote): Observable<HealthNote> {
    return this.http.post<HealthNote>(`api/animals/${animalId}/healthNotes`, healthNote);
  }

  updateHealthNoteForAnimal(animalId: string, healthNote: HealthNote): Observable<HealthNote> {
    return this.http.put<HealthNote>(`api/animals/${animalId}/healthNotes`, healthNote);
  }

  deleteHealthNoteById(id: string): Observable<HealthNote> {
    return this.http.delete<HealthNote>(`api/healthNotes/${id}`);
  }

  

}
