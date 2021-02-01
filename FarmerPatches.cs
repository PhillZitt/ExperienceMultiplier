using StardewModdingAPI;

namespace ExperienceMultiplier
{
  public class FarmerPatches
  {

    private static IMonitor Monitor;
    private static ModConfig Config;


    public static void Initialize(IMonitor monitor, ModConfig config)
    {
      Monitor = monitor;
      Config = config;
    }

    public static void ReloadConfig(ModConfig config)
    {
      Config = config;
    }

    public static bool onGainExperience(StardewValley.Farmer __instance, int which, ref int howMuch)
    {
      howMuch *= Config.GeneralMultiplier;

      switch (which)
      {
        case 0:
          howMuch *= Config.FarmingMultiplier;
          break;
        case 1:
          howMuch *= Config.FishingMultiplier;
          break;
        case 2:
          howMuch *= Config.ForagingMultiplier;
          break;
        case 3:
          howMuch *= Config.MiningMultiplier;
          break;
        case 4:
          howMuch *= Config.CombatMultiplier;
          break;
        case 5:
          howMuch *= Config.LuckMultiplier;
          break;
      }

      return true;
    }

  }
}
