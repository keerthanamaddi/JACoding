import { R3InjectorMetadataFacade } from "@angular/compiler/src/compiler_facade_interface";

export interface matchingcandidates {
  job: job;
  candidates: candidatescore[];
}

export interface job {
  jobId: string;
  name: string;
  company: string;
  skills: string;
}

export interface candidate {
  candidateId: string;
  name: string;
  skillTags: string;
}

export interface candidatescore {
  candidate: candidate;
  score: number;
}