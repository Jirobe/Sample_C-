using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Syokuhi.Models;
using System;
using System.IO;

namespace Syokuhi
{
    [Activity(Label = "Syokuhi", MainLauncher = true)]
    public class Main : Activity
    {
        int defMokuhyo;
        DateTime? start;
        DataFiltableCollection items;
        int mokuhyo = 0;
        int total = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            items = new DataFiltableCollection();
            this.Load();

            FindViewById<Button>(Resource.Id.btnPrev).Click += btnPrev_Click;
            FindViewById<Button>(Resource.Id.btnNext).Click += btnNext_Click;
            FindViewById<Button>(Resource.Id.btnCurrent).Click += btnCurrent_Click;
            FindViewById<Button>(Resource.Id.btnSetting).Click += btnSetting_Click;
            FindViewById<EditText>(Resource.Id.editText1).FocusChange += editText_Change;
            FindViewById<EditText>(Resource.Id.editText2).FocusChange += editText_Change;
            FindViewById<EditText>(Resource.Id.editText3).FocusChange += editText_Change;
            FindViewById<EditText>(Resource.Id.editText4).FocusChange += editText_Change;
            FindViewById<EditText>(Resource.Id.editText5).FocusChange += editText_Change;
            FindViewById<EditText>(Resource.Id.editText6).FocusChange += editText_Change;
            FindViewById<EditText>(Resource.Id.editText7).FocusChange += editText_Change;

            display();
        }

        void display()
        {
            defMokuhyo = (int)items.GetDefMokuhyo();

            if (start == null)
            {
                DateTime dtToday = DateTime.Today;
                start = dtToday.AddDays(dtToday.DayOfWeek == DayOfWeek.Sunday ? 6 : 1 - (int)dtToday.DayOfWeek);
            }

            DateTime dtTarget = (DateTime)start;

            for (int i = 0; i <= 6; i++)
            {
                int iDayId;
                int iEditId;
                switch (i)
                {
                    case 0:
                    default:
                        iDayId = Resource.Id.tvDay1;
                        iEditId = Resource.Id.editText1;
                        break;
                    case 1:
                        iDayId = Resource.Id.tvDay2;
                        iEditId = Resource.Id.editText2;
                        break;
                    case 2:
                        iDayId = Resource.Id.tvDay3;
                        iEditId = Resource.Id.editText3;
                        break;
                    case 3:
                        iDayId = Resource.Id.tvDay4;
                        iEditId = Resource.Id.editText4;
                        break;
                    case 4:
                        iDayId = Resource.Id.tvDay5;
                        iEditId = Resource.Id.editText5;
                        break;
                    case 5:
                        iDayId = Resource.Id.tvDay6;
                        iEditId = Resource.Id.editText6;
                        break;
                    case 6:
                        iDayId = Resource.Id.tvDay7;
                        iEditId = Resource.Id.editText7;
                        break;
                }

                FindViewById<TextView>(iDayId).Text = dtTarget.ToShortDateString();

                FindViewById<EditText>(iEditId).Text = items.GetAmount(dtTarget).ToString(); ;

                dtTarget = dtTarget.AddDays(1);
            }

            DateTime dtBefore = ((DateTime)start).AddDays(-7);
            int iBefore = 0;

            for (int i = 0; i <= 6; i++)
            {
                int? iTmp = items.GetAmount(dtBefore.AddDays(i));

                if (iTmp.HasValue)
                {
                    iBefore += (int)iTmp;
                }
            }

            mokuhyo = iBefore > defMokuhyo ? defMokuhyo * 2 - iBefore : defMokuhyo;

            FindViewById<TextView>(Resource.Id.tvMokuhyo).Text = mokuhyo.ToString();

            DispTop();
        }

        void DispTop()
        {
            total = 0;

            for (int i = 0; i <= 6; i++)
            {
                int iEditId;

                switch (i)
                {
                    case 0:
                    default:
                        iEditId = Resource.Id.editText1;
                        break;
                    case 1:
                        iEditId = Resource.Id.editText2;
                        break;
                    case 2:
                        iEditId = Resource.Id.editText3;
                        break;
                    case 3:
                        iEditId = Resource.Id.editText4;
                        break;
                    case 4:
                        iEditId = Resource.Id.editText5;
                        break;
                    case 5:
                        iEditId = Resource.Id.editText6;
                        break;
                    case 6:
                        iEditId = Resource.Id.editText7;
                        break;
                }

                string sTmp = FindViewById<EditText>(iEditId).Text;

                if (!sTmp.Equals(string.Empty))
                {
                    total += int.Parse(sTmp);
                }
            }

            FindViewById<TextView>(Resource.Id.tvWeekTotal).Text = total.ToString();

            FindViewById<TextView>(Resource.Id.tvDiff).Text = (mokuhyo - total).ToString();

        }

        void Save()
        {
            string docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string file = Path.Combine(docs, "save.xml");
            using (FileStream st = File.OpenWrite(file))
            {
                items.Save(st);
            }
        }

        void Load()
        {
            var docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var file = System.IO.Path.Combine(docs, "save.xml");
            if (File.Exists(file))
            {
                using (var st = System.IO.File.OpenRead(file))
                {
                    if (items == null)
                    {
                        items = new DataFiltableCollection();
                    }

                    if (items.Load(st) == false)
                    {
                        File.Delete(file);
                        items = DataFiltableCollection.MakeInitDate();
                    }
                }
            }
            else
            {
                items = DataFiltableCollection.MakeInitDate();
            }
        }

        void btnPrev_Click(object sender, System.EventArgs e)
        {
            start = ((DateTime)start).AddDays(-7);
            display();
        }

        void btnNext_Click(object sender, System.EventArgs e)
        {
            start = ((DateTime)start).AddDays(7);
            display();
        }

        void btnCurrent_Click(object sender, System.EventArgs e)
        {
            start = null;
            display();
        }

        void btnSetting_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(Setting));
            intent.PutExtra("mokuhyo", mokuhyo);
            StartActivityForResult(intent, 1);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            switch (requestCode)
            {
                case 1:
                    if (resultCode == Result.Ok)
                    {
                        defMokuhyo = data.GetIntExtra("mokuhyo", 0);
                        Data dt = new Data();
                        dt.Category = Data.enumCategory.setting;
                        dt.Date = new DateTime();
                        dt.Amount = defMokuhyo;
                        items.Update(dt);
                        this.Save();
                        display();
                    }
                    break;
                default:
                    break;
            }
        }

        void editText_Change(object sender, System.EventArgs e)
        {
            int iDayId;
            Data dt = new Data();
            if (sender.Equals(FindViewById<EditText>(Resource.Id.editText1)))
            {
                iDayId = Resource.Id.tvDay1;
            }
            else if (sender.Equals(FindViewById<EditText>(Resource.Id.editText2)))
            {
                iDayId = Resource.Id.tvDay2;
            }
            else if (sender.Equals(FindViewById<EditText>(Resource.Id.editText3)))
            {
                iDayId = Resource.Id.tvDay3;
            }
            else if (sender.Equals(FindViewById<EditText>(Resource.Id.editText4)))
            {
                iDayId = Resource.Id.tvDay4;
            }
            else if (sender.Equals(FindViewById<EditText>(Resource.Id.editText5)))
            {
                iDayId = Resource.Id.tvDay5;
            }
            else if (sender.Equals(FindViewById<EditText>(Resource.Id.editText6)))
            {
                iDayId = Resource.Id.tvDay6;
            }
            else if (sender.Equals(FindViewById<EditText>(Resource.Id.editText7)))
            {
                iDayId = Resource.Id.tvDay7;
            }
            else
            {
                iDayId = Resource.Id.tvDay1;
            }

            dt.Category = Data.enumCategory.data;

            dt.Date = DateTime.Parse(FindViewById<TextView>(iDayId).Text);

            if (((EditText)sender).Text != string.Empty)
            {
                dt.Amount = int.Parse(((EditText)sender).Text);
            }

            items.Update(dt);
            this.Save();

            DispTop();

        }
    }
}