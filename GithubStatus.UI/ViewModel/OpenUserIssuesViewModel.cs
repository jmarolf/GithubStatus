using System;
using Octokit;
using ReactiveUI;
using Github = Roslyn.Github.Status.Github;

namespace GithubStatus.UI.ViewModel
{
    public class OpenUserIssuesViewModel : ReactiveObject, IOpenUserIssuesViewModel
    {
        public OpenUserIssuesViewModel()
        {
            Issues = Github.GetIssues("dotnet", "roslyn").CreateCollection();
        }

        public IReactiveDerivedList<Issue> Issues { get; }
    }
}
