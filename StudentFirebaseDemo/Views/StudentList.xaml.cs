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
    public partial class StudentList : ContentPage
    {
        StudentRepo studentRepo = new StudentRepo();

        public StudentList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var students = await studentRepo.GetAll();

            collectionView.ItemsSource = students;
        }

        private void AddToolBarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new StudentEntry());
        }

        private void EditToolBarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void DeleteToolBarItem_Clicked(object sender, EventArgs e)
        {

        }

        private async void EditTap_Tapped(object sender, EventArgs e)
        {
            string key = ((TappedEventArgs)e).Parameter.ToString();

            await DisplayAlert("Show ID", key, "OK");

            var student = await studentRepo.GetById(key);

            if(student == null)
            {
                await DisplayAlert("Warning", "Student was not found", "OK");
            }
            else
            {
                student.Key = key;

                await Navigation.PushModalAsync(new StudentEntry(student));
                OnAppearing();
            }
        }
    }
}