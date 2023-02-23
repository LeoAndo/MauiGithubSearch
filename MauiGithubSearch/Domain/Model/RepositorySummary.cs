using System;
namespace MauiGithubSearch.Domain.Model
{
    public class RepositorySummary
    {
        public RepositorySummary(int id, string name, string ownerName)
        {
            Id = id;
            Name = name;
            OwnerName = ownerName;
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public string OwnerName { set; get; }
    }
}

