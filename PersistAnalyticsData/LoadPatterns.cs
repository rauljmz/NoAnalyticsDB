using Sitecore;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.Data.Items;
using Sitecore.Analytics.Pipelines.CreateVisits;
using Sitecore.Data;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistAnalyticsData
{
    public class LoadPatterns : CreateVisitProcessor
    {
        public override void Process(CreateVisitArgs args)
        {
            var stProfilePatterns = WebUtil.GetCookieValue("SC.AnalyticsProfiles");
            if (string.IsNullOrEmpty(stProfilePatterns)) return;
            var profilePatterns = StringUtil.ParseNameValueCollection(stProfilePatterns,',','=');
            foreach (var profileName in profilePatterns.AllKeys)
            {
                var profile = args.Visit.GetOrCreateProfile(profileName);
                profile.BeginEdit();
                profile.PatternId = Guid.Parse(profilePatterns[profileName]);
                var patternCardItem = Tracker.DefinitionDatabase.GetItem(new ID(profile.PatternId));
                if (patternCardItem != null)
                {
                    var ptci = new PatternCardItem(patternCardItem);

                    profile.PatternLabel = ptci.NameField;
                }
                profile.EndEdit();
            }
        }
    }
}
