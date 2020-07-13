﻿namespace SocialMedia.Services.TaggedUser
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using SocialMedia.Data.Models;

    public interface ITaggedUserService
    {
        ICollection<TagFriends> GetTagFriendsEntities(
            string taggerId, 
            IEnumerable<string> taggedFriendsIds);

        Task<ICollection<UserServiceModel>> GetTaggedFriendsByPostIdAsync(int postId);

        Task<EntityState> TagFriend(string taggerId, string taggedId, int postId);

        Task<EntityState> RemoveTaggedFriend(string taggedId, int postId);

        ICollection<UserServiceModel> GetUntaggedFriends(
            ICollection<UserServiceModel> taggedFriends,
            ICollection<UserServiceModel> friends);

        //Task<ICollection<UserServiceModel>> GetTaggedFriendsByCommentIdAsync(int commentId);
    }
}
