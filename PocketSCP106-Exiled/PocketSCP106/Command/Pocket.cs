using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;
using System;
using UnityEngine;

namespace PocketSCP106.Command
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Pocket : ICommand
    {
        public string Command { get; } = "pocket";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "Teleport to Pocket Dimension";

        Vector3 Pos;

        public float HP;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(((PlayerCommandSender)sender).ReferenceHub);

            if (player.Role != RoleType.Scp106)
            {
                response = "You are not SCP-106";
                return false;
            }

            if (player.IsInPocketDimension == false)
            {
                Pos = player.Position;

                HP = player.Health;
            }

            if (player.IsInPocketDimension == false)
            {

                player.Position = new Vector3(0, -1998.67f, 2);

                player.ShowHint("<b><color=#F70505>" + Plugin.plugin.Config.ToPocketDimension + "</color></b>", 5);

                Plugin.plugin.handlers.isgod = true;

                response = Plugin.plugin.Config.ToPocketDimension;
                return false;
            }
            else
            {

                player.Position = Pos;

                player.ShowHint("<b><color=#F70505>" + Plugin.plugin.Config.ExitPocketDimension + "</color></b>", 5);

                Plugin.plugin.handlers.isgod = false;

                response = Plugin.plugin.Config.ExitPocketDimension;
                return false;
            }
        }
    }
}
