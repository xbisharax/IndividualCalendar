//using MySql.Data.MySqlClient;
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
    public partial class Create_Event : Form
    {
        public Create_Event()
        {
            InitializeComponent();

            // Check if the table already exists before attempting to create it
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
            {
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    // Check if the table exists
                    string checkTableSql = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'csc340_db' AND table_name = 'BisharaEvents'";
                    using (MySql.Data.MySqlClient.MySqlCommand checkTableCmd = new MySql.Data.MySqlClient.MySqlCommand(checkTableSql, conn))
                    {
                        int tableCount = Convert.ToInt32(checkTableCmd.ExecuteScalar());
                        if (tableCount == 0)
                        {
                            // Table doesn't exist, so create it
                            string createTableSql = "CREATE TABLE BisharaEvents (" +
                                "EventId INT AUTO_INCREMENT PRIMARY KEY, " +
                                "Name VARCHAR(1500), " +
                                "Description VARCHAR(1500), " +
                                "Start DATETIME NOT NULL, " +
                                "End DATETIME NOT NULL)";
                            using (MySql.Data.MySqlClient.MySqlCommand createTableCmd = new MySql.Data.MySqlClient.MySqlCommand(createTableSql, conn))
                            {
                                createTableCmd.ExecuteNonQuery();
                                Console.WriteLine("Table created successfully.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Table already exists.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void submit_button_Click_1(object sender, EventArgs e)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            // Data insertion
            string name = event_name_textbox.Text;
            string description = description_textbox.Text;
            DateTime start = start_time_picker.Value;
            DateTime end = end_time_picker.Value;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                // Check if an event with the same name already exists
                string checkSql = "SELECT COUNT(*) FROM bisharaevents WHERE Name = @Name";
                using (MySql.Data.MySqlClient.MySqlCommand checkCmd = new MySql.Data.MySqlClient.MySqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Name", name);
                    int eventCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (eventCount > 0)
                    {
                        MessageBox.Show("An event with the same name already exists. Please choose a different name.", "Duplicate Event Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Exit the method
                    }
                }

                // Check for conflicting events based on start and end times
                string conflictSql = "SELECT * FROM bisharaevents WHERE (@NStart < End AND @NEnd > Start) OR (@NStart = Start OR @NEnd = End)";
                using (MySql.Data.MySqlClient.MySqlCommand conflictCmd = new MySql.Data.MySqlClient.MySqlCommand(conflictSql, conn))
                {
                    conflictCmd.Parameters.AddWithValue("@NStart", start);
                    conflictCmd.Parameters.AddWithValue("@NEnd", end);
                    using (MySql.Data.MySqlClient.MySqlDataReader reader = conflictCmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Conflicting with existing event! Please choose another time.", "Time Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Exit the method
                        }
                    }
                }

                // Insert the event if no conflicts and no duplicate name
                string insertSql = "INSERT INTO bisharaevents (Name, Description, Start, End) VALUES (@Name, @Description, @Start, @End)";
                using (MySql.Data.MySqlClient.MySqlCommand insertCmd = new MySql.Data.MySqlClient.MySqlCommand(insertSql, conn))
                {
                    insertCmd.Parameters.AddWithValue("@Name", name);
                    insertCmd.Parameters.AddWithValue("@Description", description);
                    insertCmd.Parameters.AddWithValue("@Start", start);
                    insertCmd.Parameters.AddWithValue("@End", end);
                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Event created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void cancel_button_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Close();
            home.Show();

        }
    }
}

