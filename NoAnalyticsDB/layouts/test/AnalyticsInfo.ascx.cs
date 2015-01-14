namespace NoAnalyticsDB.layouts.test
{
    using System;
    using System.Linq;
    public partial class AnalyticsInfo : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var profileFocus = Sitecore.Analytics.Tracker.CurrentVisit.Profiles.FirstOrDefault(p => p.ProfileName == "Focus");
            if (profileFocus != null)
            {
                
                literal.Text = string.Format("Focus: {0} ({1})",profileFocus.PatternLabel,profileFocus.Values) ;
            }
        }
    }
}