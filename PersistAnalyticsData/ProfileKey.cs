using Sitecore.Analytics.Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistAnalyticsData
{
    [Serializable]
    public class ProfileKey : Facet, IProfileKey
    {
        const string NAME = "name";
        const string VALUE = "value";

        public ProfileKey()
        {
            base.EnsureAttribute<float>(VALUE);
            base.EnsureAttribute<string>(NAME);
        }


        public float Value
        {
            get { return base.GetAttribute<float>(VALUE); }
            set { base.SetAttribute<float>(VALUE,value); }
        }

        public string Name
        {
            get { return base.GetAttribute<string>(NAME); }
            set { base.SetAttribute<string>(NAME, value); }
        }

    }
}
