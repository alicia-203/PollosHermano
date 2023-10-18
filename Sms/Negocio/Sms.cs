
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Negocio
{
	public class Sms
	{
		#region Miembros

		#endregion Miembros

		#region Constructor
		public Sms()
		{
		}
		#endregion Constructor

		#region Metodos
		public bool Enviar(Objetos.Sms pSms, Objetos.TwilioAccount pTwilioAccount)
		{
			string accountSid = pTwilioAccount.accountSid;
			string authToken = pTwilioAccount.authToken;

			TwilioClient.Init(accountSid, authToken);

			var message = MessageResource.Create(
					body: pSms.Body,
					from: new Twilio.Types.PhoneNumber(pSms.from),
					to: new Twilio.Types.PhoneNumber(pSms.to)
			);


			return true;
		}

		#endregion Metodos
	}
}
