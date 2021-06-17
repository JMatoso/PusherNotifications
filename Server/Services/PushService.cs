using System.Threading.Tasks;
using PusherServer;
using PusherServer.Exceptions;

namespace Server.Services
{
    public class PushService
    {
        public async Task Send(string message)
        {
            try
            {
                PusherOptions pusherOptions = new PusherOptions()
                {
                    Cluster = "APP_CLUSTER",
                    Encrypted = true
                };

                Pusher pusher = new Pusher
                (
                    "APP_ID",
                    "APP_KEY",
                    "APP_SECRET",
                    pusherOptions
                );

                await pusher.TriggerAsync(
                    "my-channel",
                    "my-event",
                    new { message = message }
                ).ConfigureAwait(false);
            }
            catch(EventDataSizeExceededException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
