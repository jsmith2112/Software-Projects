using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class CustomMonthCalendar : MonthCalendar
{
    [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
    private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

    protected override void OnHandleCreated(EventArgs e)
    {
        // This line "disables" the Windows theme for this specific control
        SetWindowTheme(this.Handle, "", "");
        base.OnHandleCreated(e);
    }
}
