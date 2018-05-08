using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Business.Models;

namespace Project.Business
{
    public class SqliteDataReader
    {
        private static readonly string DbName = "project.db3";
        private readonly DbCache<HotelDb> _hotelDbCache;
        private readonly DbCache<DelicacyDb> _delicacyDbCache;
        private readonly DbCache<SceneryDb> _sceneryDbCache;
        private readonly DbCache<SubwayDb> _subwayDbCache;
        private List<Hotel> _hotels = new List<Hotel>();
        private List<Delicacy> _delicacies = new List<Delicacy>();
        private List<Scenery> _scenerys = new List<Scenery>();
        private List<Subway> _subways = new List<Subway>();

        public SqliteDataReader()
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbName);

            if (!File.Exists(dbPath))
            {
                throw new InvalidOperationException("路径下不存在数据库文件");
            }
            _hotelDbCache = new DbCache<HotelDb>(() => $"Data Source={dbPath}");
            _delicacyDbCache = new DbCache<DelicacyDb>(() => $"Data Source={dbPath}");
            _sceneryDbCache = new DbCache<SceneryDb>(() => $"Data Source={dbPath}");
            _subwayDbCache = new DbCache<SubwayDb>(() => $"Data Source={dbPath}");
        }

        public List<Hotel> GetHotels()
        {
            if (_hotels == null || _hotels.Count == 0)
            {
                _hotels = _hotelDbCache.Execute(db => db.Hotels.OrderBy(i => i.Guid).ToList());
            }
            return _hotels;
        }

        public List<Hotel> GetHotelsByAddress(string addressName)
        {
            var works = GetHotels().Where(x => x.Addresss.Contains(addressName)).ToList();
            return works;
        }

        /// <summary>
        /// 搜索，返回作品和作者，用法参考：var (works,writers) = reader.Search("李");
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Tuple<List<Hotel>, List<Delicacy>, List<Subway>, List<Scenery>> Search(string key)
        {
            var hotels = GetHotelsByAddress(key);
            var result = new Tuple<List<Hotel>, List<Delicacy>, List<Subway>, List<Scenery>>(hotels, null, null, null);
            return result;
        }
    }
}
