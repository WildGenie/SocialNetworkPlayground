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

        Task TagFriendPost(string taggerId, string taggedId, int postId);

        Task TagFriendComment(string taggerId, string taggedId, int commentId);
        
        Task UpdateTaggedFriendsInPostAsync(IList<UserServiceModel> taggedFriends, int postId, string taggerId);
        
        Task UpdateTaggedFriendsInCommentAsync(IList<UserServiceModel> taggedFriends, int commentId, string taggerId);

        Task RemoveTaggedFriendPost(string taggedId, int postId);

        Task RemoveTaggedFriendComment(string taggedId, int commentId);
        
        Task DeleteTaggedFriendsPostId(int postId);
        
        Task DeleteTaggedFriendsCommentId(int commentId);

        /// <summary>
        ///  Compare tagged with untagged friends
        ///  For those who are tagged set checked to true
        /// </summary>
        /// <param name="taggedFriends"></param>
        /// <param name="friends"></param>
        /// <returns></returns>
        ICollection<UserServiceModel> GetUntaggedFriends(
            List<UserServiceModel> taggedFriends,
            List<UserServiceModel> friends);

        Task DeleteTaggedFriendsInComments(ICollection<int> commentsIds);

    }
}
