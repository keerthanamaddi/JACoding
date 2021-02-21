import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { job } from 'src/models/job';
interface CandidateScore {
  name: string;
  score: number;
}

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  //readonly APIUrl = "http://private-76432-jobadder1.apiary-mock.com";
  readonly APIUrl = "https://localhost:5001";

  constructor(private http: HttpClient) { }

  getJobsList(): Observable<job[]> {
    return this.http.get<any>(this.APIUrl + '/jobs');
  }

  getCandidatesList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/candidates');
  }

  getMatchingCandidates(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/matchingcandidates');
  }

  getCandidateScores(job: any, candidates: any = []) {
    let matchingCandidates: any = [];
    candidates.forEach((candidate: any) => {
      const intersection = job.skills.split(',').filter((element: any) => candidate.skillTags.includes(element));
      let name = candidate.name
      let score = intersection.length
      if (score > 0) {
        let candidateScore: CandidateScore = { name, score }
        matchingCandidates.push(candidateScore)
      }
    })

    matchingCandidates = matchingCandidates.sort((a: any, b: any) => (a.score > b.score ? -1 : 1)).slice(0, 10);
    return { job, matchingCandidates };
  }
}
