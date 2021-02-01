using StardewModdingAPI;
using StardewModdingAPI.Events;
using Harmony;

namespace ExperienceMultiplier
{

  public class Main : Mod
  {
    public ModConfig Config;

    public override void Entry(IModHelper helper)
    {
      Config = helper.ReadConfig<ModConfig>();
      helper.WriteConfig<ModConfig>(Config);

      helper.Events.GameLoop.SaveLoaded += delegate (object sender, SaveLoadedEventArgs args)
            {
              FarmerPatches.ReloadConfig(helper.ReadConfig<ModConfig>());
            };

      FarmerPatches.Initialize(Monitor, Config);

      var harmony = HarmonyInstance.Create(this.ModManifest.UniqueID);
      harmony.Patch(
       original: AccessTools.Method(typeof(StardewValley.Farmer), nameof(StardewValley.Farmer.gainExperience)),
       prefix: new HarmonyMethod(typeof(FarmerPatches), nameof(FarmerPatches.onGainExperience))
      );

      Monitor.Log("Applied experience hook");
    }

  }
}
