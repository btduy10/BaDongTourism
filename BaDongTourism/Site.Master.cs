using System;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HighlightActiveMenu();
    }

    private void HighlightActiveMenu()
    {
        string path = Request.AppRelativeCurrentExecutionFilePath.ToLower();
        // Them class active cho menu tuong ung (xu ly phia client o main.js)
    }
}
