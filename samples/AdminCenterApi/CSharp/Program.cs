using System;
using System.Threading.Tasks;

namespace CSharp
{
    class Program
    {
        // Authentication parameters
        const string aadAppId = "c03f0c34-cd78-4050-a5d8-d0ffce2bf507";         // partner's AAD app id
        const string aadAppRedirectUri = "http://localhost";                    // partner's AAD app redirect URI
        const string aadTenantId = "6bea1ef2-450d-4d02-8af1-4a25a52999aa";      // customer's tenant id

        static async Task Main(string[] args)
        {
            // Get an access token that we can use for making calls to the Business Central Admin Center APIs
            string accessToken = await Authenticate.GetAccessTokenAsync(aadAppId, aadAppRedirectUri, aadTenantId);

            // Manage environments
            await Environments.ListEnvironmentsAsync(accessToken);
            // await Environments.CreateNewEnvironmentAsync(accessToken, "HRPDEMOSandbox", "Sandbox", "HU");
            // await Environments.CopyProductionEnvironmentToSandboxEnvironmentAsync(accessToken, "MyProd", "MyNewSandboxAsACopy", "DK");
            // await Environments.SetAppInsightsKeyAsync(accessToken, "MyProd", new Guid("0da21b54-841e-4a64-a117-6092784245f9"));
            // await Environments.GetDatabaseSizeAsync(accessToken, "MyProd");
            // await Environments.GetSupportSettingsAsync(accessToken, "MyProd");

            // Manage support settings
            // await NotificationRecipients.GetNotificationRecipientsAsync(accessToken);
            // await NotificationRecipients.AddNotificationRecipientAsync(accessToken, "partnernotifications@partnerdomain.com", "Partner Notifications Mail Group");


            // await RapidStart.GetRapidStartPackages(accessToken,"PreviewV17UK","v1.0","669ba303-5ff1-ea11-bba8-000d3a299606");
            await RapidStart.DeletePackage(accessToken,"PreviewV17UK","v1.0","669ba303-5ff1-ea11-bba8-000d3a299606","FITS.DEMO");
            await RapidStart.CreatePackage(accessToken,"PreviewV17UK","v1.0","669ba303-5ff1-ea11-bba8-000d3a299606","FITS.DEMO","FITS.DEMO");
            await RapidStart.UploadPackage(accessToken,"PreviewV17UK","v1.0","669ba303-5ff1-ea11-bba8-000d3a299606","c:\\falu\\workspace\\PackageFITS.DEMO.rapidstart","FITS.DEMO");
            // Manage apps
            // await Apps.GetInstalledAppsAsync(accessToken, "MyProd");
            // await Apps.GetAvailableAppUpdatesAsync(accessToken, "MyProd");
            // await Apps.UpdateAppAsync(accessToken, "MyProd", "334ef79e-547e-4631-8ba1-7a7f18e14de6", "16.0.11240.12188");
            // await Apps.GetAppOperationsAsync(accessToken, "MyProd", "334ef79e-547e-4631-8ba1-7a7f18e14de6");

            // Manage active sessions
            // await Sessions.GetActiveSessionsAsync(accessToken, "MyProd");
            // await Sessions.CancelSessionAsync(accessToken, "MyProd", 12202);

            // Manage update settings
            // await UpdateSettings.GetUpdateWindowAsync(accessToken, "MyProd");
            // await UpdateSettings.SetUpdateWindowAsync(accessToken, "MyProd", new DateTime(2020, 06, 01, 4, 0, 0), new DateTime(2020, 06, 01, 11, 0, 0));
            // await UpdateSettings.GetScheduledUpdatesAsync(accessToken, "MyProd");
        }
    }
}
