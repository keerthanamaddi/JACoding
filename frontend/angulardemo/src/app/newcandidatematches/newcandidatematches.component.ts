import { Component, OnInit } from '@angular/core';
import { matchingcandidates } from 'src/models/matchingcandidates';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-newcandidatematches',
  templateUrl: './newcandidatematches.component.html',
  styleUrls: ['./newcandidatematches.component.css']
})
export class NewcandidatematchesComponent implements OnInit {

  MatchingCandidates: matchingcandidates[];

  constructor(private service: SharedService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList() {
    this.service.getMatchingCandidates().subscribe(data => {
      this.MatchingCandidates = data;
      console.log(this.MatchingCandidates.length)
    });

  }

}
