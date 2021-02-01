import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent implements OnInit {

  CandidatesList:any=[];
  constructor(private service:SharedService) { }

  ngOnInit(): void {
    this.refreshCandidatesList();
  }

  refreshCandidatesList(){
    this.service.getCandidatesList().subscribe(data=>{
      this.CandidatesList=data;
    });
  }

}
