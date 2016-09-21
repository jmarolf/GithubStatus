using System;
using Octokit;
using ReactiveUI;

namespace GithubStatus.UI.ViewModel
{
    public interface IOpenUserIssuesViewModel
    {
        IReactiveDerivedList<Issue> Issues { get; }
    }
}