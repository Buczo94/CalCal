using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;

namespace CalCal
{
    [Activity(Label = "", MainLauncher = true, Icon = "@drawable/ccicon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.mainMenuLayout);
            Button goToCalculatorButton = FindViewById<Button>(Resource.Id.calcButton);
            Button goToProductsButton = FindViewById<Button>(Resource.Id.productsButton);
            goToCalculatorButton.Click += delegate
            {
                StartActivity(typeof(CalcCalories));
            };
            goToProductsButton.Click += delegate
            {
                StartActivity(typeof(ProductSearch));
            };

        }
    }
}

