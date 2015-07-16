using Sitecore.Analytics.Model.Framework;
using System;
namespace PersistAnalyticsData
{
    interface IProfilingStorage : IFacet,IElement
    {
        Sitecore.Analytics.Model.Framework.IElementDictionary<IProfile> Profiles { get; }
    }
}
