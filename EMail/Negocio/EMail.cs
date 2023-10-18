using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Negocio
{
  public class EMail
  {
		#region Miembros

		#endregion Miembros

		#region Constructor
		public EMail()
    {
		}
    #endregion Constructor

    #region Metodos
    public bool Enviar(Objetos.EMail pEMail, Objetos.Attachment pAttachment, Objetos.SmtpClient pSmtpClient)
    {
				MailMessage lEmail = new MailMessage();

				foreach (string lDestinatario in pEMail.Destinatario.Split(new char[] { ';' }))
				{
					lEmail.Bcc.Add(new MailAddress(lDestinatario));

				}

				lEmail.From = new MailAddress(pSmtpClient.Remitente);
				lEmail.Subject = pEMail.Subject;
				lEmail.Body = pEMail.Body;
				lEmail.IsBodyHtml = true;
				lEmail.Priority = (MailPriority)pEMail.Priority;

				Attachment lArchivoAdjuntar = new Attachment(new MemoryStream(pAttachment.ArchivoBytes), pAttachment.Nombre.ToString());
				lEmail.Attachments.Add(lArchivoAdjuntar);

				AlternateView lHtmlView = AlternateView.CreateAlternateViewFromString(pEMail.Body,
											Encoding.UTF8,
											MediaTypeNames.Text.Html);

				lEmail.AlternateViews.Add(lHtmlView);

				SmtpClient lSmtp = new SmtpClient();
				lSmtp.Host = pSmtpClient.Host;
				lSmtp.Port = pSmtpClient.Port;
				lSmtp.EnableSsl = pSmtpClient.EnableSsl; 
				lSmtp.Credentials = new NetworkCredential(pSmtpClient.Remitente, pSmtpClient.Contraseña);

				lSmtp.Send(lEmail);
				lEmail.Dispose();

        return true;
		}

    #endregion Metodos
  }
}
