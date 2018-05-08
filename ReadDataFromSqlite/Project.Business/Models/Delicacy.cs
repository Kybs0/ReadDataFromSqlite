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
    [Table("Delicacy")]
    public class Delicacy
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

    public partial class DelicacyDb : DataConnection
    {
        public ITable<Delicacy> ClassicalWorks => GetTable<Delicacy>();

        public DelicacyDb()
        {
            InitDataContext();
        }

        public DelicacyDb(string configuration)
            : base(configuration)
        {
            InitDataContext();
        }

        public DelicacyDb(IDataProvider dataProvider, string connectionString)
            : base(dataProvider, connectionString)
        {
            InitDataContext();
        }

        partial void InitDataContext();
    }
}
