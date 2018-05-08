using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider;
using LinqToDB.Mapping;

namespace Project.Business.Models
{
    /// <summary>
    /// 酒店
    /// </summary>
    [Table("Hotel")]
    public class Hotel
    {
        [Column, NotNull]
        public string Guid { get; set; }

        [Column, Nullable]
        public string Name { get; set; }

        [Column, Nullable]
        public string Addresss { get; set; }

        [Column, Nullable]
        public string Price { get; set; }

        [Column, Nullable]
        public string Introduction { get; set; }
    }

    public partial class HotelDb : DataConnection
    {
        public ITable<Hotel> Hotels => GetTable<Hotel>();

        public HotelDb()
        {
            InitDataContext();
        }

        public HotelDb(string configuration)
            : base(configuration)
        {
            InitDataContext();
        }

        public HotelDb(IDataProvider dataProvider, string connectionString)
            : base(dataProvider, connectionString)
        {
            InitDataContext();
        }

        partial void InitDataContext();
    }
}
