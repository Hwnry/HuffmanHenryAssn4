using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace HuffmanHenryAssn4
{
    [Activity(Label = "Profile")]
    public class Profile : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Person);
            TextView tvId = (TextView) FindViewById(Resource.Id.tvId);
            TextView tvLast = (TextView) FindViewById(Resource.Id.tvLast);
            TextView tvFirst = (TextView) FindViewById(Resource.Id.tvFirst);
            TextView tvWage = (TextView) FindViewById(Resource.Id.tvWage);
            TextView tvHours = (TextView) FindViewById(Resource.Id.tvHours);
            TextView tvTotal = (TextView) FindViewById(Resource.Id.tvTotal);

            string serializedPerson = Intent.GetStringExtra("person");
            Employee selectedPerson = JsonConvert.DeserializeObject<Employee>(serializedPerson);

            this.Title = selectedPerson.lastName + "'s Profile";

            tvId.Text = selectedPerson.employeeId.ToString();
            tvLast.Text = selectedPerson.lastName;
            tvFirst.Text = selectedPerson.firstName;
            tvWage.Text = selectedPerson.hourlyWage.ToString();
            tvHours.Text = selectedPerson.hoursWorked.ToString();
            tvTotal.Text = selectedPerson.totalPayRoll.ToString();
        }
    }
}