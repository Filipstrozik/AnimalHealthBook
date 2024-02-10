import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Animal } from '../models/animal';
import { HealthNote } from '../models/healthNote';
import { RegisterDto } from '../dto/registerDto';
import { LoginDto } from '../dto/loginDto';
import { AnimalType } from '../models/animalType';
import { AnimalCreationDto } from '../dto/animalDto';
import { CoatType } from '../models/coatType';

@Injectable({
  providedIn: 'root',
})
export class ApiRequestService {
  constructor(private http: HttpClient) {}
  //authentication

  login(data: LoginDto): Observable<any> {
    return this.http.post<any>('/api/users/login', data);
  }

  register(data: RegisterDto): Observable<any> {
    return this.http.post<any>('/api/users/register', data);
  }

  // animals

  getAnimals(): Observable<Animal[]> {
    return this.http.get<Animal[]>('/api/animals');
  }

  getAnimal(id: string): Observable<Animal> {
    return this.http.get<Animal>(`/api/animals/${id}`);
  }

  createAnimal(animal: AnimalCreationDto): Observable<Animal> {
    return this.http.post<Animal>('/api/animals', animal);
  }

  updateAnimal(animal: AnimalCreationDto): Observable<AnimalCreationDto> {
    return this.http.put<Animal>(`/api/animals`, animal);
  }

  deleteAnimal(id: string): Observable<Animal> {
    return this.http.delete<Animal>(`/api/animals/${id}`);
  }

  //animalTypes

  getAnimalTypes(): Observable<AnimalType[]> {
    return this.http.get<AnimalType[]>('/api/animaltypes');
  }

  //CoatTypes
  getCoatTypes(): Observable<CoatType[]> {
    return this.http.get<CoatType[]>('/api/coattypes');
  }

  //CoatColors
  getCoatColors(): Observable<CoatType[]> {
    return this.http.get<CoatType[]>('/api/coatcolors');
  }

  // health notes

  getHealthNotes(animalId: string): Observable<HealthNote[]> {
    return this.http.get<HealthNote[]>(`api/animals/${animalId}/healthnotes`);
  }

  getHealthNoteById(id: string): Observable<HealthNote> {
    return this.http.get<HealthNote>(`api/healthNotes/${id}`);
  }

  createHealthNoteForAnimal(
    animalId: string,
    healthNote: HealthNote
  ): Observable<HealthNote> {
    return this.http.post<HealthNote>(
      `api/animals/${animalId}/healthNotes`,
      healthNote
    );
  }

  updateHealthNoteForAnimal(
    animalId: string,
    healthNote: HealthNote
  ): Observable<HealthNote> {
    return this.http.put<HealthNote>(
      `api/animals/${animalId}/healthNotes`,
      healthNote
    );
  }

  deleteHealthNoteById(id: string): Observable<HealthNote> {
    return this.http.delete<HealthNote>(`api/healthNotes/${id}`);
  }
}
