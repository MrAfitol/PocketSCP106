using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PocketSCP106
{
    public class Config : IConfig
    {
        
        [Description("Use this plugin?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Issue god mode SCP106 when he is in his dimension?")]
        public bool IsGodMod { get; set; } = true;

        [Description("What to write if SCP106 cannot teleport to its dimension?")]
        public string NoTeleport { get; set; } = "<b><color=#09F022>You cannot teleport</color></b>";

        [Description("What to write if SCP106 cannot create a portal to its dimension?")]
        public string NoCreatePortal { get; set; } = "<b><color=#09F022>You cannot create a portal here</color></b>";

        [Description("What will be written when SCP106 teleports to its dimension?")]
        public string ToPocketDimension { get; set; } = "You have moved to your dimension";

        [Description("What will be written when SCP106 leaves its dimension?")]
        public string ExitPocketDimension { get; set; } = "You are out of your dimension";
    }
}
