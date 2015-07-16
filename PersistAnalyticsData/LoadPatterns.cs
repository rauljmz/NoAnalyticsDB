using Sitecore;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.Data.Items;
using Sitecore.Analytics.Pipelines.CreateVisits;
using Sitecore.Analytics.Tracking;
using Sitecore.Data;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistAnalyticsData
{
    public class LoadProfiles : CreateVisitProcessor
    {
        public override void Process(CreateVisitArgs args)
        {
            var storedProfiles = Tracker.Current.Contact.GetFacet<IProfilingStorage>(ProfilingStorage.FACETNAME);
            

            foreach (var storedProfileKey in storedProfiles.Profiles.Keys)
            {
                var storedProfile = storedProfiles.Profiles[storedProfileKey];
                var profile = args.Interaction.Profiles[storedProfileKey];
                
                profile.Score(storedProfile.Values);
                profile.UpdatePattern();
               
            }
        }
    }
}
