using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;
using Newtonsoft.Json;
using Org.Json;

namespace HuffmanHenryAssn4
{
    [Activity(Label = "HuffmanHenryAssn4", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private static SortedList<int, Employee> workers = new SortedList<int, Employee>();
        protected override void OnCreate(Bundle bundle)
        {
            this.Title = "Employee List";
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            //SetContentView (Resource.Layout.Main);

            ListView.ChoiceMode = ChoiceMode.Single;

            //make a list of employees

            for (int i = 0; i < 100; i++)
            {
                Employee person = Employee.makeEmployee();
                workers.Add(person.employeeId, person);
            }

            ListAdapter = new HomeScreenAdapterComplex(this, workers);

        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = workers[workers.Keys[position]];
            Intent toProfile = new Intent(this, typeof(Profile));
            string person = JsonConvert.SerializeObject(t);
            toProfile.PutExtra("person", person);
            StartActivity(toProfile);
            //Android.Widget.Toast.MakeText(this, t.lastName,
            //    Android.Widget.ToastLength.Short).Show();
            //Console.WriteLine("Clicked on " + t.lastName);
        }

        public class HomeScreenAdapterComplex : BaseAdapter<Employee>
        {
            // Again, instead of binding a simple <string>, we bind a list of objects of 
            // type Employee.
            private SortedList<int ,Employee> items;
            private Activity context;

            ////// And so the constructor items are of type Employee instead of string.
            public HomeScreenAdapterComplex(Activity context, SortedList<int, Employee> items)
               : base()
            {
                this.context = context;
                this.items = items;
            }

            // The GetItemId method does not change.
            public override long GetItemId(int position)
            {
                return position;
            }

            // The indexer is of type Employee instead of type String, because 
            // we are working with an instance of the Employee class. So we are returning
            // and Employee from the list.
            public override Employee this[int position]
            {
                get
                {
                    return items[position];
                }
            }

            // The Count method does not change.
            public override int Count
            {
                get
                {
                    return items.Count;
                }
            }

            //
            // The GetView() method is changed considerably. In this example, we bind the row
            // to the predefined layout named Android.Resource.Layout.SimpleListItem2
            // instead of Android.Resource.Layout.SimpleListItem1. This layout has two
            // TextView widgets named Text1 and Text2.
            //
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                // Items is of type Employeee
                Employee item = items[items.Keys[position]];

                View view = convertView;
                if (view == null)
                {
                    // We are still using one of the Android layout's here. This layout
                    // has two TextView widgets instead of one.
                    view = context.LayoutInflater.Inflate(
                        Android.Resource.Layout.SimpleListItem2, null);
                }

                // Because item is of type Employee, we reference the Employee properties
                // instead of the default string properties.
                view.FindViewById<TextView>(Android.Resource.Id.Text1).Text =
                    item.lastName + ' ' + item.firstName;
                view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = "Id#: " +
                    item.employeeId.ToString();

                return view;
            }
        }
    }
}

