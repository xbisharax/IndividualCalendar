namespace IndividualCalendar
{
    partial class View_Events
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            edit_event_button = new Button();
            delete_event_button = new Button();
            cancel_button = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(174, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(614, 426);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // edit_event_button
            // 
            edit_event_button.BackColor = Color.LightSteelBlue;
            edit_event_button.Location = new Point(12, 12);
            edit_event_button.Name = "edit_event_button";
            edit_event_button.Size = new Size(133, 70);
            edit_event_button.TabIndex = 4;
            edit_event_button.Text = "Edit Event";
            edit_event_button.UseVisualStyleBackColor = false;
            edit_event_button.Click += edit_event_button_Click;
            // 
            // delete_event_button
            // 
            delete_event_button.BackColor = Color.LightSteelBlue;
            delete_event_button.Location = new Point(12, 88);
            delete_event_button.Name = "delete_event_button";
            delete_event_button.Size = new Size(133, 70);
            delete_event_button.TabIndex = 5;
            delete_event_button.Text = "Delete Event";
            delete_event_button.UseVisualStyleBackColor = false;
            delete_event_button.Click += delete_event_button_Click;
            // 
            // cancel_button
            // 
            cancel_button.BackColor = Color.LightSalmon;
            cancel_button.Location = new Point(12, 368);
            cancel_button.Name = "cancel_button";
            cancel_button.Size = new Size(133, 70);
            cancel_button.TabIndex = 10;
            cancel_button.Text = "Back";
            cancel_button.UseVisualStyleBackColor = false;
            cancel_button.Click += cancel_button_Click;
            // 
            // View_Events
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cancel_button);
            Controls.Add(delete_event_button);
            Controls.Add(edit_event_button);
            Controls.Add(listView1);
            Name = "View_Events";
            Text = "View Events";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private Button edit_event_button;
        private Button delete_event_button;
        private Button cancel_button;
    }
}