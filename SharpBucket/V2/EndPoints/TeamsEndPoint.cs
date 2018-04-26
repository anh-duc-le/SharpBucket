﻿using System.Collections.Generic;
using System.Dynamic;
using Serilog;
using SharpBucket.V2.Pocos;

namespace SharpBucket.V2.EndPoints
{
    /// <summary>
    /// The Teams End Point gets a team's profile information.
    /// More info:
    /// https://confluence.atlassian.com/display/BITBUCKET/teams+Endpoint
    /// </summary>
    public class TeamsEndPoint : EndPoint
    {
        public TeamsEndPoint(SharpBucketV2 sharpBucketV2, string teamName)
            : base(sharpBucketV2, "teams/" + teamName + "/")
        {
        }
        public TeamsEndPoint(ISharpBucketV2 sharpBucketV2, string teamName)
            : base(sharpBucketV2, "teams/" + teamName + "/")
        {
        }


        public List<Team> GetUserTeams(int max = 0)
        {
            dynamic parameters = new ExpandoObject();
            parameters.role = "member";
            return GetPaginatedValues<Team>("teams/", max, parameters);
            //return _sharpBucketV2.Get<List<Team>>(null, "teams/", parameters);
        }

        /// <summary>
        /// With Logging
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public List<Team> GetUserTeams(ILogger logger, int max = 0)
        {
            dynamic parameters = new ExpandoObject();
            parameters.role = "member";
            return GetPaginatedValues<Team>(logger, "teams/", max, parameters);
            //return _sharpBucketV2.Get<List<Team>>(null, "teams/", parameters);
        }

        /// <summary>
        /// Gets the public information associated with a team. 
        /// If the team's profile is private, the caller must be authenticated and authorized to view this information. 
        /// </summary>
        /// <returns></returns>
        public Team GetProfile()
        {
            return _sharpBucketV2.Get(new Team(), _baseUrl);
        }

        /// <summary>
        /// Gets the public information associated with a team. 
        /// If the team's profile is private, the caller must be authenticated and authorized to view this information. 
        /// With Logging
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        public Team GetProfile(ILogger logger)
        {
            return _sharpBucketV2.Get(logger, new Team(), _baseUrl);
        }

        /// <summary>
        /// Gets the team's members.
        /// </summary>
        /// <param name="max">The maximum number of items to return. 0 returns all items.</param>
        /// <returns></returns>
        public List<Team> ListMembers(int max = 0)
        {
            var overrideUrl = _baseUrl + "members/";
            return GetPaginatedValues<Team>(overrideUrl, max);
        }

        /// <summary>
        /// Gets the team's members.
        /// With Logging
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="max">The maximum number of items to return. 0 returns all items.</param>
        /// <returns></returns>
        public List<Team> ListMembers(ILogger logger, int max = 0)
        {
            var overrideUrl = _baseUrl + "members/";
            return GetPaginatedValues<Team>(logger, overrideUrl, max);
        }

        /// <summary>
        /// Gets the list of accounts following the team.
        /// </summary>
        /// <param name="max">The maximum number of items to return. 0 returns all items.</param>
        /// <returns></returns>
        public List<Team> ListFollowers(int max = 0)
        {
            var overrideUrl = _baseUrl + "followers/";
            return GetPaginatedValues<Team>(overrideUrl, max);
        }

        /// <summary>
        /// Gets the list of accounts following the team.
        /// With Logging
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="max">The maximum number of items to return. 0 returns all items.</param>
        /// <returns></returns>
        public List<Team> ListFollowers(ILogger logger, int max = 0)
        {
            var overrideUrl = _baseUrl + "followers/";
            return GetPaginatedValues<Team>(logger, overrideUrl, max);
        }

        /// <summary>
        /// Gets a list of accounts the team is following.
        /// </summary>
        /// <param name="max">The maximum number of items to return. 0 returns all items.</param>
        /// <returns></returns>
        public List<Team> ListFollowing(int max = 0)
        {
            var overrideUrl = _baseUrl + "following/";
            return GetPaginatedValues<Team>(overrideUrl, max);
        }

        /// <summary>
        /// Gets a list of accounts the team is following.
        /// With Logging
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="max">The maximum number of items to return. 0 returns all items.</param>
        /// <returns></returns>
        public List<Team> ListFollowing(ILogger logger, int max = 0)
        {
            var overrideUrl = _baseUrl + "following/";
            return GetPaginatedValues<Team>(logger, overrideUrl, max);
        }

        /// <summary>
        /// Gets the list of the team's repositories. 
        /// Private repositories only appear on this list if the caller is authenticated and is authorized to view the repository.
        /// </summary>
        /// <param name="max">The maximum number of items to return. 0 returns all items.</param>
        /// <returns></returns>
        public List<Repository> ListRepositories(int max = 0)
        {
            var overrideUrl = _baseUrl + "repositories/";
            return GetPaginatedValues<Repository>(overrideUrl, max);
        }

        /// <summary>
        /// Gets the list of the team's repositories. 
        /// Private repositories only appear on this list if the caller is authenticated and is authorized to view the repository.
        /// With Logging
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="max">The maximum number of items to return. 0 returns all items.</param>
        /// <returns></returns>
        public List<Repository> ListRepositories(ILogger logger, int max = 0)
        {
            var overrideUrl = _baseUrl + "repositories/";
            return GetPaginatedValues<Repository>(logger, overrideUrl, max);
        }

        /// <summary>
        /// Get's the list of the team's projects.
        /// A paginated list of projects that belong to the specified team.
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public List<Project> ListProjects(int max = 0)
        {
            var overrideUrl = _baseUrl + "projects/";
            return GetPaginatedValues<Project>(overrideUrl, max);
        }

        /// <summary>
        /// With Logging
        /// Get's the list of the team's projects.
        /// A paginated list of projects that belong to the specified team.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public List<Project> ListProjects(ILogger logger, int max = 0)
        {
            var overrideUrl = _baseUrl + "projects/";
            return GetPaginatedValues<Project>(logger, overrideUrl, max);
        }
        /// <summary>
        /// ProjectPostParams contains solely the required parameters for posting a project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public ProjectPostParams PostProject(ProjectPostParams project)
        {
            var overrideUrl = _baseUrl + "projects/";
            return _sharpBucketV2.Post(project, overrideUrl);
        }

        /// <summary>
        /// With Logging
        /// ProjectPostParams contains solely the required parameters for posting a project
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        public ProjectPostParams PostProject(ILogger logger, ProjectPostParams project)
        {
            var overrideUrl = _baseUrl + "projects/";
            return _sharpBucketV2.Post(logger, project, overrideUrl);
        }
        /// <summary>
        /// Get a project by using 
        /// </summary>
        /// <param name="projectKey"></param>
        /// <returns></returns>
        public Project GetProject(string projectKey)
        {
            var overrideUrl = _baseUrl + "projects/" + projectKey;
            return _sharpBucketV2.Get(new Project(), overrideUrl);
        }

        /// <summary>
        /// With Logging
        /// Get a project by using project key
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="projectKey"></param>
        /// <returns></returns>
        public Project GetProject(ILogger logger, string projectKey)
        {
            var overrideUrl = _baseUrl + "projects/" + projectKey;
            return _sharpBucketV2.Get(logger, new Project(), overrideUrl);
        }
    }
}