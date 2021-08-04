using Exiled.API.Features;
using PocketSCP106.Command;
using System;
using Player = Exiled.Events.Handlers.Player;
using Scp106 = Exiled.Events.Handlers.Scp106;

namespace PocketSCP106
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "MrAfitol";
        public override string Name => "PocketSCP106";
        public override string Prefix => "pocet_scp_106";
        public override Version RequiredExiledVersion => new Version(1, 11, 1);
        public override Version Version => new Version(1, 0, 0);

        public static Plugin plugin;
        public EventHandlers handlers;
        public Pocket pocket;

        public override void OnEnabled()
        {
            plugin = this;
            handlers = new EventHandlers();
            Player.FailingEscapePocketDimension += handlers.OnExit106No;
            Player.EscapingPocketDimension += handlers.OnExit106Yes;
            Scp106.Teleporting += handlers.OnTeleport106;
            Scp106.CreatingPortal += handlers.NoCreatePortal;
            Player.EnteringPocketDimension += handlers.NoTeleportPlayer;
            Player.Hurting += handlers.NoDamagePocketDimension;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.FailingEscapePocketDimension -= handlers.OnExit106No;
            Player.EscapingPocketDimension -= handlers.OnExit106Yes;
            Scp106.Teleporting -= handlers.OnTeleport106;
            Scp106.CreatingPortal -= handlers.NoCreatePortal;
            Player.EnteringPocketDimension -= handlers.NoTeleportPlayer;
            Player.Hurting -= handlers.NoDamagePocketDimension;
            pocket = null;

            base.OnDisabled();
        }
    }
}
