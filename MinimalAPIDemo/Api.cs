using DataAccess.Data;
using DataAccess.Models;

namespace MinimalAPIDemo
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/Users", GetUsers);
            app.MapGet("/Users/{id}", GetUser);
            app.MapDelete("/Users", DeleteUser);
            app.MapPut("/Users", UpdateUser);
            app.MapPost("/Users", InsertUser);
        }

        private static async Task<IResult> GetUsers(IUserData data)
        {
            try
            {
                return Results.Ok(await data.GetUsers());
            }
            catch (Exception ex) 
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetUser(int id, IUserData data)
        {
            var results = await data.GetUser(id);
            if (results == null) return Results.NotFound();

            return Results.Ok(results);

        }

        private static async Task<IResult> InsertUser(UserModel user, IUserData data)
        {
            try
            {
                await data.InsertUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
        {
            try
            {
                await data.UpdateUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteUser(int id, IUserData data)
        {
            try
            {
                await data.DeleteUser(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


    }
}
