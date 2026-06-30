using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace CalendarApp

{

    public partial class MainForm : Form

    {

        // Dictionary to store events for each date

        private Dictionary<DateTime, List<string>> events = new Dictionary<DateTime, List<string>>();



        public MainForm()

        {

            InitializeComponent();

        }



        private void MainForm_Load(object sender, EventArgs e)

        {

            monthCalendar1.MaxSelectionCount = 1; // Only one date at a time

        }



        // Add event button click

        private void btnAddEvent_Click(object sender, EventArgs e)

        {

            DateTime selectedDate = monthCalendar1.SelectionStart;

            string eventText = txtEvent.Text.Trim();



            if (string.IsNullOrEmpty(eventText))

            {

                MessageBox.Show("Please enter an event description.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;

            }



            if (!events.ContainsKey(selectedDate))

            {

                events[selectedDate] = new List<string>();

            }

            monthCalendar1.AddBoldedDate(selectedDate);
            monthCalendar1.UpdateBoldedDates();

            events[selectedDate].Add(eventText);



            txtEvent.Clear();

            DisplayEvents(selectedDate);

        }



        // Display events for selected date

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)

        {

            DisplayEvents(e.Start);

        }



        private void DisplayEvents(DateTime date)

        {

            lstEvents.Items.Clear();



            if (events.ContainsKey(date))

            {

                foreach (var ev in events[date])

                {

                    lstEvents.Items.Add(ev);

                }

            }

            else

            {

                lstEvents.Items.Add("(No events)");

            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Check if an item is actually selected in the ListBox
            if (lstEvents.SelectedIndex == -1 || lstEvents.SelectedItem.ToString() == "(No events)")
            {
                return;
            }

            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            string selectedEvent = lstEvents.SelectedItem.ToString();

            // 1. Remove from Dictionary
            if (events.ContainsKey(selectedDate))
            {
                events[selectedDate].Remove(selectedEvent);

                // 2. If no events are left for this date, clean up
                if (events[selectedDate].Count == 0)
                {
                    events.Remove(selectedDate);

                    // 3. Unbold the date on the calendar
                    monthCalendar1.RemoveBoldedDate(selectedDate);
                    monthCalendar1.UpdateBoldedDates();
                }
            }

            // Refresh the list display
            DisplayEvents(selectedDate);
        }

    }

}