using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.AddressableAssets;
using Il2CppTLD.Scenes;
using UnityEngine.ResourceManagement.ResourceLocations;
using Il2CppCollection = Il2CppSystem.Collections.Generic;

namespace DeveloperConsole {
    /*
    [HarmonyPatch(typeof(BootUpdate), "Start")]
    internal static class SceneNameAutocompletePatch {

        private static void Postfix() {
            Il2CppCollection.List<IResourceLocation> scenes = AssetHelper.FindAllAssetsLocations<SceneSet>().Cast<Il2CppCollection.List<IResourceLocation>>();
            Il2CppCollection.List<string> sceneParamaters = new Il2CppCollection.List<string>();

            foreach (IResourceLocation sceneResource in scenes) {
                sceneParamaters.Add(sceneResource.PrimaryKey);
                sceneParamaters.Add(sceneResource.PrimaryKey.ToLowerInvariant());
            }
            sceneParamaters.Sort();

            uConsoleAutoComplete.CreateCommandParameterSet("scene", sceneParamaters);
        }
    }*/

    [HarmonyPatch(typeof(GameManager), nameof(GameManager.Awake))]
    internal static class FixSceneAutoComplete
    {

        private static void Postfix()
        {

            foreach (uConsoleCommandParameterSet ccps in uConsoleAutoComplete.m_CommandParameterSets)
            {
                if (!ccps.m_Commands.Contains("scene"))
                {
                    return;
                }

                Il2CppCollection.List<IResourceLocation> scenes = AssetHelper.FindAllAssetsLocations<SceneSet>().Cast<Il2CppCollection.List<IResourceLocation>>();
                Il2CppCollection.List<string> sceneParamaters = new Il2CppCollection.List<string>();

                foreach (IResourceLocation sceneResource in scenes)
                {
                    if (sceneResource.PrimaryKey.ToLowerInvariant().StartsWith("mod") && !ccps.m_AllowedParameters.Contains(sceneResource.PrimaryKey))
                    {
                        ccps.m_AllowedParameters.Add(sceneResource.PrimaryKey);
                        ccps.m_AllowedParameters.Add(sceneResource.PrimaryKey.ToLowerInvariant());
                    }
                }
            }

        }
    }
}
