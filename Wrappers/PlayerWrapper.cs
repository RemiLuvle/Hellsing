using I18N.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.DataModel;
using VRC.SDKBase;
using VRC.UI;
using VRC.UI.Elements.Menus;

//Credit:Evil Eye wrapper 
namespace Wrappers
{
    static class PlayerWrapper
    {
        //converted all the bs to one lines to clean the class
        public static Dictionary<int, VRC.Player> PlayersActorID = new Dictionary<int, VRC.Player>();
        public static Player[] GetAllPlayers() => PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
        public static Player GetByUsrID(string usrID) => GetAllPlayers().Where(x => x.field_Private_APIUser_0.id == usrID).FirstOrDefault();
        public static void Teleport(this Player player) => LocalVRCPlayer().transform.position = player.prop_VRCPlayer_0.transform.position;
        public static VRCPlayer LocalVRCPlayer() => VRCPlayer.field_Internal_Static_VRCPlayer_0;
        public static APIUser GetAPIUser(this VRC.Player player) => player.prop_APIUser_0;
        public static float GetFrames(this Player player) => (player._playerNet.prop_Byte_0 != 0) ? Mathf.Floor(1000f / (float)player._playerNet.prop_Byte_0) : -1f;
        public static short GetPing(this Player player) => player._playerNet.field_Private_Int16_0;
        public static bool IsBot(this Player player) => player.GetPing() <= 0 && player.GetFrames() <= 0 || player.transform.position == Vector3.zero;
        public static Player GetPlayer(this VRCPlayer player) => player.prop_Player_0;
        public static VRCPlayer GetVRCPlayer(this Player player) => player._vrcplayer;
        public static Color GetTrustColor(this VRC.Player player) => VRCPlayer.Method_Public_Static_Color_APIUser_0(player.GetAPIUser());
        public static APIUser GetAPIUser(this VRCPlayer Instance) => Instance.GetPlayer().GetAPIUser();
        public static VRCPlayerApi GetVRCPlayerApi(this Player Instance) => Instance?.prop_VRCPlayerApi_0;
        public static bool GetIsMaster(this Player Instance) => Instance.GetVRCPlayerApi().isMaster;
        public static int GetActorNumber(this Player player) => player.GetVRCPlayerApi() != null ? player.GetVRCPlayerApi().playerId : -1;
        public static void SetHide(this VRCPlayer Instance, bool State) => Instance.GetPlayer().SetHide(State);
        public static void SetHide(this Player Instance, bool State) => Instance.transform.Find("ForwardDirection").gameObject.active = !State;
        public static USpeaker GetUspeaker(this Player player) => player.prop_USpeaker_0;
        public static ulong GetSteamID(this Player player) => (player.GetVRCPlayer().field_Private_UInt64_0 > 10000000000000000UL) ? player.GetVRCPlayer().field_Private_UInt64_0 : ulong.Parse(player.GetPhotonPlayer().prop_Hashtable_0["steamUserID"].ToString());
        public static Photon.Realtime.Player GetPhotonPlayer(this Player player) => player.prop_Player_1;
        public static bool ClientDetect(this Player player) => player.GetFrames() > 90 || player.GetFrames() < 1 || player.GetPing() > 665 || player.GetPing() < 0;
        public static ApiAvatar GetAPIAvatar(this VRCPlayer vrcPlayer) => vrcPlayer.prop_ApiAvatar_0;
        public static ApiAvatar GetAPIAvatar(this Player player) => player.GetVRCPlayer().GetAPIAvatar();
        public static Player GetPlayer() => Player.prop_Player_0;
        internal static bool IsAdmin(this Player player) => player.prop_APIUser_0.hasModerationPowers || player.prop_APIUser_0.tags.Contains("admin_moderator") || player.prop_APIUser_0.hasSuperPowers || player.prop_APIUser_0.tags.Contains("admin_");

        internal static string GetFramesColord(this Player player)
        {
            float fps = player.GetFrames();
            if (fps > 80)
                return "<color=#AD00FF>FPS: " + fps + "</color>";
            else if (fps > 30)
                return "<color=#8100BE>FPS: " + fps + "</color>";
            else
                return "<color=#48006B>FPS: " + fps + "</color>";
        }
        internal static string GetRankColord(this Player player)
        {
            bool MOD = player.prop_APIUser_0.hasModerationPowers || player.prop_APIUser_0.tags.Contains("admin_moderator");
            bool ADMIN = player.prop_APIUser_0.hasSuperPowers || player.prop_APIUser_0.tags.Contains("admin_");
            if (ADMIN)
                return "<color=#ff0000>[Admin User]</color>";
            else if (MOD)
                return "<color=red>[Moderation User]</color>";
            else if (player.prop_APIUser_0.hasVeteranTrustLevel)
                return "<color=#864EDD>Trusted</color>";
            else if (player.prop_APIUser_0.hasTrustedTrustLevel)
                return "<color=yellow>Known</color>";
            else if (player.prop_APIUser_0.hasKnownTrustLevel)
                return "<color=green>User</color>";
            else if (player.prop_APIUser_0.hasBasicTrustLevel)
                return "<color=blue>New</color>";
            else
                return "<color=white>Vistor</color>";
        }
        public static string GetPingColord(this Player player)
        {
            short ping = player.GetPing();
            if (ping > 150)
                return "<color=#48006B>Ping: " + ping + "</color>";
            else if (ping > 75)
                return "<color=#8100BE>Ping: " + ping + "</color>";
            else
                return "<color=#AD00FF>Ping: " + ping + "</color>";
        }
        internal static string GetAviColord(this Player player)
        {
            string ApiAvi = player.prop_ApiAvatar_0.releaseStatus;

            if (ApiAvi == "internal")
                return " | [<color=green>Public</color>]";
            else
                return " | [<color=red>Private</color>]";
        }
        public static string GetPlatform(this Player player)
        {
            if (player.GetAPIUser().IsOnMobile)
            {
                return "<color=green>Quest</color>";
            }
            else if (player.GetVRCPlayerApi().IsUserInVR())
            {
                return "<color=#CE00D5>Vr</color>";
            }
            else
            {
                return "<color=grey>PC</color>";
            }
        }
        public static Player LocalPlayer
        {
            get
            {
                return Player.prop_Player_0;
            }
        }
        public static bool Amongunsworld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_dd036610-a246-4f52-bf01-9d7cea3405d7";
        }

        // Token: 0x0600003C RID: 60 RVA: 0x000037E0 File Offset: 0x000019E0
        public static bool MurderWorld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe";
        }
        public static void DelegateSafeInvoke(this Delegate @delegate, params object[] args)
        {
            Delegate[] invocationList = @delegate.GetInvocationList();
            for (int i = 0; i < invocationList.Length; i++)
            {
                try
                {
                    invocationList[i].DynamicInvoke(args);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static void ReloadAvatar(this Player player)
        {
            // VRCPlayer.Method_Public_Static_Void_APIUser_0(player.GetAPIUser()); (error one)
            VRCPlayer.Method_Public_Static_Boolean_APIUser_0(player.GetAPIUser());

        }
        public static void ReloadAllAvatars()
        {
            PlayerWrapper.LocalVRCPlayer().Method_Public_Void_Boolean_0(false);
        }

        public static void ChangeAvatar(string AvatarID)
        {
            PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
            component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
            {
                id = AvatarID
            };
            component.ChangeToSelectedAvatar();
        }

        public static List<Player> AllPlayers
        {
            get
            {
                return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray().ToList<Player>();
            }
        }
        public static QuickMenu GetQuickMenu()
        {
            return GameObject.Find("UserInterface/QuickMenu").GetComponent<QuickMenu>();
        }
        public static Player GetSelectedPlayer()
        {
            return PlayerWrapper.GetQuickMenu().field_Private_Player_0;
        }

        public static Player GetPlayerByActorID(int actorId)
        {
            VRC.Player player = null;
            PlayersActorID.TryGetValue(actorId, out player);
            return player;
        }
        public static string GetName(this Player player)
        {
            return player.GetAPIUser().displayName;
        }
        public static bool IsInVR(this Player player)
        {
            return player.GetVRCPlayerApi().IsUserInVR();
        }
        public static void SetGain(float Gain)
        {
            PlayerWrapper.LocalGain = Gain;
        }



        public static void SendVRCEvent(VRC_EventHandler.VrcEvent vrcEvent, VRC_EventHandler.VrcBroadcastType type, GameObject instagator)
        {
            bool flag = PlayerWrapper.handler == null;
            if (flag)
            {
                PlayerWrapper.handler = Resources.FindObjectsOfTypeAll<VRC_EventHandler>().FirstOrDefault<VRC_EventHandler>();
            }
            vrcEvent.ParameterObject = Player.Method_Internal_Static_Player_0().GetUspeaker().gameObject;
            PlayerWrapper.handler.TriggerEvent(vrcEvent, type, instagator, 0f);
        }
        public static float LocalGain
        {
            get
            {
                return USpeaker.field_Internal_Static_Single_1;
            }
            set
            {
                USpeaker.field_Internal_Static_Single_1 = value;
            }
        }
        private static VRC_EventHandler handler;
    }
}