using UnityEngine;
using ModSettings;
using MelonLoader;
using Il2Cpp;

namespace DeveloperConsole
{
    internal class DeveloperConsoleSettings : JsonModSettings
    {
        [Section("Buttons")]

        [Name("Open/Close")]
        [Description("Standard F1")]
        public KeyCode openConsoleButton = KeyCode.F1;

        [Name("Font size")]
        [Description("Here text")]
        [Slider(8, 50)]
        public int fontSize = 18;

        protected override void OnConfirm()
        {
            base.OnConfirm();
            uConsole.m_Instance.m_Activate = openConsoleButton;
            uConsole.m_Instance.m_LogFontSize = fontSize;
            uConsole.m_Instance.m_InputFieldFontSize = fontSize;
        }
    }

    internal static class Settings
    {
        public static DeveloperConsoleSettings options;

        public static void OnLoad()
        {
            options = new DeveloperConsoleSettings();
            options.AddToModSettings("DeveloperConsole");           
        }

        public static void Apply()
        {
            uConsole.m_Instance.m_Activate = Settings.options.openConsoleButton;
            uConsole.m_Instance.m_LogFontSize = Settings.options.fontSize;
            uConsole.m_Instance.m_InputFieldFontSize = Settings.options.fontSize;
        }
    }
}
