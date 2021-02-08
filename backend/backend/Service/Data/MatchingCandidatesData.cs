using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using backend.Model;
using Newtonsoft.Json;

namespace backend.Service.Data
{
    //service layer reads data from the two JobAdder public APIs and computes matching candidates
    public class MatchingCandidatesData
    {
        private HttpClient _httpClient;

        public MatchingCandidatesData(HttpClient client)
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
                string[] jobSkills = job.skills.Split(",");
                var filteredCandidates = candidates.Where(candidate => { return jobSkills.Any(skill => candidate.skillTags.Contains(skill)); } ).ToList();
                List<CandidateScore> matches = new List<CandidateScore>();
                foreach(Candidate c in filteredCandidates)
                {
                    int count = jobSkills.Intersect(c.skillTags.Split(",")).ToList().Count;
                    matches.Add(new CandidateScore(c, count));
                }
                matches = matches.OrderByDescending(p => p.score).ToList().GetRange(0,10);
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
