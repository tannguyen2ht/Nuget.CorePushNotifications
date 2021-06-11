using System;
using System.Net.Http;
using System.Threading.Tasks;
using CorePush.Apple;
using CorePush.Google;
using CorePush.Tester.Models;
namespace CorePush.Tester
{
    class Program
    {
        #region Apn Sender Settings

        private const string apnBundleId = "";
        private const string apnP8PrivateKey = "";
        private const string apnP8PrivateKeyId = "";
        private const string apnTeamId = "";
        private const string apnDeviceToken = "";
        private const ApnServerType apnServerType = ApnServerType.Development;

        #endregion

        #region FCM Sender Settings
        private const string fcmReceiverToken = "";
        private const string fcmSenderId = "1010491462237";
        private const string fcmServerKey = "AAAA60X8El0:APA91bGr7rSdU1fdEg_LFC9zf9Mxz5AtuwCVpx79A4Z3A2i9EysVlTn7tYynEecQLEMdIDfSsUFcxRaAmeHqLlTWxjjMPSv9dmXUQN6MWIdwx9I8iVaLYE_fdF-o_N7YKgVSPm8is1j7";

        # endregion

        private static HttpClient http = new HttpClient();

        static async Task Main()
        {
            //await SendApnNotificationAsync();
            await SendFcmNotificationAsync();

            Console.WriteLine("Done!");
        }

        private static async Task SendApnNotificationAsync()
        {
            var settings = new ApnSettings
            {
                AppBundleIdentifier = apnBundleId,
                P8PrivateKey = apnP8PrivateKey,
                P8PrivateKeyId = apnP8PrivateKeyId,
                TeamId = apnTeamId,
                ServerType = apnServerType,
            };

            var apn = new ApnSender(settings, http);
            var payload = new
            {
                notification = new { body = "Hello World!" }
            };

            await apn.SendAsync(payload, apnDeviceToken);
        }

        private static async Task SendFcmNotificationAsync()
        {
            var settings = new FcmSettings
            {
                SenderId = fcmSenderId,
                ServerKey = fcmServerKey
            };

            var fcm = new FcmSender(settings, http);
            var payload = new
            {
                notification = new { body = "Hello World!" }
            };

            var response = await fcm.SendAsync(fcmReceiverToken, payload);
        }
    }
}
