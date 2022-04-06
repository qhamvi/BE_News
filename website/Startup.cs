using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using website.Entities;
using website.Repositories;//AAccountsRepository,InMemAccountsRepository
using website.Settings;

namespace website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Them dong nay neu Account.cs co Guid 
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            //Them dong nay neu thu muc trong Entites có DateTimeOffsetRializer
            // BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            // BsonSerializer.RegisterSerializer(new StringSerializer(BsonType.String));

            services.AddSingleton<IMongoClient>(ServiceProvider =>
            {
                var settings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                return new MongoClient(settings.ConnectionString);
            });


            services.AddSingleton<AAccountsRepository, MongoDbAccountsRepository>();
            services.AddSingleton<NNewsRepository, MongoDbNewsRepository>();
            services.AddSingleton<PPositionsRepository, MongoDbPoisitionsRepository>();
            services.AddSingleton<RReasonsRepository, MongoDbReasonsRepository>();
            services.AddSingleton<TTopicsRepository, MongoDbTopicsRepository>();
            // services.AddSingleton<UUsersRepository, MongoDbUserRepository>(); --> Image chay duoc why User not? loi o ham xay dung , khai bao IMongoClient moi dung
            services.AddSingleton<UUsersRepository, MongoDbUserRepository>();

            services.AddSingleton<IImagesRepository, MongoDbImagesRepository>();
            services.AddControllers(options =>{
                options.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "website", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "website v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
