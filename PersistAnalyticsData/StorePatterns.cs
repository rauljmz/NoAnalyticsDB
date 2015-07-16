using Sitecore;
using Sitecore.Analytics;
using Sitecore.Analytics.Pipelines.StartTracking;
using Sitecore.Pipelines.SessionEnd;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistAnalyticsData
{
    public class StoreProfiles 
    {
        public virtual void Process(SessionEndArgs args)
        {
            var tracker = Tracker.Current;
            if (tracker == null || tracker.Contact == null || tracker.Interaction == null) return;
            var profilestorage = tracker.Contact.GetFacet<IProfilingStorage>(ProfilingStorage.FACETNAME);

            foreach (var profilename in tracker.Interaction.Profiles.GetProfileNames())
            {
                var profile = tracker.Interaction.Profiles[profilename];

                var profileDefItem = Tracker.DefinitionItems.Profiles.FirstOrDefault(i => i.ProfileName.Equals(profilename, StringComparison.InvariantCultureIgnoreCase));

                if (profileDefItem == null || profileDefItem["do not persist"] == "1") continue;

                var storedProfile = profilestorage.Profiles.Contains(profilename) ? profilestorage.Profiles[profilename] : profilestorage.Profiles.Create(profilename);

                foreach (var profilekey in profile)
                {
                    var keystorage = storedProfile.ProfileKeys.Contains(profilekey.Key) ? storedProfile.ProfileKeys[profilekey.Key] : storedProfile.ProfileKeys.Create(profilekey.Key);
                    keystorage.Name = profilekey.Key;
                    keystorage.Value = profilekey.Value ;
                }

            }

            //var profilePatterns = new NameValueCollection();

            //foreach (var profile in Tracker.CurrentVisit.Profiles)
            //{
            //    if (profile.PatternId != Guid.Empty)
            //    {
            //        profilePatterns.Add(profile.ProfileName, profile.PatternId.ToString());
            //    }
            //}
            //if (profilePatterns.Count > 0)
            //{
            //    var oldCookieValue = WebUtil.GetCookieValue("SC.AnalyticsProfiles");
            //    var newCookieValue = StringUtil.NameValuesToString(profilePatterns);
            //    if (oldCookieValue != newCookieValue)
            //    {
            //        WebUtil.SetCookieValue("SC.AnalyticsProfiles", newCookieValue, DateTime.MaxValue);
            //    }
            //}
        }
    }
}
