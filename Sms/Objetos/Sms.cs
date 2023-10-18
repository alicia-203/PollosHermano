

namespace Objetos
{
  public class Sms
  {
    #region Constructor
    public Sms()
    {

    }
    #endregion Constructor

    #region Propiedades
    public int SmsID { get; set; }
    public string Body { get; set; }
    public string from { get; set; }
    public string to { get; set; }
    #endregion Propiedades
  }
}