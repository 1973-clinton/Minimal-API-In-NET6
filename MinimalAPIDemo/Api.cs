using DataAccess.Data;

namespace MinimalAPIDemo
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {

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
    }
}
