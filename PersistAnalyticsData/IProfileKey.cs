using Sitecore.Analytics.Model.Framework;
using System;
namespace PersistAnalyticsData
{
    public interface IProfileKey : IElement
    {
        string Name { get; set; }
        float Value { get; set; }
    }
}
