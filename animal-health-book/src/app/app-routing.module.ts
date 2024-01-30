import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './modules/pages/dashboard/dashboard.component';
import { AnimalsComponent } from './modules/pages/animals/animals.component';
import { AnimalDetailsComponent } from './modules/pages/animal-details/animal-details.component';
import { LoginComponent } from './modules/pages/login/login.component';
import { RegisterComponent } from './modules/pages/register/register.component';

const routes: Routes = [
  { path: 'home', component: DashboardComponent, title: 'Home'},
  { path: 'animals', component: AnimalsComponent, title: 'Animals'},
  { path: 'animal-details/:id', component: AnimalDetailsComponent, title: 'Animal Details' },
  
  // { path: 'vets', component: VetsComponent },
  // { path: 'treatments', component: TreatmentsComponent },
  // { path: 'users', component: UsersComponent },
  {path : 'login' , component: LoginComponent, title: 'Login'},
  {path : 'register' , component: RegisterComponent, title: 'Register'},
  { path: '', redirectTo: '/home', pathMatch: 'full' }, // Redirect to the default route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
