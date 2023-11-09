using Microsoft.Extensions.DependencyInjection;

namespace Domain.Auth;

//define the policies
public class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
             // options.AddPolicy("MustBePostCreator", a =>
             //    a.RequireAuthenticatedUser().RequireClaim("Role", "PostCreator"));
            //add for each role if doing smth different a policy + setting the role when creating user-> but set the role in the server

            
            
            
            //     options.AddPolicy("SecurityLevel4", a =>
            //         a.RequireAuthenticatedUser().RequireClaim("SecurityLevel", "4", "5"));
            //
            //    options.AddPolicy("MustBeTeacher", a =>
            //         a.RequireAuthenticatedUser().RequireClaim("Role", "Teacher"));
            //
            //     options.AddPolicy("SecurityLevel2OrAbove", a =>
            //         a.RequireAuthenticatedUser().RequireAssertion(context =>
            //         {
            //             Claim? levelClaim = context.User.FindFirst(claim => claim.Type.Equals("SecurityLevel"));
            //             if (levelClaim == null) return false;
            //             return int.Parse(levelClaim.Value) >= 2;
            //         }));
        });
    }
}