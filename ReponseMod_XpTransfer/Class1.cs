using Rocket.API;
using Rocket.Core.Commands;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReponseMod_XpTransfer
{
    public class Class1 : RocketPlugin<Config>
    {
        protected override void Load()
        {
            base.Load();
        }

        [RocketCommand("xpsend", "you send xp to the specified user", "xpsend <player> <Amount> <Description>", AllowedCaller.Both)]
        [RocketCommandPermission("reponse.xpsend")]
        public void xpsend(IRocketPlayer caller, string[] args)
        {
            UnturnedPlayer pl = (UnturnedPlayer)caller;
            UnturnedPlayer pls = UnturnedPlayer.FromName(args[0]);
            var miktar = Convert.ToUInt64(args[1]);
            if (args.Length < 1)
            {
                return;
            }

            if (pls == null)
            {
                ChatManager.serverSendMessage($"<color=green>Unsucces |</color> The User was Not Found.", Color.white, null, pl.SteamPlayer(), EChatMode.SAY, Configuration.Instance.ServerLogo, true);

            }

            if (args[1] == null)
            {
                ChatManager.serverSendMessage($"<color=green>Unsucces |</color> The User was Not Found.", Color.white, null, pl.SteamPlayer(), EChatMode.SAY, Configuration.Instance.ServerLogo, true);

            }
            if (pl.Experience >= miktar)
            {
                ChatManager.serverSendMessage($"<color=green>SUCCES |</color> You Successfully Sent Xp.", Color.white, null, pl.SteamPlayer(), EChatMode.SAY, Configuration.Instance.ServerLogo, true);
                ChatManager.serverSendMessage($"<color=green>XP |</color> <color=orange>{pls.CharacterName}</color> Sent <color=yellow>{miktar}</color> Xp. Description;", Color.white, null, pls.SteamPlayer(), EChatMode.SAY, Configuration.Instance.ServerLogo, true);
                ChatManager.serverSendMessage($"{args[2]}", Color.white, null, pls.SteamPlayer(), EChatMode.SAY, Configuration.Instance.ServerLogo, true);
                pl.Experience -= (uint)miktar;
                pls.Experience += (uint)miktar;

            }

        }
    } 
}
