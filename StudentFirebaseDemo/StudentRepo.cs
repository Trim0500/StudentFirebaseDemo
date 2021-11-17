using Firebase.Database;
using Newtonsoft.Json;
using StudentFirebaseDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFirebaseDemo
{
    public class StudentRepo
    {
        FirebaseClient firebaseClient = new FirebaseClient(
                "https://xamarin-firebase-demo-705c3-default-rtdb.firebaseio.com/"
            );

        public async Task<bool> Save(Student student)
        {
            var data = await firebaseClient.Child(nameof(Student)).PostAsync(JsonConvert.SerializeObject(student));

            if(!String.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Student>> GetAll()
        {
            return (await firebaseClient.Child(nameof(Student)).OnceAsync<Student>()).Select(item => new Student
            {
                Key = item.Key,
                id = item.Object.id,
                lastName = item.Object.lastName,
                firstName = item.Object.firstName,
                email = item.Object.email,
                phoneNum = item.Object.phoneNum
            }).ToList();
        }

        public async Task<Student> GetById(string key)
        {
            return (await firebaseClient.Child(nameof(Student) + "/" + key).OnceSingleAsync<Student>());
        }
    }
}
