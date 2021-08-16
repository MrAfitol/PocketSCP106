using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;
using System;
using UnityEngine;
using MEC;
using System.Collections;
using System.Collections.Generic;

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

        public bool CoolDown = false;

        public bool CoolDownNoErrorB = false;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(((PlayerCommandSender)sender).ReferenceHub);

            if (player.Role != RoleType.Scp106)
            {
                response = "You are not SCP-106";
                return false;
            }

            if (!player.IsInPocketDimension)
            {
                Pos = player.Position;
            }

            if (CoolDown)
            {
                player.ShowHint("<b><color=#4E03FF>" + Plugin.plugin.Config.CooldownText + "</color><b>", 5);

                response = Plugin.plugin.Config.CooldownText;
                return false;
            }

            if (CoolDownNoErrorB)
            {
                player.ShowHint("<b><color=#4E03FF>" + Plugin.plugin.Config.CooldownInTeleport + "</color><b>", 5);

                response = Plugin.plugin.Config.CooldownInTeleport;
                return false;
            }

            if (!player.IsInPocketDimension)
            {
                Timing.CallDelayed(0.5f, () => {
                    if (Plugin.plugin.Config.AnimTeleportStart)
                    {
                        /*Timing.CallDelayed(0.3f, () => {
                            player.ReferenceHub.scp106PlayerScript.SetPortalPosition(new Vector3(0.2f, -2000.67f, -0.05f));
                            player.ReferenceHub.scp106PlayerScript.UseTeleport();
                        });*/

                        player.ReferenceHub.scp106PlayerScript.SetPortalPosition(new Vector3(0.2f, -2000.67f, -0.05f));

                        if (player.ReferenceHub.scp106PlayerScript.portalPosition != new Vector3(0.2f, -2000.67f, -0.05f))
                        {
                            player.ReferenceHub.scp106PlayerScript.SetPortalPosition(new Vector3(0.2f, -2000.67f, -0.05f));
                        }

                        player.ReferenceHub.scp106PlayerScript.UseTeleport();

                        Timing.RunCoroutine(CoolDownNoError(), "cooldownnoerror");

                        Timing.CallDelayed(10f, () => player.ReferenceHub.scp106PlayerScript.DeletePortal());

                        Plugin.plugin.handlers.isgod = true;
                    }
                    else
                    {
                        player.Position = new Vector3(0.2f, -1998.67f, -0.05f);

                        Plugin.plugin.handlers.isgod = true;
                    }

                    player.ShowHint("<b><color=#F70505>" + Plugin.plugin.Config.ToPocketDimension + "</color></b>", 5);
                });

                response = Plugin.plugin.Config.ToPocketDimension;
                return false;

            }
            else
            {

                Plugin.plugin.handlers.isgod = false;

                Timing.KillCoroutines("cooldownnoerror");

                Timing.CallDelayed(0.5f, () =>
                {
                    if (Plugin.plugin.Config.AnimTeleportBack)
                    {
                        player.ReferenceHub.scp106PlayerScript.SetPortalPosition(new Vector3(Pos.x, Pos.y - 2f, Pos.z));
                        if (player.ReferenceHub.scp106PlayerScript.portalPosition != new Vector3(Pos.x, Pos.y - 2f, Pos.z))
                        {
                            player.ReferenceHub.scp106PlayerScript.SetPortalPosition(new Vector3(Pos.x, Pos.y - 2f, Pos.z));
                        }
                        player.ReferenceHub.scp106PlayerScript.UseTeleport();

                        Timing.CallDelayed(5f, () => {
                            if (player.Position.x != Pos.x && player.Position.z != Pos.z)
                            {
                                player.ReferenceHub.scp106PlayerScript.SetPortalPosition(new Vector3(Pos.x, Pos.y - 2f, Pos.z));
                                player.ReferenceHub.scp106PlayerScript.UseTeleport();
                            }
                        });

                        Timing.RunCoroutine(CoolDownNoError(), "cooldownnoerror");

                        Timing.CallDelayed(10f, () => {
                            Timing.KillCoroutines("cooldownnoerror");
                            Timing.RunCoroutine(CoolDownTP(), "cooldown");
                            player.ReferenceHub.scp106PlayerScript.DeletePortal();
                        });
                    }
                    else
                    {
                        player.Position = Pos;

                        Timing.RunCoroutine(CoolDownTP(), "cooldown");
                    }

                player.ShowHint("<b><color=#F70505>" + Plugin.plugin.Config.ExitPocketDimension + "</color></b>", 5);
                });
               
                response = Plugin.plugin.Config.ExitPocketDimension;
                return false;
            }
        }

        IEnumerator<float> CoolDownTP()
        {
            CoolDown = true;

            yield return Timing.WaitForSeconds(Plugin.plugin.Config.CooldownTP);

            CoolDown = false;
        }

        IEnumerator<float> CoolDownNoError()
        {
            CoolDownNoErrorB = true;

            yield return Timing.WaitForSeconds(10f);

            CoolDownNoErrorB = false;
        }
    }
}
