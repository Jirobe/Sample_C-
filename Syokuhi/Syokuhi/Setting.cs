﻿
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Syokuhi
{
    [Activity(Label = "Setting")]
    class Setting : Activity
    {
        EditText etMokuhyo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Setting);

            etMokuhyo = FindViewById<EditText>(Resource.Id.etMokuhyo);
            etMokuhyo.Text = Intent.GetDoubleExtra("mokuhyo", 0).ToString();
        }

        public override void OnBackPressed()
        {
            var intent = new Intent();

            double iMokuhyo = 0;
            if (!etMokuhyo.Text.Equals(string.Empty))
            {
                iMokuhyo = double.Parse(etMokuhyo.Text);
            }

            intent.PutExtra("mokuhyo", iMokuhyo);
            SetResult(Result.Ok, intent);
            Finish();
        }
    }
}