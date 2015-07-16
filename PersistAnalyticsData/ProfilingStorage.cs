using Sitecore.Analytics.Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistAnalyticsData
{
    public class ProfilingStorage : Facet, PersistAnalyticsData.IProfilingStorage
    {
        public const string FACETNAME = "profiling";
        const string PROFILES = "profiles";
        public ProfilingStorage()
        {
            base.EnsureDictionary<IProfile>(PROFILES);
        }


        public IElementDictionary<IProfile> Profiles
        {
            get { return base.GetDictionary<IProfile>(PROFILES); }
        
        }

    }
}
