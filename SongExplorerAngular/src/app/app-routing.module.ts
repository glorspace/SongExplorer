import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MusiciansComponent } from './musicians/musicians.component';
import { SongsComponent } from './songs/songs.component';
import { AccountComponent } from './account/account.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'musicians', component: MusiciansComponent },
  { path: 'songs', component: SongsComponent },
  { path: 'account', component: AccountComponent }
]

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
