import { Component, OnInit } from '@angular/core';
import { JobsComponent } from '../jobs/jobs.component';
import { SharedService } from '../shared.service';



@Component({
  selector: 'app-candidatematches',
  templateUrl: './candidatematches.component.html',
  styleUrls: ['./candidatematches.component.css']
})


export class CandidatematchesComponent implements OnInit {

  CandidatesList: any = [];
  JobsList: any = [];
  MatchingCandidates: any = [];

  constructor(private service: SharedService) { }

  ngOnInit(): void {
    this.getMatchingCandidates();
  }

  //computes matching candidates by getting responses from jobs & candidates APIs  and renders data
  getMatchingCandidates() {
    this.service.getCandidatesList().subscribe(data => {
      this.CandidatesList = data;

      this.service.getJobsList().subscribe(data => {
        this.JobsList = data;
        this.JobsList.forEach((element: any) => {
          this.MatchingCandidates.push(this.service.getCandidateScores(element, this.CandidatesList))
        });
      });
    })
  }

}
