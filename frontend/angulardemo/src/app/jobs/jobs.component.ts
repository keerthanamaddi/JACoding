import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent implements OnInit {

  JobsList:any=[];
  ActivateViewJob:boolean=false;
  job:any;

  constructor(private service:SharedService) { }

  ngOnInit(): void {
    this.refreshJobsList();
  }

  refreshJobsList(){
    this.service.getJobsList().subscribe(data=>{
      this.JobsList=data;
    });
  }


  addClick(job:any){
    console.log("add clicked" + job)
    this.job=this.JobsList.filter((element:any) => element.name.includes(job));
    console.log("add clicked" + this.job[0].skills)
    this.ActivateViewJob=true;
  }

  closeClick(){
    this.ActivateViewJob=false;
  }
}
