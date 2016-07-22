using System.Collections.Generic;

namespace SpaceVulture.Core.MarketFeed.Json
{

        public class UploadKey
        {
            public string name { get; set; }
            public string key { get; set; }
        }

        public class Generator
        {
            public string name { get; set; }
            public string version { get; set; }
        }

        public class Rowset
        {
            public string generatedAt { get; set; }
            public int regionID { get; set; }
            public int typeID { get; set; }
            public List<List<object>> rows { get; set; }
        }

        public class MarketHistoryRoot
        {
            public string OriginalJson { get; set; }
            public string resultType { get; set; }
            public string version { get; set; }
            public List<UploadKey> uploadKeys { get; set; }
            public Generator generator { get; set; }
            public string currentTime { get; set; }
            public List<string> columns { get; set; }
            public List<Rowset> rowsets { get; set; }
        }
}
