using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IndividualCalendar
{
    public partial class Edit_Event : Form
    {
        // Properties to store the edited event details
        public int EventId { get; private set; }
        public string EditedEventName { get; private set; }
        public DateTime EditedStartTime { get; private set; }
        public DateTime EditedEndTime { get; private set; }
        public string EditedDescription { get; private set; }

        public Edit_Event(int eventId, string eventName, DateTime startTime, DateTime endTime, string description)
        {
            InitializeComponent();

            // Initialize form controls with event details
            EventId = eventId; // Store the event ID
            event_name_textbox.Text = eventName;
            start_time_picker.Value = startTime;
            end_time_picker.Value = endTime;
            description_textbox.Text = description;
        }

        private int GetEventId(ListViewItem selectedItem)
        {
            // Assuming the event ID is stored as a tag associated with the ListViewItem
            if (selectedItem.Tag != null && int.TryParse(selectedItem.Tag.ToString(), out int eventId))
            {
                return eventId;
            }
            else
            {
                // Handle the case where the event ID is not available
                MessageBox.Show("Event ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Or any other suitable default value
            }
        }

        private void submit_button_Click_1(object sender, EventArgs e)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            // Data retrieval
            string name = event_name_textbox.Text;
            string description = description_textbox.Text;
            DateTime start = start_time_picker.Value;
            DateTime end = end_time_picker.Value;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                // Update the existing event
                string updateSql = "UPDATE bisharaevents SET Name = @Name, Description = @Description, Start = @Start, End = @End WHERE EventId = @EventId";
                using (MySql.Data.MySqlClient.MySqlCommand updateCmd = new MySql.Data.MySqlClient.MySqlCommand(updateSql, conn))
                {
                    updateCmd.Parameters.AddWithValue("@Name", name);
                    updateCmd.Parameters.AddWithValue("@Description", description);
                    updateCmd.Parameters.AddWithValue("@Start", start);
                    updateCmd.Parameters.AddWithValue("@End", end);
                    updateCmd.Parameters.AddWithValue("@EventId", EventId);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Event updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No event updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Done.");
            }
        }


        private void cancel_button_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
