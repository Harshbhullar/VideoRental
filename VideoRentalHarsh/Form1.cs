using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace VideoRentalHarsh
{
    //c#.net doesnot support the concept of multiple inheritance sow e have to use the concpt of interface for these things 
    interface database {
        // method of the interface
         void dataInsert(String query);
        void dataDelete(String query);
        void dataUpdate(String query);
        int datacharges(int Year);

    }
    public partial class Form1 : Form
    {
        //creating the instance object of the global class that is used to create  the connection between the database and the main frame and pass the value to the database for permanent storage 
        SqlConnection connection;
        String connectionStr = "Data Source=LAPTOP-OIRKFLCJ\\SQLEXPRESS;Initial Catalog=HarshDB;Integrated Security=True";
        SqlCommand command;
        SqlDataReader Datareader;
        public int R_ID = 0,M_Copies=0,M_Cost=0;
        public String Table = "";


        public Form1()
        {
            InitializeComponent();
        }
        //this method is used to calcaute the charges of the movie that will be charged at the time of rent 
        public int charges(int Year)
        {
            //dislay the cost of the price of the video after adding the year of the video
            DateTime date_Now = DateTime.Now;

            int Current_year = date_Now.Year;

            int diff_Year = Current_year -Year;
            // MessageBox.Show(diff.ToString());
            if (diff_Year >= 5)
            {
                Video_Cost.Text = "2";
            }
            if (diff_Year >= 0 && diff_Year < 5)
            {
                Video_Cost.Text = "5";
            }

            throw new NotImplementedException();
        }
        public void Delete(string query)
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            
        }

        //this method id used to return the record  of the table from database and then pass to the data grid view for the gui view
        public DataTable Srch(String table)
        {
            DataTable tbl = new DataTable();


            connection = new SqlConnection(connectionStr);

            connection.Open();
            command = new SqlCommand("select * from "+table , connection);

            Datareader = command.ExecuteReader();

            tbl.Load(Datareader);

            connection.Close();

            return tbl;
        }

        //this method id used to return the record  of the table from database and then pass to the data grid view for the gui view
        public DataTable SelectData(String cmd)
        {
            DataTable tbl = new DataTable();


            connection = new SqlConnection(connectionStr);

            connection.Open();
            command = new SqlCommand(cmd, connection);

            Datareader = command.ExecuteReader();

            tbl.Load(Datareader);

            connection.Close();

            return tbl;
        }

        //this is  the code to implement the method of the interface in the class with the help of exception handling format like throw exception 
        public void Insert(string query)
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();
            command= new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            
        }

        public void Update(string query)

        {
            connection = new SqlConnection(connectionStr);
            connection.Open();
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

            
        }
        




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Add_Video_Click(object sender, EventArgs e)
        {
            // this block is used to add the recor to the movie_table in the database that is used insert the record with the help of exception method try-catch
            // try {

            String cmd = "insert into Movie_Table(Video_title,Video_Ratting,Video_Year,Video_Cost,Video_Copies,Video_Plot,Video_Genre) values('" + Video_title.Text.ToString() + "','" + Video_Ratting.Text.ToString() + "'," + Convert.ToInt32(Video_Year.Text.ToString()) + "," + Convert.ToInt32(Video_Cost.Text.ToString()) + "," + Convert.ToInt32(Video_Copies.Text.ToString()) + ",'" + Video_Plot.Text.ToString() + "','" + Video_Genre.Text.ToString() + "')";
                Insert(cmd);
                MessageBox.Show("Movie Record is Saved");
                //this method id used to clear all the text boxes and datagridview

                clearAll();


            /*}

            catch (Exception ex) {
                //if there is an error occured then the block will be print the error message 
                MessageBox.Show(ex.Message.ToString());
            }*/
            

        }

        private void delete_Video_Click(object sender, EventArgs e)
        {
            // this block is used to delete the record to the movie_table in the database that is used delete the record with the help of exception method try-catch
          //  try
           // {
                
                String cmd = "delete from Movie_Table where id="+Convert.ToInt32(MIDTxtBox.Text.ToString())+"";
                Delete(cmd);
                MessageBox.Show("Movie Record is Deleted");
                //this method id used to clear all the text boxes and datagridview

                clearAll();


            /*}

            catch (Exception ex)
            {
                //if there is an error occured then the block will be print the error message 
                MessageBox.Show(ex.Message.ToString());
            }*/

        }

        private void update_Video_Click(object sender, EventArgs e)
        {
            // this block is used to Update the record to the movie_table in the database that is used Update the record with the help of exception method try-catch
            try
            {
                String cmd = "update Movie_Table set Video_title='" + Video_title.Text.ToString() + "',Video_Ratting='" + Video_Ratting.Text.ToString() + "',Video_Year=" + Convert.ToInt32(Video_Year.Text.ToString()) + ",Video_Cost=" + Convert.ToInt32(Video_Cost.Text.ToString()) + ",Video_Copies=" + Convert.ToInt32(Video_Copies.Text.ToString()) + ",Video_Plot='" + Video_Plot.Text.ToString() + "',Video_Genre='" + Video_Genre.Text.ToString() + "' where id=" + Convert.ToInt32(MIDTxtBox.Text.ToString()) + "";
                Insert(cmd);
                MessageBox.Show("Movie Record is Updated");
                //this method id used to clear all the text boxes and datagridview

                clearAll();


            }

            catch (Exception ex)
            {
                //if there is an error occured then the block will be print the error message 
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void Insert_Customer_Click(object sender, EventArgs e)
        {

            // this block is used to add the record to the Customer_table in the database that is used insert the record with the help of exception method try-catch
            try
            {
                String cmd = "insert into Customer_Table (Customer_Name,Customer_LName,Customer_PhNo,Customer_Address) values('"+Customer_Name.Text.ToString()+"','"+Customer_LName.Text.ToString()+"','"+Customer_PhNo.Text.ToString()+"','"+Customer_Address.Text.ToString()+"')";
                Insert(cmd);
                MessageBox.Show("Customer is Registered in the portal ");
                //this method id used to clear all the text boxes and datagridview

                clearAll();


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void delete_Customer_Click(object sender, EventArgs e)
        {
            // this block is used to delete the record to the movie_table in the database that is used delete the record with the help of exception method try-catch
            try
            {

                String cmd = "delete from Customer_Table where id=" + Convert.ToInt32(C_IDTxtBox.Text.ToString()) + "";
                Delete(cmd);
                MessageBox.Show("Customer Record is Deleted from the Portal");
                //this method id used to clear all the text boxes and datagridview

                clearAll();


            }

            catch (Exception ex)
            {
                //if there is an error occured then the block will be print the error message 
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void update_Customer_Click(object sender, EventArgs e)
        {
            // this block is used to Upate the record to the Customer_table in the database that is used Update the record with the help of exception method try-catch
            try
            {
                String cmd = "Update Customer_Table set Customer_Name='" + Customer_Name.Text.ToString() + "',Customer_LName='" + Customer_LName.Text.ToString() + "',Customer_PhNo='" + Customer_PhNo.Text.ToString() + "',Customer_Address='" + Customer_Address.Text.ToString() + "' where id=" + Convert.ToInt32(C_IDTxtBox.Text.ToString()) + "";
                Insert(cmd);
                MessageBox.Show("Customer Details are Updated in the portal ");
                //this method id used to clear all the text boxes and datagridview

                clearAll();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void rentalIssue_Click(object sender, EventArgs e)
        {
            // this block is used to add the record to the Booking_table in the database that is used Insert the record with the help of exception method try-catch
            try
            {
                String cmd = "";
                int no_Of_Booking = 0;

                DataTable tblBooking = new DataTable();


                cmd = "select * from Customer_Booking where id=" + Convert.ToInt32(C_IDTxtBox.Text.ToString()) + " ";
                DataTable tbl = new DataTable();
                tbl = SelectData(cmd);
                if (tbl.Rows.Count > 0)
                {
                    no_Of_Booking = Convert.ToInt32(tbl.Rows[tbl.Rows.Count - 1]["Booking"].ToString());
                   
                }
               /* else {
                   
                    
                }*/




                String cmd1 = "select * from Booking_Table where id=" + Convert.ToInt32(MIDTxtBox.Text.ToString()) + " and Return_Date='Booked'";
                tblBooking = SelectData(cmd1);

                if (no_Of_Booking < 2 && tblBooking.Rows.Count < M_Copies)
                {
                    if (no_Of_Booking == 0)
                    {
                        cmd = "";
                        cmd = "insert into Customer_Booking(Customer_Id,Booking) values(" + Convert.ToInt32(C_IDTxtBox.Text.ToString()) + ",1)";
                        Insert(cmd);
                    }
                    else {
                        cmd = "";
                        cmd = "Update Customer_Booking set Booking=2 where Customer_Id=" + Convert.ToInt32(C_IDTxtBox.Text.ToString()) + "";
                        Update(cmd);
                    }

                    cmd = "";
                    cmd = "insert into Booking_Table(C_Id,M_Id,issued_Date,Return_Date) values(" + Convert.ToInt32(C_IDTxtBox.Text.ToString()) + "," + Convert.ToInt32(MIDTxtBox.Text.ToString()) + ",'" + Issue.Text.ToString() + "','Booked')";
                    Insert(cmd);

                    MessageBox.Show("Movie is Sent on Rent to the Regsitered Customer");
                }
                else {
                    MessageBox.Show("No More Caste or Customer has already Booked 2 movies ");
                }
                //this method id used to clear all the text boxes and datagridview

                clearAll();
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void clearAll() {
            C_IDTxtBox.Text = "";

            MIDTxtBox.Text = "";

            Video_title.Text = "";
            Video_Year.Text = "";
            Video_Ratting.Text = "";
            Video_Cost.Text = "";
            Video_Copies.Text = "";
            Video_Plot.Text = "";
            Video_Genre.Text = "";

            Customer_LName.Text = "";
            Customer_Name.Text = "";
            Customer_Address.Text = "";

            Customer_PhNo.Text = "";


        }
        private void rentalDelete_Click(object sender, EventArgs e)
        {
            // this block is used to Delete the record to the Booking_table in the database that is used Delete the record with the help of exception method try-catch
            try
            {
                String cmd = "delete from Booking_Table where id=" + R_ID + "";
                Delete(cmd);
                MessageBox.Show("Rental Movie is Deleted from the Portal which is Unfortunately Recorded");
                //this method id used to clear all the text boxes and datagridview

                clearAll();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void rentalReturn_Click(object sender, EventArgs e)
        {
            // this block is used to Upate the record to the Booking_table in the database that is used Update the record with the help of exception method try-catch
            try
            {
                String cmd = "";

                int no_Of_Booking = 0;

                DataTable tblBooking = new DataTable();


                cmd = "select * from Customer_Booking where id=" + Convert.ToInt32(C_IDTxtBox.Text.ToString()) + " ";
                DataTable tbl = new DataTable();
                tbl = SelectData(cmd);
                if (tbl.Rows.Count > 0)
                {
                    no_Of_Booking = Convert.ToInt32(tbl.Rows[tbl.Rows.Count - 1]["Booking"].ToString());

                }
                MessageBox.Show("" + no_Of_Booking);
                if (no_Of_Booking >= 0)
                {

                    no_Of_Booking = no_Of_Booking - 1;

                    cmd = "";
                    cmd = "Update Customer_Booking set Booking="+Convert.ToInt32(no_Of_Booking)+" where Customer_Id=" + Convert.ToInt32(C_IDTxtBox.Text.ToString()) + "";
                    Update(cmd);

                    cmd = "Update Booking_Table set C_Id=" + Convert.ToInt32(C_IDTxtBox.Text.ToString()) + ",M_Id=" + Convert.ToInt32(MIDTxtBox.Text.ToString()) + ",issued_Date='" + Issue.Text.ToString() + "',Return_Date='" + Return.Text.ToString() + "' where id="+Convert.ToString(R_ID.ToString()) +"";
                    Update(cmd);


                    DateTime Current_date = DateTime.Now;

                    //convert the old date from string to Date fromat
                    DateTime Old_date = Convert.ToDateTime(Issue.Text.ToString());


                    //get the difference in the days fromat
                    String diff = (Current_date - Old_date).TotalDays.ToString();


                    // calculate the round off value 
                    Double Days = Math.Round(Convert.ToDouble(diff));



                    int tot_Charges = Convert.ToInt32(Days) * M_Cost;


                    MessageBox.Show("Rental  movie is Returned to the Portal by the Customer "+ tot_Charges);

                }


                //this method id used to clear all the text boxes and datagridview

                clearAll();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void Video_Year_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void Video_Copies_TextChanged(object sender, EventArgs e)
        {
            try
            {



                //dislay the cost of the price of the video after adding the year of the video
                DateTime dateNow = DateTime.Now;

                int Currentyear = dateNow.Year;

                int diffYear = Currentyear - Convert.ToInt32(Video_Year.Text.ToString());
                // MessageBox.Show(diff.ToString());
                if (diffYear >= 5)
                {
                    Video_Cost.Text = "2";
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    Video_Cost.Text = "5";
                }

            }
            catch (Exception ex) {
                    
            }


        }

        private void Button_Booking_Click(object sender, EventArgs e)
        {
            //pass the name of the table and fetch the whole record form the database anddisplay in the database table
             Table = "Booking_Table";
            //pass the record to the database table
            Database_Table.DataSource = Srch(Table);

        }

        private void buton_Movie_Click(object sender, EventArgs e)
        {
            //pass the name of the table and fetch the whole record form the database and display in the database table
            Table = "Movie_Table";
            //pass the record to the database table
            Database_Table.DataSource = Srch(Table);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //this method id used to print the id of that customer who has most movie on rent 
           String query = "";
            int countVideo = 0, countID = 0;
            DataTable tbl = new DataTable();
            DataTable tbl1 = new DataTable();

            query = "select * from Customer_Table";
            tbl = SelectData(query);
            for (int y = 0; y < tbl.Rows.Count; y++)
            {
                String query1 = "select * from Booking_Table where C_Id='" + tbl.Rows[y]["id"].ToString() + "'";
                tbl1 = SelectData(query1);
                if (tbl1.Rows.Count > 0)
                {
                    if (tbl1.Rows.Count > countVideo)
                    {
                        countVideo = tbl1.Rows.Count;
                        countID = Convert.ToInt32(tbl.Rows[y]["id"].ToString());
                    }
                }


            }
            MessageBox.Show("Top Rated customer ID who get most Video on Rent ID is==" + countID);

            //calling the reset method to reset all the text box
            

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //this method is used to print  the id of the movie which is send most on rent 
           String query = "";
            int countVideo = 0, countID = 0;
            DataTable tbl = new DataTable();
            DataTable tbl1 = new DataTable();

            query = "select * from Movie_Table";
            tbl = SelectData(query);
            for (int y = 0; y < tbl.Rows.Count; y++)
            {
                String query1 = "select * from Booking_Table where M_Id='" + tbl.Rows[y]["id"].ToString() + "'";
                tbl1 = SelectData(query1);
                if (tbl1.Rows.Count > 0)
                {
                    if (tbl1.Rows.Count > countVideo)
                    {
                        countVideo = tbl1.Rows.Count;
                        countID = Convert.ToInt32(tbl.Rows[y]["id"].ToString());
                    }
                }


            }
            MessageBox.Show("Top Rated  Video which is on Rent Most the id  is==" + countID);

        }

        private void Button_Customer_Click(object sender, EventArgs e)
        {
            //pass the name of the table and fetch the whole record form the database anddisplay in the database table
            Table = "Customer_Table";
            //pass the record to the database table
            Database_Table.DataSource = Srch(Table);

        }

        private void Database_Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Table.Equals("Booking_Table")) {

                R_ID = Convert.ToInt32(Database_Table.CurrentRow.Cells[0].Value.ToString());

                C_IDTxtBox.Text = Database_Table.CurrentRow.Cells[1].Value.ToString();
                MIDTxtBox.Text = Database_Table.CurrentRow.Cells[2].Value.ToString();
                Issue.Text = Database_Table.CurrentRow.Cells[3].Value.ToString();
                
            }

            if (Table.Equals("Customer_Table")) {
                C_IDTxtBox.Text= Database_Table.CurrentRow.Cells[0].Value.ToString();
                Customer_Name.Text = Database_Table.CurrentRow.Cells[1].Value.ToString();
                Customer_LName.Text = Database_Table.CurrentRow.Cells[2].Value.ToString();
                Customer_PhNo.Text = Database_Table.CurrentRow.Cells[3].Value.ToString();
                Customer_Address.Text = Database_Table.CurrentRow.Cells[4].Value.ToString();

            }


            if (Table.Equals("Movie_Table")) {

                MIDTxtBox.Text= Database_Table.CurrentRow.Cells[0].Value.ToString();
                Video_title.Text= Database_Table.CurrentRow.Cells[1].Value.ToString();
                Video_Ratting.Text= Database_Table.CurrentRow.Cells[2].Value.ToString();
                Video_Year.Text=Database_Table.CurrentRow.Cells[3].Value.ToString();

                Video_Cost.Text= Database_Table.CurrentRow.Cells[4].Value.ToString();
                M_Cost = Convert.ToInt32(Video_Cost.Text);

                Video_Copies.Text= Database_Table.CurrentRow.Cells[5].Value.ToString();
                M_Copies = Convert.ToInt32(Video_Copies.Text.ToString());

                Video_Plot.Text= Database_Table.CurrentRow.Cells[6].Value.ToString();
                Video_Genre.Text= Database_Table.CurrentRow.Cells[7].Value.ToString();

            }


            Table = "";

        }
    }
}
