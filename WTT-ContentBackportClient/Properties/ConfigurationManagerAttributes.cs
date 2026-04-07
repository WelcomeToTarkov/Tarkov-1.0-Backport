using System;
using BepInEx.Configuration;

namespace WTTArmoryClient.Properties;

internal sealed class ConfigurationManagerAttributes
{
    public bool? ShowRangeAsPercent;

    public Action<ConfigEntryBase> CustomDrawer;

    public bool? Browsable;

    public string Category;

    public object DefaultValue;

    public bool? HideDefaultButton;

    public bool? HideSettingName;

    public string Description;

    public string DispName;

    public int? Order;

    public bool? ReadOnly;

    public bool? IsAdvanced;

    public Func<object, string> ObjToStr;

    public Func<string, object> StrToObj;
}