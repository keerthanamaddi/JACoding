import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { job } from 'src/models/job';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent implements OnInit {

  JobsList: job[];
  ActivateViewJob: boolean = false;
  currentJob: job;
  constructor(private service: SharedService) { }

  ngOnInit(): void {
    this.refreshJobsList();
  }

  refreshJobsList() {
    this.service.getJobsList().subscribe(data => {
      this.JobsList = data;
    });
  }


  addClick(job: any) {
    console.log("add clicked" + job)
    let jobMatches = (this.JobsList.filter((element: job) => element.name.includes(job)));
    this.currentJob = jobMatches[0];
    console.log("add clicked" + this.currentJob.skills)
    this.ActivateViewJob = true;
  }

  closeClick() {
    this.ActivateViewJob = false;
  }
}
