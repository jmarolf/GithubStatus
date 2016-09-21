using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using ReactiveUI;
using Roslyn.Github.Status;

namespace GithubStatus.UI.ViewModel
{
    public class OpenUserPullRequestsViewModel : ReactiveObject, IOpenUserPullRequestsViewModel
    {
        public OpenUserPullRequestsViewModel()
        {
            PullRequests = Github.GetPullRequests("dotnet", "roslyn").CreateCollection();
        }

        public IReactiveDerivedList<PullRequest> PullRequests { get; }
    }
}
