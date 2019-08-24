using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Syokuhi.Models
{
    public class DataFiltableCollection : ObservableCollection<Data>
    {
        private List<Data> _items;

        public DataFiltableCollection() : base()
        {
            _items = new List<Data>();
        }

        public DataFiltableCollection(List<Data> items) : base(items)
        {
            _items = items;
        }

        public new void Add(Data item)
        {
            _items.Add(item);
        }

        public void Update(Data item)
        {
            try
            {
                var it = _items.First(x => x.Category == item.Category && x.Date == item.Date);
                if (it != null)
                {
                    item.Copy(it);
                }
                else
                {
                    this.Add(item);
                }
            }
            catch
            {
                this.Add(item);
            }
            UpdateFilter();
        }

        public void UpdateFilter()
        {
            SetFilter();
        }

        public void SetFilter()
        {
            List<Data> lst = _items;
            lst = _items.OrderBy(x => x.Date).ToList();
            this.Clear();
            lst.All(x => { base.Add(x); return true; });
        }

        public bool Save(System.IO.Stream st)
        {
            try
            {
                st.SetLength(0);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(DataFiltableCollection));
                xs.Serialize(st, this);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Load(System.IO.Stream st)
        {
            try
            {
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(DataFiltableCollection));
                var newItems = xs.Deserialize(st) as DataFiltableCollection;
                this._items = newItems._items;
                this.UpdateFilter();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static DataFiltableCollection MakeInitDate()
        {
            var lst = new List<Data>();
            lst.Add(new Data() { Category = Data.enumCategory.setting, Date = new DateTime(), Amount = 10000 });
            return new DataFiltableCollection(lst);
        }

        public double? GetAmount(DateTime date)
        {
            try
            {
                var it = _items.First(x => x.Category == Data.enumCategory.data && x.Date == date);
                return it.Amount;
            }
            catch
            {
                return null;
            }
        }

        public double? GetDefMokuhyo()
        {
            try
            {
                var it = _items.First(x => x.Category == Data.enumCategory.setting);
                return it.Amount;
            }
            catch
            {
                return 0;
            }
        }
    }
}