// Decompiled with JetBrains decompiler
// Type: Logical.Properties.Settings
// Assembly: BoolGate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F0D7661-EAFC-4F52-BA76-3A0ABDEAAD45
// Assembly location: C:\Program Files (x86)\Atom Softworks\BoolGate\BoolGate.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Logical.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings settings = Settings.defaultInstance;
        return settings;
      }
    }

    private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
    {
    }

    private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
    {
    }
  }
}
