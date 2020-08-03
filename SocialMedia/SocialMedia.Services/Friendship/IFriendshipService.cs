﻿namespace SocialMedia.Services.Friendship
{
    using Microsoft.EntityFrameworkCore;
    using SocialMedia.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFriendshipService
    {
        Task<IList<UserServiceModel>> GetFriendsAsync(string userId);

        Task<ICollection<UserServiceModel>> GetNonFriendsAsync(string userId);

        Task<ServiceModelFRStatus> GetFriendshipStatusAsync(string currentUserId, string secondUserId);

        Task<IEnumerable<UserServiceModel>> GetFriendRequestsAsync(string currentUserId);

        Task<IEnumerable<UserServiceModel>> GetPendingRequestsAsync(string currentUserId);

        Task SendRequestAsync(string currentUserId, string addresseeId);

        Task AcceptRequestAsync(string currentUserId, string requesterId);

        Task RejectRequestAsync(string currentUserId, string requesterId);

        Task CancelInvitationAsync(string currentUserId, string addresseeId);

        Task UnfriendAsync(string currentUserId, string friendId);
    }
}
