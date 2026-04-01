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
        [Slider(8, 22)]
        public int fontSize = 18;

        [Section("Text color")]

        [Name("Text - Red")]
        [Description(" ")]
        [Slider(0, 255)]
        public byte textR = 0;

        [Name("Text - Green")]
        [Description(" ")]
        [Slider(0, 255)]
        public int textG = 0;

        [Name("Text - Blue")]
        [Description(" ")]
        [Slider(0, 255)]
        public int textB = 0;

        [Section("Background color")]

        [Name("Background - Red")]
        [Description(" ")]
        [Slider(0, 255)]
        public int bgR = 185;

        [Name("Background - Green")]
        [Description(" ")]
        [Slider(0, 255)]
        public int bgG = 185;

        [Name("Background - Blue")]
        [Description(" ")]
        [Slider(0, 255)]
        public int bgB = 185;


        protected override void OnConfirm()
        {
            base.OnConfirm();
            uConsole.m_Instance.m_Activate = openConsoleButton;
            uConsole.m_Instance.m_LogFontSize = fontSize;
            uConsole.m_Instance.m_InputFieldFontSize = fontSize;
            uConsole.m_Instance.m_InputFieldBackGroundColor = new Color32((byte)Settings.options.bgR, (byte)Settings.options.bgG, (byte)Settings.options.bgB, 255);
            uConsole.m_Instance.m_InputFieldFontColor = new Color32((byte)Settings.options.textR, (byte)Settings.options.textG, (byte)Settings.options.textB, 255);
            uConsole.m_Instance.m_LogBackGroundColor = new Color32((byte)Settings.options.bgR, (byte)Settings.options.bgG, (byte)Settings.options.bgB, 255);
            uConsole.m_Instance.m_LogFontColor = new Color32((byte)Settings.options.textR, (byte)Settings.options.textG, (byte)Settings.options.textB, 255);

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
            uConsole.m_Instance.m_InputFieldBackGroundColor = new Color32((byte)Settings.options.bgR, (byte)Settings.options.bgG, (byte)Settings.options.bgB, 255);
            uConsole.m_Instance.m_InputFieldFontColor = new Color32((byte)Settings.options.textR, (byte)Settings.options.textG, (byte)Settings.options.textB, 255);
            uConsole.m_Instance.m_LogBackGroundColor = new Color32((byte)Settings.options.bgR, (byte)Settings.options.bgG, (byte)Settings.options.bgB, 255);
            uConsole.m_Instance.m_LogFontColor = new Color32((byte)Settings.options.textR, (byte)Settings.options.textG, (byte)Settings.options.textB, 255);

            uConsole.m_Instance.m_InputFieldFontSize = Settings.options.fontSize;
        }
    }
}
