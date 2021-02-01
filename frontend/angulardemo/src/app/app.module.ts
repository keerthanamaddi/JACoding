import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { JobsComponent } from './jobs/jobs.component';
import { CandidatesComponent } from './candidates/candidates.component';
import { CandidatematchesComponent } from './candidatematches/candidatematches.component';
import{SharedService} from './shared.service';

import {HttpClientModule} from '@angular/common/http';
import { ViewjobComponent } from './jobs/viewjob/viewjob.component';
@NgModule({
  declarations: [
    AppComponent,
    JobsComponent,
    CandidatesComponent,
    CandidatematchesComponent,
    ViewjobComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
