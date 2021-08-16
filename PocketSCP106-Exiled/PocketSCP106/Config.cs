using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PocketSCP106
{
    public class Config : IConfig
    {
        
        [Description("Use this plugin?")]
        public bool IsEnabled { get; set; } = true;

        [Description("What to write if SCP106 cannot teleport to its dimension?")]
        public string NoTeleport { get; set; } = "<b><color=#09F022>You cannot teleport</color></b>";

        [Description("What to write if SCP106 cannot create a portal to its dimension?")]
        public string NoCreatePortal { get; set; } = "<b><color=#09F022>You cannot create a portal here</color></b>";

        [Description("What will be written when SCP106 teleports to its dimension?")]
        public string ToPocketDimension { get; set; } = "You have moved to your dimension";

        [Description("What will be written when SCP106 leaves its dimension?")]
        public string ExitPocketDimension { get; set; } = "You are out of your dimension";

        [Description("You want the Scp-106 to teleport through the dira when teleporting to its dimension, this will take longer?")]
        public bool AnimTeleportStart { get; set; } = true;

        [Description("Do you want Scp-106 to teleport through the dira when exiting dimension, will it take longer?")]
        public bool AnimTeleportBack { get; set; } = true;

        [Description("How long will Scp-106 wait until the next teleportation?")]
        public float CooldownTP { get; set; } = 10f;

        [Description("What will be written when Scp-106 is waiting for the next teleportation?")]
        public string CooldownText { get; set; } = "You cannot use this command so often";

        [Description("What will be written when Scp-106 teleports?")]
        public string CooldownInTeleport { get; set; } = "Wait for the end of teleportation";
    }
}
