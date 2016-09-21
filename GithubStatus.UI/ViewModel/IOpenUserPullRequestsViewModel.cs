using Octokit;
using ReactiveUI;

namespace GithubStatus.UI.ViewModel
{
    public interface IOpenUserPullRequestsViewModel
    {
        IReactiveDerivedList<PullRequest> PullRequests { get; }
    }
}