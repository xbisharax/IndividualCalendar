namespace IndividualCalendar
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            create_event_button = new Button();
            monthCalendar1 = new MonthCalendar();
            view_events_button = new Button();
            titlebox = new TextBox();
            SuspendLayout();
            // 
            // create_event_button
            // 
            create_event_button.BackColor = Color.LightSteelBlue;
            create_event_button.Location = new Point(94, 292);
            create_event_button.Name = "create_event_button";
            create_event_button.Size = new Size(133, 70);
            create_event_button.TabIndex = 1;
            create_event_button.Text = "Create Event";
            create_event_button.UseVisualStyleBackColor = false;
            create_event_button.Click += create_event_button_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(94, 73);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // view_events_button
            // 
            view_events_button.BackColor = Color.LightSteelBlue;
            view_events_button.Location = new Point(223, 292);
            view_events_button.Name = "view_events_button";
            view_events_button.Size = new Size(133, 70);
            view_events_button.TabIndex = 4;
            view_events_button.Text = "View Events";
            view_events_button.UseVisualStyleBackColor = false;
            view_events_button.Click += view_events_button_Click;
            // 
            // titlebox
            // 
            titlebox.BackColor = Color.Snow;
            titlebox.Font = new Font("Unispace", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titlebox.Location = new Point(65, 12);
            titlebox.Multiline = true;
            titlebox.Name = "titlebox";
            titlebox.ReadOnly = true;
            titlebox.Size = new Size(325, 49);
            titlebox.TabIndex = 5;
            titlebox.Text = "Event Calendar";
            titlebox.TextAlign = HorizontalAlignment.Center;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 384);
            Controls.Add(titlebox);
            Controls.Add(view_events_button);
            Controls.Add(monthCalendar1);
            Controls.Add(create_event_button);
            Name = "Home";
            Text = "Home";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button create_event_button;
        private MonthCalendar monthCalendar1;
        private Button view_events_button;
        private TextBox titlebox;
    }
}
