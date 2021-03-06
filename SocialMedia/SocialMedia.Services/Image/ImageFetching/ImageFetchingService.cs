﻿namespace SocialMedia.Services.Image.ImageFetching
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using SocialMedia.Data;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class ImageFetchingService : IImageFetchingService
    {
        private readonly SocialMediaDbContext _data;

        public ImageFetchingService(SocialMediaDbContext data) => this._data = data;

        public Task<List<ImageServiceModel>> GetAllImagesByUserId(string userId)
        => this._data
            .ImagesData
            .Where(u => u.UploaderId == userId)
            .Select(i => new ImageServiceModel 
            {
                Id = i.Id.ToString(),
                UploadDate = i.UploadDate
            })
            .ToListAsync();

        public Task<Stream> GetThumbnail(string id)
        => this.GetImageData(id, "Thumbnail");

        public Task<Stream> GetFullscreen(string id)
        => this.GetImageData(id, "Fullscreen");

        public ImageServiceModel GetOriginalImageDetails(string id)
        => this._data
            .ImagesData
            .Where(i => i.Id.ToString() == id)
            .Select(i => new ImageServiceModel 
            {
                Name = i.OriginalFileName,
                OriginalContent = i.OriginalContent
            })
            .FirstOrDefault();

        private async Task<Stream> GetImageData(string id, string size)
        {
            var db = this._data.Database;

            var dbConnection = (SqlConnection)db.GetDbConnection();

            var command = new SqlCommand(
                $"SELECT {size}Content " +
                $"FROM ImagesData " +
                $"WHERE Id = @id;",
                dbConnection);

            command.Parameters.Add(new SqlParameter("@id", id));

            dbConnection.Open();

            var reader = await command.ExecuteReaderAsync();
            Stream result = null;

            if (reader.HasRows)
            {
                while (reader.Read()) result = reader.GetStream(0);
            }

            reader.Close();

            return result;
        }
    }
}
