using System;
using System.Web;

public partial class Global : HttpApplication
{
    protected void Application_Start(object sender, EventArgs e)
    {
        // Khoi tao ung dung
    }

    protected void Session_Start(object sender, EventArgs e)
    {
    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        // Dat header bao mat
        HttpContext.Current.Response.Headers.Remove("X-Powered-By");
        HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
        HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");
        HttpContext.Current.Response.Headers.Remove("Server");
    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
    }

    protected void Application_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        if (ex != null)
        {
            // Log loi neu can
            // EventLog.WriteEntry("BaDongTourism", ex.ToString());
        }
    }

    protected void Session_End(object sender, EventArgs e)
    {
    }

    protected void Application_End(object sender, EventArgs e)
    {
    }
}
