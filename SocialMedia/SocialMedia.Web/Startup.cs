namespace SocialMedia.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SocialMedia.Data;
    using SocialMedia.Web.Identity;
    using Infrastructure;
    using SocialMedia.Services.TaggedUser;
    using SocialMedia.Data.Models;
    using SocialMedia.Services.Post;
    using SocialMedia.Services.Friendship;
    using SocialMedia.Services.Profile;
    using SocialMedia.Services.Comment;
    using SocialMedia.Services.User;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddRazorPages();
            services.AddMvc();

            services
                .AddDbContext<SocialMediaDbContext>(opt => opt
                    .UseSqlServer(Configuration.GetConnectionString("SocialMediaDb")));

            services.AddIdentity();

            services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomUserClaimsPrincipalFactory>();

            services.AddTransient<ITaggedUserService, TaggedUserService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IFriendshipService, FriendshipService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IUserService, UserService>();

            // Cookies for Login
            services
                .ConfigureApplicationCookie(options => options
                    .LoginPath = "/Account/Login");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
