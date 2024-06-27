using MelonLoader;
using UnityEngine;


namespace DeveloperConsole {

    public static class GearList
    {
       public static Dictionary<string, bool> removeList = new Dictionary<string, bool>();
       
       public static void RemoveFromConsole(string gearName, bool failSilent)
       {
            string lowerGearName = gearName.ToLower();

            if(lowerGearName.Contains("gear_"))
            {
                lowerGearName = lowerGearName.Replace("gear_", "");
            }

            if (!removeList.ContainsKey(lowerGearName))
            {
                removeList.Add(lowerGearName, failSilent);
            }            
       }
    }
}
