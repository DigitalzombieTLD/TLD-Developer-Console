using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace DeveloperConsole
{

    [HarmonyPatch(typeof(uConsole), "GetString")]
    internal static class GearListPatch
    {
        private static void Postfix(uConsole __instance, ref string __result)
        {            
            if (GearList.removeList != null && GearList.removeList.Count > 0)
            {
                string lowerResult = __result.ToLower();

                if (lowerResult.Contains("gear_"))
                {
                    lowerResult = lowerResult.Replace("gear_", "");
                }
                
                if (GearList.removeList.ContainsKey(lowerResult))
                {
                    // Fail silently?
                    if(!GearList.removeList[lowerResult])
                    {
                        MelonLogger.Msg("Adding of item [" + __result + "] disabled");
                        Debug.Log("Adding of item [" + __result + "] disabled\n");
                    }

                    __result = null;
                }
            }           
        }
    }
}