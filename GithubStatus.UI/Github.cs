using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Octokit;
using Octokit.Internal;
using Octokit.Reactive;

namespace Roslyn.Github.Status {
    public class Github {
        private static ObservableGitHubClient GithubObservable = new ObservableGitHubClient(
            new ProductHeaderValue("Roslyn.Github.Status"),
            new InMemoryCredentialStore(new Credentials("531e86d714884ad4b3a89a064db40d5031d5ae2a")));

        public static IObservable<Issue> GetIssues(string owner, string name) {
            var issues = GithubObservable.Issue.GetAllForRepository(owner, name)
                .Where(x =>
                    x.State == ItemState.Open &&
                    x.Assignee?.Login == "jmarolf")
                .Catch((Exception ex) => { LogException(ex); return Observable.Create(subscribeAsync: (Func<IObserver<Issue>, CancellationToken, Task<Action>>)EmptyObservable); });
            return issues;
        }

        public static IObservable<PullRequest> GetPullRequests(string owner, string name) {
            return GithubObservable.PullRequest.GetAllForRepository(owner, name)
                .SelectMany(pullrequest => {
                    var isInDotNetOrg = GithubObservable.Organization.Member.CheckMember("dotnet", pullrequest.User.Login);
                    return isInDotNetOrg.Zip(new[] { pullrequest }, (item1, item2) => Tuple.Create(item1, item2));
                })
                .Where(x => x.Item2.State == ItemState.Open && x.Item1 != true)
                .Select(x => x.Item2);
        }

        private static void LogException(Exception ex) {
            Debug.Print(ex.Message);
        }

        private static Task<Action> EmptyObservable(IObserver<Issue> arg1, CancellationToken arg2) {
            Action a = new Action(() => { });
            return Task.FromResult(a);
        }
    }
}
