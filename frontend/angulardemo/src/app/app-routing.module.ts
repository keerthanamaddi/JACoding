import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {JobsComponent} from './jobs/jobs.component';
import {CandidatesComponent} from './candidates/candidates.component';
import {CandidatematchesComponent} from './candidatematches/candidatematches.component';

const routes: Routes = [
  {path:'jobs',component:JobsComponent},
  {path:'candidates',component:CandidatesComponent},
  {path:'candidatematches',component:CandidatematchesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
