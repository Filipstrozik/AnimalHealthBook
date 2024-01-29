import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './modules/pages/dashboard/dashboard.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  // { path: 'animals', component: AnimalsComponent },
  // { path: 'owners', component: OwnersComponent },
  // { path: 'vets', component: VetsComponent },
  // { path: 'treatments', component: TreatmentsComponent },
  // { path: 'users', component: UsersComponent },
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' }, // Redirect to the default route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
