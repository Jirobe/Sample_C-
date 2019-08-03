using Syokuhi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syokuhi.Models
{
    // アイテムクラス
    public class Data : ObservableObject
    {
        public enum enumCategory
        {
            data,
            setting
        }

        enumCategory category;
        public enumCategory Category
        {
            get { return category; }
            set { SetProperty(ref category, value); }
        }

        DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                SetProperty(ref date, value);
                this.OnPropertyChanged(nameof(StrDate));
            }
        }

        int? amount;
        public int? Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        public string StrDate
        {
            get
            {
                return Date.ToString("yyyy/MM/dd");
            }
        }

        public Data Copy(Data target = null)
        {
            if (target == null)
            {
                target = new Data();
            }
            target.Date = this.Date;
            target.Amount = this.Amount;
            return target;
        }
    }
}