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
using Android.Views.InputMethods;

namespace CalCal
{
    [Activity(Label = "Ile kalori potrzebujesz?")]
    public class CalcCalories : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.calcLayout);
            double activityRatio = 0;
            double sexRatio = 0;
            EditText heightText = FindViewById<EditText>(Resource.Id.heightText);
            EditText weightText = FindViewById<EditText>(Resource.Id.weightText);
            EditText ageText = FindViewById<EditText>(Resource.Id.ageText);
            RadioGroup sexRadioGroup = FindViewById<RadioGroup>(Resource.Id.sexRadioGroup);
            RadioButton womanRadio = FindViewById<RadioButton>(Resource.Id.womanButton);
            RadioButton manRadio = FindViewById<RadioButton>(Resource.Id.manButton);
            RadioGroup activityRadioGroup = FindViewById<RadioGroup>(Resource.Id.activityRadioGroup);
            RadioButton lowActivity = FindViewById<RadioButton>(Resource.Id.lowActivityRadio);
            RadioButton avarageActivity = FindViewById<RadioButton>(Resource.Id.avarageActivityRadio);
            RadioButton highActivity = FindViewById<RadioButton>(Resource.Id.highActivityRadio);
            RadioButton veryHighActivity = FindViewById<RadioButton>(Resource.Id.highestActivityRadio);
            Button countButton = FindViewById<Button>(Resource.Id.countButton);
            TextView ppmLabel = FindViewById<TextView>(Resource.Id.PPMLabel);
            TextView ppmText = FindViewById<TextView>(Resource.Id.PPMText);
            TextView calNeedsLabel = FindViewById<TextView>(Resource.Id.calNeedsLabel);
            TextView calNeedsText = FindViewById<TextView>(Resource.Id.calNeedsText);
            ppmLabel.Visibility = ViewStates.Invisible;
            ppmText.Visibility = ViewStates.Invisible;
            calNeedsLabel.Visibility = ViewStates.Invisible;
            calNeedsText.Visibility = ViewStates.Invisible;

            manRadio.Click += delegate
            {
                var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
                inputManager.HideSoftInputFromWindow(ageText.WindowToken, HideSoftInputFlags.None);
            };

            womanRadio.Click += delegate
            {
                var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
                inputManager.HideSoftInputFromWindow(ageText.WindowToken, HideSoftInputFlags.None);
            };

            lowActivity.Click += delegate
            {
                var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
                inputManager.HideSoftInputFromWindow(ageText.WindowToken, HideSoftInputFlags.None);
            };

            avarageActivity.Click += delegate
            {
                var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
                inputManager.HideSoftInputFromWindow(ageText.WindowToken, HideSoftInputFlags.None);
            };

            highActivity.Click += delegate
            {
                var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
                inputManager.HideSoftInputFromWindow(ageText.WindowToken, HideSoftInputFlags.None);
            };

            veryHighActivity.Click += delegate
            {
                var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
                inputManager.HideSoftInputFromWindow(ageText.WindowToken, HideSoftInputFlags.None);
            };



            sexRadioGroup.Click += delegate
            {
                var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
                inputManager.HideSoftInputFromWindow(ageText.WindowToken, HideSoftInputFlags.None);
            };

            activityRadioGroup.Click += delegate
            {
                var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
                inputManager.HideSoftInputFromWindow(ageText.WindowToken, HideSoftInputFlags.None);
            };

            countButton.Click += delegate
            {
                try
                {
                    if (womanRadio.Checked) sexRatio = -161;
                    if (manRadio.Checked) sexRatio = 5;
                    if (lowActivity.Checked) activityRatio = 1.4;
                    if (avarageActivity.Checked) activityRatio = 1.6;
                    if (highActivity.Checked) activityRatio = 1.75;
                    if (veryHighActivity.Checked) activityRatio = 2.2;

                    double ppm = 10 * double.Parse(weightText.Text) + 6.25 * double.Parse(heightText.Text) - 5 * double.Parse(ageText.Text) + sexRatio;
                    double caloriesNeed = ppm * activityRatio;
                    ppmLabel.Visibility = ViewStates.Visible;
                    ppmText.Visibility = ViewStates.Visible;
                    calNeedsLabel.Visibility = ViewStates.Visible;
                    calNeedsText.Visibility = ViewStates.Visible;
                    ppmText.Text = (ppm.ToString() + " kcal");
                    calNeedsText.Text = (caloriesNeed.ToString() + " kcal");
                }
                catch
                {
                    ppmText.Visibility = ViewStates.Visible;
                    ppmText.Text = "Podaj poprawne wartoœci";

                }
            };
        }
    }
}