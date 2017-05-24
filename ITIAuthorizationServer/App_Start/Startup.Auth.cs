


using ITIAuthorizationServer.Constants;
using ITIAuthorizationServer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Owin;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Client = ITIAuthorizationServer.Models.Client;

namespace ITIAuthorizationServer
{
    //grant_type=password&username=demo1&password=demo1&Client_Id=123456&client_secret=abcdef&logtype=1&client_Type=android&clientOsVersion=19
    public partial class Startup
    {
        private int loginType=0;
        private string client_Type = "";
        private string clientOsVersion = "";
        public static List<Client> InmemoryClient
        {
            get { return InMemortClient(); }
             }
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
           // List<Models.Client> inmemoryClient = InMemortClient();
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
          //  app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Account/Login"),
            //    Provider = new CookieAuthenticationProvider
            //    {
            //        // Enables the application to validate the security stamp when the user logs in.
            //        // This is a security feature which is used when you change a password or add an external login to your account.  
            //        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
            //            validateInterval: TimeSpan.FromMinutes(30),
            //            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
            //    }
            //});            
         //   app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
          //  app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
         //   app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
            // Setup Authorization Server
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AuthorizeEndpointPath = new PathString(Paths.AuthorizePath),
                TokenEndpointPath = new PathString(Paths.TokenPath),
                ApplicationCanDisplayErrors = true,
#if DEBUG
                AllowInsecureHttp = true,
#endif
                // Authorization server provider which controls the lifecycle of Authorization Server
                Provider = new OAuthAuthorizationServerProvider
                {
                    OnValidateClientRedirectUri = ValidateClientRedirectUri,
                    OnValidateClientAuthentication = ValidateClientAuthentication,
                    OnGrantResourceOwnerCredentials = GrantResourceOwnerCredentials,
                    OnGrantClientCredentials = GrantClientCredetails,
                    OnTokenEndpoint = TokenEndpoint
                },

                // Authorization code provider which creates and receives authorization code
                AuthorizationCodeProvider = new AuthenticationTokenProvider
                {
                    OnCreate = CreateAuthenticationCode,
                    OnReceive = ReceiveAuthenticationCode,
                },

                // Refresh token provider which creates and receives referesh token
                RefreshTokenProvider = new AuthenticationTokenProvider
                {
                    OnCreate = CreateRefreshToken,
                    OnReceive = ReceiveRefreshToken,
                },
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(10)
            });
        }

        private Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            //if (context.ClientId == Clients.Client1.Id)
            //{
            //    context.Validated(Clients.Client1.RedirectUrl);
            //}
            //else if (context.ClientId == Clients.Client2.Id)
            //{
            //    context.Validated(Clients.Client2.RedirectUrl);
            //}
            context.Validated(InmemoryClient.FirstOrDefault( x=>x.ClientId == context.ClientId).ClientUri);
            return Task.FromResult(0);
        }

        public static List<Models.Client> InMemortClient()
        {
            ITIAuthorizationServerEntities db = new ITIAuthorizationServerEntities();
          return  db.Clients.Where(x => x.Enabled.Value == true).ToList();
        }
        private Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
       // private Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
             loginType = int.Parse(context.Parameters["logtype"]);
            client_Type = context.Parameters["client_Type"];
            clientOsVersion = context.Parameters["clientOsVersion"];
            if (context.TryGetBasicCredentials(out clientId, out clientSecret) ||
                context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                var xx = InmemoryClient;
                if (clientId == InmemoryClient.FirstOrDefault(x => x.ClientId == context.ClientId).ClientId && clientSecret == InmemoryClient.FirstOrDefault(x => x.ClientId == context.ClientId).ClientSecrets)
                {
                    //if (InmemoryClient.FirstOrDefault(x => x.ClientId == context.ClientId).FlowID==2)
                    //{

                    //    //add device id
                    //    UserDevice userDevice = new UserDevice();
                    //    userDevice.DevicesID = clientId;
                    //    userDevice.DevicesOS = client_Type;
                    //    userDevice.DevicesOsVersion = clientOsVersion;
                    //    userDevice.EmployeeID = results.EmployeeID;

                    //    new UserDeviceManager().AddUserDevice(userDevice);
                    //    using (var client = new HttpClient())
                    //    {
                    //        client.BaseAddress = new Uri(Paths.AuthorizationServerBaseAddress+Paths.ResourceServerBaseAddress);
                    //        client.DefaultRequestHeaders.Accept.Clear();
                    //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //        StringContent content = new StringContent(JsonConvert.SerializeObject(product));
                    //        // HTTP POST
                    //        HttpResponseMessage response = await client.PostAsync("api/products/save", content);
                    //        if (response.IsSuccessStatusCode)
                    //        {
                    //            string data = await response.Content.ReadAsStringAsync();
                    //            product = JsonConvert.DeserializeObject<Product>(data);
                    //        }
                    //    }
                    //}
                    context.Validated();
                }
               
            }
            return Task.FromResult(0);
        }

        private Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            var user=new User() ;
            //employee
            if (loginType ==1)
            {
                 user =
                Users.Get().FirstOrDefault(x => x.IPassword == context.Password && x.UserName2 == context.UserName);
            }
            
            if (user !=null)
            {
                 identity.AddClaim(new Claim("role", "user"));
            identity.AddClaim(new Claim("guid", user.EmployeeID.ToString()));
                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "UserID", user.EmployeeID.ToString()
                    },
                    {
                        "EmployeeName", user.InstructorName
                    },

                    {
                        "ViewSchedule", "true"
                    },
                    {
                        "ViewEvaluation", "false"
                    }

                });
                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return Task.FromResult<object>(null);
            }

            var student = new Student();
            //sudent
            if (loginType == 2)
            {
                student =
               Students.Get().FirstOrDefault(x => x.IPassword == context.Password && x.UserName2 == context.UserName);
           

            if (student != null)
            {
                identity.AddClaim(new Claim("role", "student"));
                identity.AddClaim(new Claim("guid", student.StudentID.ToString()));
                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "StudentID", student.StudentID.ToString()
                    },
                    {
                        "StudentName", student.englishname
                    },

                    {
                        "TrackID", student.TrackID.ToString()
                    },
                    {
                        "BranchID", student.BranchID.ToString( )
                    }

                });
                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            } 
            else
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return Task.FromResult<object>(null);
            }
}
            var company = new Company();
            //sudent
            if (loginType == 3)
            {
                company =
               Companys.Get().FirstOrDefault(x => x.CompanyPassWord == context.Password && x.CompanyUserName == context.UserName);


                if (company != null)
                {
                    identity.AddClaim(new Claim("role", "Company"));
                    identity.AddClaim(new Claim("guid", company.CompanyID.ToString()));
                    var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "CompanyID", company.CompanyID.ToString()
                    },
                    {
                        "CompanyName", company.CompanyName
                    },

                    {
                        "CompanyApprove", company.CompanyApprove.ToString()
                    }

                });
                    var ticket = new AuthenticationTicket(identity, props);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return Task.FromResult<object>(null);
                }
            }
            //identity.AddClaim(new Claim("clientId", clientId));
            //identity.AddClaim(new Claim("client_Type", client_Type));
            //identity.AddClaim(new Claim("clientOsVersion", clientOsVersion));
            //  var identity = new ClaimsIdentity(new GenericIdentity(context.UserName, OAuthDefaults.AuthenticationType), context.Scope.Select(x => new Claim("urn:oauth:scope", x)));


            // context.Validated(identity);

            // return Task.FromResult(0);
            return Task.FromResult<object>(null);
        }

        private Task GrantClientCredetails(OAuthGrantClientCredentialsContext context)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(context.ClientId, OAuthDefaults.AuthenticationType), context.Scope.Select(x => new Claim("urn:oauth:scope", x)));

            context.Validated(identity);

            return Task.FromResult(0);
        }


        private readonly ConcurrentDictionary<string, string> _authenticationCodes =
            new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

        private void CreateAuthenticationCode(AuthenticationTokenCreateContext context)
        {
            context.SetToken(Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n"));
            _authenticationCodes[context.Token] = context.SerializeTicket();
        }

        private void ReceiveAuthenticationCode(AuthenticationTokenReceiveContext context)
        {
            string value;
            if (_authenticationCodes.TryRemove(context.Token, out value))
            {
                context.DeserializeTicket(value);
            }
        }

        private void CreateRefreshToken(AuthenticationTokenCreateContext context)
        {
            context.SetToken(context.SerializeTicket());
        }

        private void ReceiveRefreshToken(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
        public Task  TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

           return Task.FromResult<object>(null);
        }
    }

    internal class UserDevice
    {
        public string DevicesID { get; internal set; }
        public object DevicesOS { get; internal set; }
        public object DevicesOsVersion { get; internal set; }
        public object EmployeeID { get; internal set; }
    }
}