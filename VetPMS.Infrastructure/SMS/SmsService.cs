using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace VetPMS.Infrastructure.SMS
{
    public class SmsService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromNumber;

        public SmsService(string accountSid, string authToken, string fromNumber)
        {
            _accountSid = accountSid;
            _authToken = authToken;
            _fromNumber = fromNumber;

            TwilioClient.Init(_accountSid, _authToken);
        }

        public async Task SendSmsAsync(string toNumber, string message)
        {
            var messageOptions = new CreateMessageOptions(new PhoneNumber(toNumber))
            {
                From = new PhoneNumber(_fromNumber),
                Body = message
            };

            var messageResource = await MessageResource.CreateAsync(messageOptions);
            Console.WriteLine($"Message SID: {messageResource.Sid}");
        }
    }
}
