using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Data.SqlClient;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Markup;
using System.Text.RegularExpressions;

namespace ERP.Views
{
    public sealed partial class DummyDBForm : Page
    {
        public ObservableCollection<Supplier> Suppliers { get; set; } = new ObservableCollection<Supplier>();

        public DummyDBForm()
        {
            this.InitializeComponent();
            FetchSuppliersData();
        }

        // Function to fetch suppliers data from the database
        private void FetchSuppliersData()
        {
            // Create a connection string
            string connectionString = "Data Source=DESKTOP-CBITDTR;Initial Catalog=ERP;User ID=appConn;Password=appConn;TrustServerCertificate=true;";

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SQL command to fetch the data
                string selectQuery = "SELECT * FROM Suppliers";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    // Execute the command and fetch the data
                    SqlDataReader reader = command.ExecuteReader();
                    List<Supplier> suppliers = new List<Supplier>();

                    while (reader.Read())
                    {
                        // Create a new Supplier object and populate its properties from the data reader
                        Supplier supplier = new Supplier
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                            ContactName = reader.GetString(reader.GetOrdinal("ContactName")),
                            Location = reader.GetString(reader.GetOrdinal("Location")),
                            LandCode = reader.GetString(reader.GetOrdinal("LandCode")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"))
                        };

                        // Add the Supplier object to the list
                        suppliers.Add(supplier);
                    }

                    // Assign the list of suppliers to the property
                    Suppliers = new ObservableCollection<Supplier>(suppliers);
                }

                // Close the connection
                connection.Close();
            }

            // Update the ListView's item source with the new data
            SupplierListView.ItemsSource = Suppliers;
        }

        // When Add to Database button is clicked
        private void addToDB_Click(object sender, RoutedEventArgs e)
        {
            bool formError = false;
            string formErrorText = "An ERROR occured";

            // Retrieve the information from the TextBoxes
            string id = ID.Text;
            string companyName = CompanyName.Text;
            string contactName = ContactName.Text;
            string location = Location.Text;
            string landCode = LandCode.Text;
            string phoneNumber = PhoneNumber.Text;

            // FORM VALIDATION
            // ID should be a integer field
            if (!Regex.IsMatch(id, @"^[0-9]+$"))
            {
                formErrorText = "ID must be an integer";
                formError = true;
            }

            if (string.IsNullOrWhiteSpace(companyName))
            {
                formErrorText = "Company Name cannot be empty";
                formError = true;
            }

            // Phone Number should be a integer field
            if (!Regex.IsMatch(phoneNumber, @"^[0-9]+$"))
            {
                formErrorText = "Phone Number must be an integer";
                formError = true;
            }

            // Land Code length should be of 2 characters
            if (!(landCode.Length == 2))
            {
                formErrorText = "Land Code must be of 2 characters";
                formError = true;
            }

            // Form is valid -> add data to database
            if (formError ==  false)
            {
                // Create a connection string
                string connectionString = "Data Source=DESKTOP-CBITDTR;Initial Catalog=ERP;User ID=appConn;Password=appConn;TrustServerCertificate=true;";

                // Create a SQL connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SQL command
                    string insertQuery = "INSERT INTO Suppliers (ID, CompanyName, ContactName, Location, LandCode, PhoneNumber) VALUES (@ID, @CompanyName, @ContactName, @Location, @LandCode, @PhoneNumber)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@CompanyName", companyName);
                        command.Parameters.AddWithValue("@ContactName", contactName);
                        command.Parameters.AddWithValue("@Location", location);
                        command.Parameters.AddWithValue("@LandCode", landCode);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        // Execute the command
                        command.ExecuteNonQuery();
                    }

                    // Close the connection
                    connection.Close();
                }

                // Fetch the updated data from the database
                FetchSuppliersData();

                // Update the result text
                processResult.Text = "Item added successfully";
                processResult.Foreground = new SolidColorBrush((Windows.UI.Color)XamlBindingHelper.ConvertValue(typeof(Windows.UI.Color), "#66B032"));

                // Reset the TextBoxes
                ID.Text = string.Empty;
                CompanyName.Text = string.Empty;
                ContactName.Text = string.Empty;
                Location.Text = string.Empty;
                LandCode.Text = string.Empty;
                PhoneNumber.Text = string.Empty;
            }
            else
            {
                processResult.Text = formErrorText;
                processResult.Foreground = new SolidColorBrush((Windows.UI.Color)XamlBindingHelper.ConvertValue(typeof(Windows.UI.Color), "#B90E0A"));
            }
        }

        // When Delete from Database button is clicked
        private void deleteFromDB_Click(object sender, RoutedEventArgs e)
        {
            // Check if a list item is selected
            if (SupplierListView.SelectedItem != null)
            {
                // Retrieve the selected Supplier object
                Supplier selectedSupplier = (Supplier)SupplierListView.SelectedItem;

                // Access the properties of the selected Supplier
                int id = selectedSupplier.ID;
                string companyName = selectedSupplier.CompanyName;
                string contactName = selectedSupplier.ContactName;
                string location = selectedSupplier.Location;
                string landCode = selectedSupplier.LandCode;
                string phoneNumber = selectedSupplier.PhoneNumber;

                // Perform the delete operation based on the selected Supplier's information
                // For example, you can execute a SQL delete statement using the Supplier's ID

                // Create a connection string
                string connectionString = "Data Source=DESKTOP-CBITDTR;Initial Catalog=ERP;User ID=appConn;Password=appConn;TrustServerCertificate=true;";

                // Create a SQL connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SQL command to delete the selected Supplier
                    string deleteQuery = "DELETE FROM Suppliers WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Add the Supplier's ID as a parameter to the command
                        command.Parameters.AddWithValue("@ID", id);

                        // Execute the delete command
                        command.ExecuteNonQuery();
                    }

                    // Close the connection
                    connection.Close();
                }

                // Update the result text
                processResult.Text = "Item deleted successfully";
                processResult.Foreground = new SolidColorBrush((Windows.UI.Color)XamlBindingHelper.ConvertValue(typeof(Windows.UI.Color), "#66B032"));

                // Fetch the updated data from the database
                FetchSuppliersData();

                // Reset the TextBoxes
                ID.Text = string.Empty;
                CompanyName.Text = string.Empty;
                ContactName.Text = string.Empty;
                Location.Text = string.Empty;
                LandCode.Text = string.Empty;
                PhoneNumber.Text = string.Empty;
            } 
            // No list item is selected
            else
            {
                processResult.Text = "No item selected";
                processResult.Foreground = new SolidColorBrush((Windows.UI.Color)XamlBindingHelper.ConvertValue(typeof(Windows.UI.Color), "#B90E0A"));
            }
        }
    }

    public class Supplier
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Location { get; set; }
        public string LandCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
