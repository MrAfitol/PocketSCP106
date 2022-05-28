using Exiled.API.Features;
using Exiled.Events.EventArgs;
using UnityEngine;

namespace PocketSCP106
{
    public class EventHandlers
    {

        public bool isgod;

        public void OnExit106No(FailingEscapePocketDimensionEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp106)
            {
                ev.IsAllowed = false;
                ev.Player.Position = new Vector3(0, -1998.67f, 2);
            }
        }

        public void OnExit106Yes(EscapingPocketDimensionEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp106)
            {
                ev.IsAllowed = false;
                ev.Player.Position = new Vector3(0, -1998.67f, 2);
            }
        }

        public void NoTeleportPlayer(EnteringPocketDimensionEventArgs ev)
        {
            if (isgod)
            {
                ev.IsAllowed = false;
            }
        }

        public void OnTeleport106(TeleportingEventArgs ev)
        {
            if (isgod)
            {
                ev.IsAllowed = false;
                ev.Player.ShowHint(Plugin.plugin.Config.NoTeleport, 5);
            }
        }

        public void NoCreatePortal(CreatingPortalEventArgs ev)
        {
            if (isgod)
            {
                ev.IsAllowed = false;
                ev.Player.ShowHint(Plugin.plugin.Config.NoCreatePortal, 5);
            }
        }

        public void NoDamagePocketDimension(HurtingEventArgs ev)
        {
            if (ev.Target.Role == RoleType.Scp106 && ev.Target.IsInPocketDimension)
            {
                ev.IsAllowed = false;
            }    
        }
    }
}