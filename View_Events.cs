using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualCalendar
{
    public partial class View_Events : Form
    {
        public View_Events()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("Event Name", 100); // Adjust the width as needed
            listView1.Columns.Add("Start Time", 175); // Adjust the width as needed
            listView1.Columns.Add("End Time", 175); // Adjust the width as needed
            listView1.Columns.Add("Description", 300); // Adjust the width as needed
            DisplayEventsInList();
        }

        private void DisplayEventsInList()
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT EventId, Name, Start, End, Description FROM bisharaevents";

                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        using (MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear existing items in the ListView
                            listView1.Items.Clear();

                            while (reader.Read())
                            {
                                int eventId = reader.GetInt32(0); // Event ID
                                string eventName = reader.GetString(1); // Event Name
                                DateTime startTime = reader.GetDateTime(2); // Start Time
                                DateTime endTime = reader.GetDateTime(3); // End Time
                                string description = reader.GetString(4); // Description

                                // Create a ListViewItem with the event name
                                ListViewItem item = new ListViewItem(eventName);

                                // Set the event ID as the tag of the ListViewItem
                                item.Tag = eventId;

                                // Add sub-items for start time, end time, and description
                                item.SubItems.Add(startTime.ToString());
                                item.SubItems.Add(endTime.ToString());
                                item.SubItems.Add(description);

                                // Add the ListViewItem to the ListView
                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void delete_event_button_Click(object sender, EventArgs e)
        {
            // Check if any item is selected in the ListView
            if (listView1.SelectedItems.Count > 0)
            {
                // Iterate over selected items and delete corresponding events
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    int eventId = (int)selectedItem.Tag; // Get the event ID
                    // Additional code to delete the event with the given ID from the database
                    DeleteEvent(eventId);
                    // Remove the selected item from the ListView
                    listView1.Items.Remove(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("Please select an event to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to delete an event from the database
        private void DeleteEvent(int eventId)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "DELETE FROM bisharaevents WHERE EventId = @eventId";

                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        // Add parameter to the query to prevent SQL injection
                        cmd.Parameters.AddWithValue("@eventId", eventId);

                        // Execute the DELETE command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Event deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Event not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void edit_event_button_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the ListView
            if (listView1.SelectedItems.Count == 1)
            {
                // Retrieve the selected event details
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int eventId = (int)selectedItem.Tag; // Get the event ID from the selected item
                string eventName = selectedItem.Text;
                string startTimeStr = selectedItem.SubItems[1].Text;
                string endTimeStr = selectedItem.SubItems[2].Text;
                string description = selectedItem.SubItems[3].Text;

                // Parse string to DateTime
                DateTime startTime = DateTime.Parse(startTimeStr);
                DateTime endTime = DateTime.Parse(endTimeStr);

                // Show the edit event form and pass the event details
                Edit_Event editForm = new Edit_Event(eventId, eventName, startTime, endTime, description);
                editForm.ShowDialog();

                // After editing, refresh the list view to reflect the changes
                DisplayEventsInList();
            }
            else
            {
                MessageBox.Show("Please select a single event to edit.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int GetEventIdFromSelectedItem(ListViewItem selectedItem)
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


        private void cancel_button_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Close();
            home.Show();
        }
    }
}
