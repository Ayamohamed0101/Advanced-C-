using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CountriesBusinessLayer;
namespace ContactsPresentationLayer
{
    public partial class frmAddEditContact : Form
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode;

        int _ContactID;
        clsContact _Contact;// object 

        private void _FillCountriesInComboBox()
        {

            DataTable dt = clsCountry.GetAllCountries();//////

            foreach (DataRow row in dt.Rows) // for each row 
            {

                cbCountry.Items.Add(row["CountryName"]);
            }

        }

        private void _LoadData()
        {

            _FillCountriesInComboBox();
            //cbCountry.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Contact";
                _Contact = new clsContact(); ///
                return;
            }

            _Contact = clsContact.FindContactbyID(_ContactID); // update

            if (_Contact == null)
            {

                MessageBox.Show("This Form will be closed because no contact with ID = " + _ContactID);
                this.Close();
                return;
            }

            lblMode.Text = "Edit Contact ID = " + _ContactID;
            lblContactID.Text = _ContactID.ToString();

            txtFirstName.Text = _Contact.FirstName;
            txtLastName.Text = _Contact.LastName;
            txtEmail.Text = _Contact.Email;
            txtPhone.Text = _Contact.Phone;
            txtAddress.Text = _Contact.Address;
            tpdate.Value = _Contact.DateOfBirth;

            if (_Contact.ImagePath != "")
            {

                guna2PictureBox1.Load(_Contact.ImagePath);
            }

            llremovephote.Visible = (_Contact.ImagePath != "");
           cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Contact.CountryID).CountryName);/////////

        }



        public frmAddEditContact(int ID)
        {
            InitializeComponent();

            this._ContactID = ID;

            if (ID == -1)
            {
                this._Mode = enMode.AddNew;
            }
            else
            {
                this._Mode = enMode.Update;
            }

        }

        private void lblAddNewContact_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
            _LoadData();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close
                ();
        }

        private void lladdphote_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string selectedFilePath = openFileDialog1.FileName;
                guna2PictureBox1.Load(selectedFilePath);
                llremovephote.Visible = true;
            }

        }

        private void llremovephote_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            guna2PictureBox1.ImageLocation = null;
            llremovephote.Visible = false;

        }

        private void guna2Button1_Click(object sender, EventArgs e) // save
        {
          int CountryID = clsCountry.Find(cbCountry.Text).CountryID;/////////////////////////

            _Contact.FirstName = txtFirstName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Email = txtEmail.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtAddress.Text;
            _Contact.DateOfBirth = tpdate.Value;
           _Contact.CountryID = CountryID;

            if (guna2PictureBox1.ImageLocation != null)
            {

                _Contact.ImagePath = guna2PictureBox1.ImageLocation;
            }
            else
            {
                _Contact.ImagePath = "";
            }

            if (_Contact.save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Didn't Save Successfully.");
            }

            _Mode = enMode.Update;

            lblMode.Text = "Edit Contact ID = " + _Contact.ID;
            lblContactID.Text = _Contact.ID.ToString();

        }
    }
}
