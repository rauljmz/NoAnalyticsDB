namespace NoAnalyticsDB.layouts.test
{
    using Sitecore.Analytics;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public partial class AnalyticsInfo : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
           
        }

        public IEnumerable<Sitecore.Analytics.Tracking.Profile> GetData()
        {
            var tracker = Tracker.Current;
            if (tracker == null || tracker.Interaction == null) return null;
            return tracker.Interaction.Profiles.GetProfileNames().Select(name => tracker.Interaction.Profiles[name]);
        }
    }
}