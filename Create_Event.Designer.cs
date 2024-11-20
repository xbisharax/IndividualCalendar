namespace IndividualCalendar
{
    partial class Create_Event
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
            submit_button = new Button();
            event_name_textbox = new TextBox();
            label1 = new Label();
            description_textbox = new TextBox();
            label2 = new Label();
            start_label = new Label();
            end_label = new Label();
            start_time_picker = new DateTimePicker();
            end_time_picker = new DateTimePicker();
            mySqlConnection1 = new MySql.Data.MySqlClient.MySqlConnection();
            cancel_button = new Button();
            SuspendLayout();
            // 
            // submit_button
            // 
            submit_button.BackColor = Color.LightSteelBlue;
            submit_button.Location = new Point(12, 367);
            submit_button.Name = "submit_button";
            submit_button.Size = new Size(94, 29);
            submit_button.TabIndex = 0;
            submit_button.Text = "Submit";
            submit_button.UseVisualStyleBackColor = false;
            submit_button.Click += submit_button_Click_1;
            // 
            // event_name_textbox
            // 
            event_name_textbox.Location = new Point(12, 32);
            event_name_textbox.Name = "event_name_textbox";
            event_name_textbox.Size = new Size(382, 27);
            event_name_textbox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 2;
            label1.Text = "Event Name";
            // 
            // description_textbox
            // 
            description_textbox.Location = new Point(12, 106);
            description_textbox.Multiline = true;
            description_textbox.Name = "description_textbox";
            description_textbox.Size = new Size(382, 118);
            description_textbox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 83);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 4;
            label2.Text = "Event Description";
            // 
            // start_label
            // 
            start_label.AutoSize = true;
            start_label.Location = new Point(6, 247);
            start_label.Name = "start_label";
            start_label.Size = new Size(77, 20);
            start_label.TabIndex = 5;
            start_label.Text = "Start Time";
            // 
            // end_label
            // 
            end_label.AutoSize = true;
            end_label.Location = new Point(203, 247);
            end_label.Name = "end_label";
            end_label.Size = new Size(71, 20);
            end_label.TabIndex = 6;
            end_label.Text = "End Time";
            // 
            // start_time_picker
            // 
            start_time_picker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            start_time_picker.Format = DateTimePickerFormat.Custom;
            start_time_picker.Location = new Point(6, 270);
            start_time_picker.Name = "start_time_picker";
            start_time_picker.Size = new Size(191, 27);
            start_time_picker.TabIndex = 7;
            // 
            // end_time_picker
            // 
            end_time_picker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            end_time_picker.Format = DateTimePickerFormat.Custom;
            end_time_picker.Location = new Point(203, 270);
            end_time_picker.Name = "end_time_picker";
            end_time_picker.Size = new Size(191, 27);
            end_time_picker.TabIndex = 8;
            // 
            // cancel_button
            // 
            cancel_button.BackColor = Color.LightSalmon;
            cancel_button.Location = new Point(300, 367);
            cancel_button.Name = "cancel_button";
            cancel_button.Size = new Size(94, 29);
            cancel_button.TabIndex = 9;
            cancel_button.Text = "Back";
            cancel_button.UseVisualStyleBackColor = false;
            cancel_button.Click += cancel_button_Click;
            // 
            // Create_Event
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 408);
            Controls.Add(cancel_button);
            Controls.Add(end_time_picker);
            Controls.Add(start_time_picker);
            Controls.Add(end_label);
            Controls.Add(start_label);
            Controls.Add(label2);
            Controls.Add(description_textbox);
            Controls.Add(label1);
            Controls.Add(event_name_textbox);
            Controls.Add(submit_button);
            Name = "Create_Event";
            Text = "Create Event";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submit_button;
        private TextBox event_name_textbox;
        private Label label1;
        private TextBox description_textbox;
        private Label label2;
        private Label start_label;
        private Label end_label;
        private DateTimePicker start_time_picker;
        private DateTimePicker end_time_picker;
        private MySql.Data.MySqlClient.MySqlConnection mySqlConnection1;
        private Button cancel_button;
    }
}