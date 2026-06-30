using System;
using System.Windows.Forms;

public class SimpleBrowserForm : Form
{
    private WebBrowser webBrowser;

    public SimpleBrowserForm()
    {
        // 1. Initialize the browser control
        webBrowser = new WebBrowser();

        // 2. Set it to fill the entire form
        webBrowser.Dock = DockStyle.Fill;

        // 3. Add it to the form's controls
        this.Controls.Add(webBrowser);

        // 4. Navigate to a URL
        webBrowser.Navigate("https://www.google.com");
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new SimpleBrowserForm());
    }
}
