using Sitecore;
using Sitecore.Analytics;
using Sitecore.Analytics.Pipelines.StartTracking;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistAnalyticsData
{
    public class StorePatterns : StartTrackingProcessor
    {
        public override void Process(StartTrackingArgs args)
        {
            var profilePatterns = new NameValueCollection();

            foreach (var profile in Tracker.CurrentVisit.Profiles)
            {
                if (profile.PatternId != Guid.Empty)
                {
                    profilePatterns.Add(profile.ProfileName, profile.PatternId.ToString());
                }
            }
            if (profilePatterns.Count > 0)
            {
                var oldCookieValue = WebUtil.GetCookieValue("SC.AnalyticsProfiles");
                var newCookieValue = StringUtil.NameValuesToString(profilePatterns);
                if (oldCookieValue != newCookieValue)
                {
                    WebUtil.SetCookieValue("SC.AnalyticsProfiles", newCookieValue, DateTime.MaxValue);
                }
            }
        }
    }
}
