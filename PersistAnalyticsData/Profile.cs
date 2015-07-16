using Sitecore.Analytics.Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistAnalyticsData
{
    [Serializable]
    public class Profile : Element, PersistAnalyticsData.IProfile
    {
        const string DATA = "data";

        public Profile()
        {
            base.EnsureDictionary<IProfileKey>(DATA);
        }
      

        public IElementDictionary<IProfileKey> ProfileKeys
        {
            get
            {
               return  base.GetDictionary<IProfileKey>(DATA);
            }
        }

        public IEnumerable<KeyValuePair<string, float>> Values
        {
            get
            {
                foreach (var key in ProfileKeys.Keys)
                {
                    yield return  new KeyValuePair<string,float>(key,ProfileKeys[key].Value);
                }
            }
           
        }
    }
}
