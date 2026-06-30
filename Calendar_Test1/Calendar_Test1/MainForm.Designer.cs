namespace CalendarApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // 1. Change type from System.Windows.Forms.MonthCalendar to CustomMonthCalendar
        private CustomMonthCalendar monthCalendar1;

        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.ListBox lstEvents;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.monthCalendar1 = new CalendarApp.CustomMonthCalendar();
            this.SuspendLayout();
            // 
            // txtEvent
            // 
            this.txtEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEvent.Location = new System.Drawing.Point(453, 21);
            this.txtEvent.Multiline = true;
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(235, 50);
            this.txtEvent.TabIndex = 1;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEvent.Location = new System.Drawing.Point(458, 88);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(113, 39);
            this.btnAddEvent.TabIndex = 2;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEvent.Location = new System.Drawing.Point(577, 88);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(111, 39);
            this.btnDeleteEvent.TabIndex = 4;
            this.btnDeleteEvent.Text = "Delete";
            this.btnDeleteEvent.Click += new System.EventHandler(this.Delete_Click);
            // 
            // lstEvents
            // 
            this.lstEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEvents.ItemHeight = 29;
            this.lstEvents.Location = new System.Drawing.Point(453, 142);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(235, 178);
            this.lstEvents.TabIndex = 3;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(753, 514);
            this.Controls.Add(this.btnDeleteEvent);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.txtEvent);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "MainForm";
            this.Text = "Calendar App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
