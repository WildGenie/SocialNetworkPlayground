﻿namespace SocialMedia.Web.Models
{
    using SocialMedia.Services.Models;
    using System;

    public class CommentViewModel
    {
        public CommentViewModel()
        {
        }

        public int CommentId { get; set; }

        public string Content { get; set; }

        public DateTime DatePosted { get; set; }

        public UserServiceModel Author { get; set; }

        public TagFriendsServiceModel TagFriends { get; set; }

        public int PostId { get; set; }
    }
}
