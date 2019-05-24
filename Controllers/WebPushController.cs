using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapidapper.Data;
using webapidapper.Data.Models;
using WebPush;

namespace webapidapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebPushController : ControllerBase
    {
        public WebPushController() { }

        [HttpPost("send")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(string sampleParam)
        {
            //TODO endpoint, auth - retrieve from UI, save to db
            var pushEndpoint = @"https://fcm.googleapis.com/fcm/send/fcQY8aBpBUQ:APA91bHQxER48x97XDAk5P_Ahdjuka7kqRmUGI33gfqP2xLYWoN8Fhc6YYxHxINa02A77kOt-MT7WXkre2cdLpl4Cb7Rc_p7n4SKvPL-enwFVcL2ke7fEPtiB_0gOEi29H_p5_WAsJBt";
            var p256dh = @"BJLeaEQRpqNvCcxK-qoQhmTb_02zIwWY5gTal-124sE89aqE5-gM7c4xlqi-vctsY7tlbr8K9lisw9aKfUfdp_s";
            var auth = @"Vz2aZFiZ7-K6KknndrxSng";
            var subscription = new PushSubscription(pushEndpoint, p256dh, auth);

            var options = new Dictionary<string, object>();
            var subject = @"mailto:example@example.com";
            var publicKey = @"BFVE8GeDN3tHNJJc50Zufq3KkEFRU4vmuxOIVyjw5VxXiQ7KpnZ7vqfvn67hMSLxv6Cbe_308e_V9xffPH5ncjc";
            var privateKey = @"E3utukZxBbaIIH295QqQcxDjAg6GNswsPDhj6Z9HJ2Y";
            options["vapidDetails"] = new VapidDetails(subject, publicKey, privateKey);

            var webPushClient = new WebPushClient();
            try
            {
                await webPushClient.SendNotificationAsync(subscription, sampleParam, options);
                return Ok(sampleParam);
            }
            catch (WebPushException ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
