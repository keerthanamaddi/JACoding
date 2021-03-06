import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { job } from 'src/models/job';

@Component({
  selector: 'app-viewjob',
  templateUrl: './viewjob.component.html',
  styleUrls: ['./viewjob.component.css']
})
export class ViewjobComponent implements OnInit {

  @Input() job: job;
  CandidatesList: any = [];
  MatchingCandidates: any = [];
  jobName: any;
  constructor(private service: SharedService) {
  }

  ngOnInit(): void {
    this.loadJobDetails();
  }

  loadJobDetails() {

    this.service.getCandidatesList().subscribe(data => {
      this.CandidatesList = data;
      this.MatchingCandidates = this.service.getCandidateScores(this.job, this.CandidatesList).matchingCandidates;
      console.log(this.MatchingCandidates[0].name + this.MatchingCandidates[0].score)
    })
  }

}
