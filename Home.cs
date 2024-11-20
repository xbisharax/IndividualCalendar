namespace IndividualCalendar
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        //show calendar
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //do nothing, we are just showing a calendar for now
        }

        //create event
        private void create_event_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Create_Event Create_Event = new Create_Event();
            Create_Event.Show();
        }

        //view events
        private void view_events_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Events View_Events = new View_Events();
            View_Events.Show();
        }
    }
}
