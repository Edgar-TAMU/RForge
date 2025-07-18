﻿using Microsoft.AspNetCore.Mvc;
using RForgeDocs.Abstractions.DataModels;
using RForgeDocs.Abstractions.Services;

namespace RForgeDocs.EndPoints
{
    public static class UserEndpoints
    {
        public static void MapUserApi(this WebApplication app)
        {
            //IGetUserProcessor
            app.MapGet("/api/users/{*userId}",
                async ([FromServices] IGetUserProcessor processor, int userId) =>
                {
                    return Results.Ok(await processor.GetUser(userId));
                });
         
            //ISaveUserProcessor
            app.MapPut("/api/users",
                async ([FromServices] ISaveUserProcessor processor, [FromBody] UserAddSaveData user) =>
                {
                    return Results.Ok(await processor.AddUser(user));
                });

            app.MapPost("/api/users",
                async ([FromServices] ISaveUserProcessor processor, [FromBody] UserSaveData user) =>
                {
                    return Results.Ok(await processor.SaveUser(user));
                });

            //IUserDataGridPageProcessor
            app.MapPost("/api/users/page",
                async ([FromServices] IUserDataGridPageProcessor processor, [FromBody] UserDataGridGetPageData options) =>
                {
                    return Results.Ok(await processor.GetPage(options));
                });
            app.MapGet("/api/users/all",
                async ([FromServices] IUserDataGridPageProcessor processor) =>
                {
                    return Results.Ok(await processor.GetAll());
                });
            //IFindUserProcessor
            app.MapGet("/api/users/find/",
                async ([FromServices] IFindUsersProcessor processor, string searchText, int returnCount = 10) =>
                {
                    return Results.Ok(await processor.Find(searchText, returnCount));
                });
        }

    }
}
