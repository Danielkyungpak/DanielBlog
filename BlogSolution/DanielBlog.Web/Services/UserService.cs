using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DanielBlog.Web.Models;
using DanielBlog.Web.Models.Requests;
using SendGrid.Helpers.Mail;
using DanielBlog.Web.Exceptions;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace DanielBlog.Web.Services
{
    public class UserService
    {
        //HttpContext is the current HttpRequest, GetOwinContext gets current logged in
        private static ApplicationUserManager GetUserManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        //Register
        //This will register and send the confirmation email on success
        public async Task<IdentityUser> Register(UserRegisterRequest payload)
        {
            ApplicationUserManager userManager = GetUserManager();

            //Initializing when constructing, Object Intializer for the userManager.Create method
            ApplicationUser newUser = new ApplicationUser { UserName = payload.UserName, Email = payload.Email, LockoutEnabled = false };


            var result = userManager.Create(newUser, payload.Password);


            if (result.Succeeded)
            {
                var roleresult = userManager.AddToRole(newUser.Id, "User");
                var request = HttpContext.Current;
                string code = await userManager.GenerateEmailConfirmationTokenAsync(newUser.Id);

                var urlBuilder = new System.Web.Mvc.UrlHelper(request.Request.RequestContext);
                var callbackUrl = urlBuilder.Action("ConfirmEmail", "Users", new { userId = newUser.Id, code = code });

                EmailAddress emailAddress = new EmailAddress(payload.Email, "");
                ConfirmEmailRequest userTarget = new ConfirmEmailRequest(emailAddress, code, callbackUrl);
                await EmailService.SendConfirmationEmail(userTarget);

                return newUser;

            }
            else
            {
                throw new IdentityResultException(result);
            }

        }
        //This will sign in
        //Why is it bool, why is it out string userId
        public bool SignIn(UserLoginRequest payload)
        {
            bool state = false;
            ApplicationUserManager userManager = GetUserManager();
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            ApplicationUser user = userManager.Find(payload.UserName, payload.Password);
            if (user != null)
            {
                ClaimsIdentity signin = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, signin);
                state = true;
                return state;
            }
            return state;
        }

        public bool Logout()
        {
            bool result = false;

            string user = GetCurrentUserId();

            if (user != null)
            {
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                result = true;
            }

            return result;
        }


        //For Checking if Logged In
        public static string GetCurrentUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }

        //For Get Current User
        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(GetCurrentUserId());
        }

        //Gets the entire aspnetuser row
        //public static IdentityUser GetCurrentUser()
        //{
        //    if (!IsLoggedIn())
        //    {
        //        return null;
        //    }

        //    ApplicationUserManager userManager = GetUserManager();

        //    IdentityUser currentUser = userManager.FindById(GetCurrentUserId());
        //    return currentUser;
        //}

        //public static User UserSelect()
        //{
        //    User user = null;

        //    string userId = GetCurrentUserId();
        //    if (userId != null)
        //    {
        //        List<Role> roleList = new List<Role>();

        //        DataProvider.ExecuteCmd(GetConnection, "dbo.User_Select"
        //           , inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //           {
        //               paramCollection.AddWithValue("@ID", userId);
        //           }, map: delegate (IDataReader reader, short set)
        //           {
        //               switch (set)
        //               {
        //                   case 0:
        //                       User u = new User();

        //                       int startingIndex = 0; //startingOrdinal

        //                       u.Id = reader.GetSafeString(startingIndex++);
        //                       u.Email = reader.GetSafeString(startingIndex++);
        //                       u.EmailConfirmed = reader.GetSafeBool(startingIndex++);
        //                       u.FirstName = reader.GetSafeString(startingIndex++);
        //                       u.LastName = reader.GetSafeString(startingIndex++);
        //                       u.PersonId = reader.GetSafeInt32(startingIndex++);
        //                       u.Gender = reader.GetSafeString(startingIndex++);
        //                       user = u;
        //                       break;
        //                   case 1:

        //                       Role r = new Role();
        //                       r.UserRole = reader.GetSafeString(0);
        //                       roleList.Add(r);

        //                       // run the code logic for the second result SET
        //                       break;
        //               }
        //           }
        //           );
        //        user.UserRoles = roleList;
        //        return user;
        //    }
        //    else
        //    {
        //        User nonUser = new User();
        //        nonUser.PersonId = 0;
        //        return nonUser;
        //    }
        //}


        //public static User UserSelectInternal(string userId)
        //{
        //    User user = null;

        //    List<Role> roleList = new List<Role>();

        //    DataProvider.ExecuteCmd(GetConnection, "dbo.User_Select"
        //       , inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //       {
        //           paramCollection.AddWithValue("@ID", userId);
        //       }, map: delegate (IDataReader reader, short set)
        //       {
        //           switch (set)
        //           {
        //               case 0:
        //                   User u = new User();

        //                   int startingIndex = 0; //startingOrdinal

        //                   u.Id = reader.GetSafeString(startingIndex++);
        //                   u.Email = reader.GetSafeString(startingIndex++);
        //                   u.EmailConfirmed = reader.GetSafeBool(startingIndex++);
        //                   u.FirstName = reader.GetSafeString(startingIndex++);
        //                   u.LastName = reader.GetSafeString(startingIndex++);
        //                   u.PersonId = reader.GetSafeInt32(startingIndex++);
        //                   u.Gender = reader.GetSafeString(startingIndex++);
        //                   user = u;
        //                   break;
        //               case 1:

        //                   Role r = new Role();
        //                   r.UserRole = reader.GetSafeString(0);
        //                   roleList.Add(r);

        //                   // run the code logic for the second result SET
        //                   break;
        //           }
        //       }
        //       );
        //    user.UserRoles = roleList;
        //    return user;
        //}




        //public List<UserSearchInfo> UserSelectTop8(string query)
        //{
        //    List<UserSearchInfo> userList = null;

        //    DataProvider.ExecuteCmd(GetConnection, "dbo.User_SelectTop8Search"
        //       , inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //       {
        //           paramCollection.AddWithValue("@SearchParams", query);
        //       }, map: delegate (IDataReader reader, short set)
        //       {
        //           UserSearchInfo u = new UserSearchInfo();

        //           int startingIndex = 0; //startingOrdinal

        //           u.UserId = reader.GetSafeString(startingIndex++);
        //           u.Email = reader.GetSafeString(startingIndex++);
        //           u.PersonId = reader.GetSafeInt32(startingIndex++);
        //           u.FullName = reader.GetSafeString(startingIndex++);
        //           if (userList == null)
        //           {
        //               userList = new List<UserSearchInfo>();
        //           }

        //           userList.Add(u);
        //       }
        //       );
        //    return userList;
        //}


        //public List<UserSearchInfo> UserSelectAll()
        //{
        //    List<UserSearchInfo> userList = null;

        //    DataProvider.ExecuteCmd(GetConnection, "dbo.User_SelectAll"
        //       , inputParamMapper: null, map: delegate (IDataReader reader, short set)
        //       {

        //           UserSearchInfo u = new UserSearchInfo();

        //           int startingIndex = 0; //startingOrdinal

        //           u.UserId = reader.GetSafeString(startingIndex++);
        //           u.Email = reader.GetSafeString(startingIndex++);
        //           u.FullName = reader.GetSafeString(startingIndex++);
        //           if (userList == null)
        //           {
        //               userList = new List<UserSearchInfo>();
        //           }

        //           userList.Add(u);
        //       }
        //       );
        //    return userList;
        //}

        //public ReceiverUserInfo UserSelectById(string userId)
        //{
        //    ReceiverUserInfo row = null;

        //    DataProvider.ExecuteCmd(GetConnection, "dbo.User_SelectById"
        //       , inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //       {
        //           paramCollection.AddWithValue("@ID", userId);
        //       }, map: delegate (IDataReader reader, short set)
        //       {

        //           ReceiverUserInfo u = new ReceiverUserInfo();

        //           int startingIndex = 0; //startingOrdinal

        //           u.UserId = reader.GetSafeString(startingIndex++);
        //           u.Email = reader.GetSafeString(startingIndex++);
        //           u.FirstName = reader.GetSafeString(startingIndex++);
        //           u.LastName = reader.GetSafeString(startingIndex++);
        //           if (row == null)
        //           {
        //               row = u;
        //           }
        //       }
        //       );

        //    return row;
        //}



        //public ApplicationUser GetUser(string emailaddress)
        //{
        //    ApplicationUserManager userManager = GetUserManager();
        //    IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

        //    ApplicationUser user = userManager.FindByEmail(emailaddress);

        //    return user;
        //}

        ////Send the email
        //public async Task<bool> ResetPassword(string email)
        //{
        //    ApplicationUserManager userManager = GetUserManager();
        //    var request = HttpContext.Current;

        //    ApplicationUser user = GetUser(email);

        //    if (user != null)
        //    {
        //        string resetToken = await userManager.GeneratePasswordResetTokenAsync(user.Id);

        //        var urlBuilder = new System.Web.Mvc.UrlHelper(request.Request.RequestContext);
        //        var callbackUrl = urlBuilder.Action("ResetPassword", "Users", new { userId = user.Id, code = resetToken });

        //        EmailAddress emailAddress = new EmailAddress(email, "");
        //        ResetEmailRequest userTarget = new ResetEmailRequest(emailAddress, resetToken, callbackUrl);
        //        await MessagingService.SendPasswordResetEmail(userTarget);

        //    }
        //    return true;

        //}

        ////Changes the password to the new password
        //public async Task<bool> ResetPasswordConfirm(ConfirmPasswordRequest payload)
        //{
        //    ApplicationUserManager userManager = GetUserManager();
        //    var result = await userManager.ResetPasswordAsync(payload.UserId, payload.Code, payload.Password2);
        //    return true;
        //}

        //public async Task<bool> ChangePassword(ChangePasswordRequest payload)
        //{
        //    ApplicationUserManager userManager = GetUserManager();
        //    var user = await userManager.FindByNameAsync(payload.Email);
        //    var result = await userManager.ChangePasswordAsync(user.Id, payload.CurrentPassword, payload.ConfirmNewPassword);
        //    return true;

        //}

        //public async Task<bool> ResendEmailConfirmation(ResendEmailAddRequest email)
        //{

        //    var request = HttpContext.Current;
        //    ApplicationUserManager userManager = GetUserManager();
        //    IdentityUser user = await userManager.FindByEmailAsync(email.Email);
        //    if (user != null)
        //    {
        //        string code = userManager.GenerateEmailConfirmationToken(user.Id);
        //        var urlBuilder = new System.Web.Mvc.UrlHelper(request.Request.RequestContext);
        //        var callbackUrl = urlBuilder.Action("ConfirmEmail", "Users", new { userId = user.Id, code = code });

        //        EmailAddress emailAddress = new EmailAddress(email.Email, "");
        //        ConfirmEmailRequest userTarget = new ConfirmEmailRequest(emailAddress, code, callbackUrl);
        //        await MessagingService.SendConfirmationEmail(userTarget);
        //    }
        //    //So the user will never know if it is a real email or not, always return true..?
        //    return true;
        //}


    }

}

