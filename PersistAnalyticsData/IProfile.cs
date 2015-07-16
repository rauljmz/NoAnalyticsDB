using Sitecore.Analytics.Model.Framework;
using System;
using System.Collections.Generic;
namespace PersistAnalyticsData
{
    public interface IProfile : IElement
    {
        Sitecore.Analytics.Model.Framework.IElementDictionary<IProfileKey> ProfileKeys { get; }

        IEnumerable<System.Collections.Generic.KeyValuePair<string, float>> Values { get;  }
    }
}
