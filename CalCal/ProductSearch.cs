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
using System.IO;

namespace CalCal
{
    [Activity(Label = "Znajdü produkt")]
    public class ProductSearch : Activity
    {
        static string[] textLines;
        public static Dictionary<string, string> list = new Dictionary<string, string>();

        public static void Initiate()
        {

            
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            textLines = File.ReadAllLines(@"/storage/sdcard0/drob2.txt");
            //  button.Text = textLines.Length.ToString();
            List<string> items = new List<string>();
            
            int x = 0;
            string[] prod = new string[5000];
            string[] prodczlon = new string[5000];
            foreach (string line in textLines)
            {
                string pLine = line;
                //pLine = pLine.Replace(" ", "");
                string[] parts = pLine.Split(';');
                prodczlon[x] = parts[0];
                items.Add(parts[0] +" "+ parts[1] + " kcal");
                //list.Add(parts[0], parts[1]);
                x++;
            }
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.productsLayout);
            // Create your application here
            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            //edit.LineHeight = 30;
            //ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            EditText searchProduct = FindViewById<EditText>(Resource.Id.productText);
            Button searchButton = FindViewById<Button>(Resource.Id.findButton);
            searchButton.Click += delegate
            {
                List<string> items2 = new List<string>();
                for (int y = 0; y < 120; y++)
                {
                    if (items[y].Contains(searchProduct.Text))
                    {
                        items2.Add(items[y]);
                    }
                }
                ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items2);
                listView.Adapter = adapter;
            };



        }
    }
}