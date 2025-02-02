﻿namespace Git.Models.Repositories
{
    public class RepositoryListingViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Owner { get; set; }

        public string CreatedOn { get; init; }

        public int Commits { get; init; }

    }
}
