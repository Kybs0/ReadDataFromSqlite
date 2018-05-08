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
    /// 风景
    /// </summary>
    [Table("Scenery")]
    public class Scenery
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

    public partial class SceneryDb : DataConnection
    {
        public ITable<Scenery> ClassicalWorks => GetTable<Scenery>();

        public SceneryDb()
        {
            InitDataContext();
        }

        public SceneryDb(string configuration)
            : base(configuration)
        {
            InitDataContext();
        }

        public SceneryDb(IDataProvider dataProvider, string connectionString)
            : base(dataProvider, connectionString)
        {
            InitDataContext();
        }

        partial void InitDataContext();
    }
}
