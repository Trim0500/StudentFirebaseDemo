using StudentFirebaseDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentFirebaseDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentEntry : ContentPage
    {
        StudentRepo repo = new StudentRepo();

        public StudentEntry()
        {
            InitializeComponent();
        }

        public StudentEntry(Student student)
        {
            InitializeComponent();
            txtId.Text = student.id;
            txtFName.Text = student.firstName;
            txtLName.Text = student.lastName;
            txtEmail.Text = student.email;
            txtPhone.Text = student.phoneNum;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string lName = txtLName.Text;
            string fName = txtFName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            if (String.IsNullOrEmpty(id))
            {
                await DisplayAlert("Required", "Enter last name", "Cancel");
            }
            if (String.IsNullOrEmpty(lName))
            {
                await DisplayAlert("Required", "Enter last name", "Cancel");
            }
            if (String.IsNullOrEmpty(fName))
            {
                await DisplayAlert("Required", "Enter first name", "Cancel");
            }
            if (String.IsNullOrEmpty(email))
            {
                await DisplayAlert("Required", "Enter email", "Cancel");
            }
            if (String.IsNullOrEmpty(phone))
            {
                await DisplayAlert("Required", "Enter email", "Cancel");
            }

            Student newStudent = new Student();

            newStudent.id = id;
            newStudent.lastName = lName;
            newStudent.firstName = fName;
            newStudent.email = email;
            newStudent.phoneNum = phone;

            var isSaved = await repo.Save(newStudent);

            if (isSaved)
            {
                await DisplayAlert("Success", "Saved", "Cancel");
            }
            else
            {
                await DisplayAlert("Failed", "Did not save", "Cancel");
            }

            ClearFields();
        }

        private void ClearFields()
        {
            txtId.Text = String.Empty;
            txtLName.Text = String.Empty;
            txtFName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtPhone.Text = String.Empty;
        }
    }
}