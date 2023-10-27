using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Web.Model
{
  public class EmailModel
  {
    public string Subject { get; set; }
    public string Body { get; set; }
    public string Recepients { get; set; }
  }
}
