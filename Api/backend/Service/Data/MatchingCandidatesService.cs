using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Model;
using Newtonsoft.Json;

namespace Api.Service.Data
{
    //service layer reads data from the two JobAdder public APIs and computes matching candidates
    public class MatchingCandidatesService
    {
        private HttpClient _httpClient;

        public MatchingCandidatesService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<MatchingCandidate>> GetMatchingCandidates()
        {

            var jobs = JsonConvert.DeserializeObject<List<Job>>(
                   await _httpClient.GetStringAsync("/jobs")
               );
            var candidates = JsonConvert.DeserializeObject<List<Candidate>>(
                    await _httpClient.GetStringAsync("/candidates")
                );

            List<MatchingCandidate> matchingCandidates =new List<MatchingCandidate>();
            foreach (Job job in jobs)
            {
                string[] jobSkills = job.Skills.Split(",");
                var filteredCandidates = candidates.Where(candidate => { return jobSkills.Any(skill => candidate.SkillTags.Contains(skill)); } ).ToList();
                List<CandidateMatch> matches = new List<CandidateMatch>();
                foreach(Candidate c in filteredCandidates)
                {
                    int count = jobSkills.Intersect(c.SkillTags.Split(",")).ToList().Count;
                    matches.Add(new CandidateMatch(c, count));
                }
                matches = matches.OrderByDescending(p => p.MatchingScore).ToList().GetRange(0,10);
                MatchingCandidate details = new MatchingCandidate(job, matches);
                matchingCandidates.Add(details);
            }
            return matchingCandidates;


        }


        public async Task<List<Job>> GetJobs()
        {
            string APIURL = "/jobs";
            //var response = await _httpClient.GetAsync(APIURL);
            return JsonConvert.DeserializeObject<List<Job>>(
                await _httpClient.GetStringAsync(APIURL)
            );

        }

        public async Task<string> GetCandidates()
        {
            string APIURL = "/candidates";
            var response = await _httpClient.GetAsync(APIURL);
            return await response.Content.ReadAsStringAsync();

        }
    }
}
