﻿namespace SocialMedia.Models.ViewModels
{
    using SocialMedia.Data.Models;
    using SocialMedia.Services.Models;
    using System.Collections.Generic;

    public class GroupViewModel
    {
        public GroupViewModel()
        {
            this.Groups = new List<Group>();
            this.MemberGroups = new List<Group>();
            this.NonMemberGroups = new List<Group>();
            this.Posts = new List<PostServiceModel>();
        }

        public Group Group { get; set; }
        public User CurrentUser { get; set; }

        /// <summary>
        /// Group posts with tagged users 
        /// </summary>
        public ICollection<PostServiceModel> Posts { get; set; }

        public ICollection<Group> Groups { get; set; }

        public ICollection<Group> NonMemberGroups { get; set; }

        public ICollection<Group> MemberGroups { get; set; }
    }
}
