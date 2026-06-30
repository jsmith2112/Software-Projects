using System;
using System.Drawing;
using System.Windows.Forms;

public class CalendarForm : Form
{
    private MonthCalendar monthCalendar;

    public CalendarForm()
    {
        monthCalendar = new MonthCalendar();

        // Customization
        monthCalendar.Location = new Point(20, 20);
        monthCalendar.ShowWeekNumbers = true;
        monthCalendar.MaxSelectionCount = 7; // Allow selecting up to a week

        // Colors (Note: Certain themes may override these)
        monthCalendar.TitleBackColor = Color.Navy;
        monthCalendar.TitleForeColor = Color.Yellow;

        // Handle date selection
        monthCalendar.DateSelected += (s, e) => {
            MessageBox.Show($"Selected Range: {e.Start.ToShortDateString()} to {e.End.ToShortDateString()}");
        };

        this.Controls.Add(monthCalendar);
        this.Text = "Graphic Calendar Example";
    }
}
