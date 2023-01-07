using Harmony;
using HellsingCore.API.QM;
using HellsingCore.ButtonAPI;
using HellsingPc.Exploits;
using HellsingPc.Misc;
using MelonLoader;
using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.SDKBase;
using Player = VRC.Player;

[assembly: MelonInfo(typeof(HellsingPc.Main), "Hellsing Client", "0.0.1", "Remi#0666")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonColor(ConsoleColor.DarkMagenta)]

namespace HellsingPc
{

    public class Main : MelonMod
    {
       
        public static bool Earrape = false;
        public static bool yeet;
        public static bool Fly;
        public static bool SuperJump;
        public static bool SuperSpeed;
        public static bool Force_Pickups;
        public static bool toggledebug;
        public static bool toggleesp;
        public static bool Ui;
        public static GameObject UserInterface;

        public override void OnUpdate()
        {

            //Esp
            if (Utils.esp.ESP == true)
            {

                Utils.esp.espmethod();
            }

            //fly
            HellsingPc.Exploits.Fly.fly();
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    HellsingPc.Exploits.Fly.togglefly(Fly);
                }
            }
        }

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Loading Hellsing Client...");
            MelonLogger.Msg("By Remi#0666");
            MelonCoroutines.Start(WaitForUI());

            IEnumerator WaitForUI()
            {
                while (VRCUiManager.field_Private_Static_VRCUiManager_0 == null) yield return null; // wait till VRCUIManger isnt null
                foreach (var GameObjects in Resources.FindObjectsOfTypeAll<GameObject>())
                {
                    if (GameObjects.name.Contains("UserInterface"))
                    {
                        UserInterface = GameObjects;
                    }
                }
                while (APIUtils.QuickMenuInstance == null) yield return null;
                Hooks();
                MenuStart();
                APIUtils.GetUserInterface();
                HellsingPc.Misc.CustomUi.QmCustom();
                yield break;
            }

        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (buildIndex == 1)
            {
                MelonCoroutines.Start(HellsingPc.Misc.LoadingMusic.LoadingScreen());
            }
            if (buildIndex == 2)
            {
                MelonCoroutines.Start(HellsingPc.Misc.LoadingMusic.ChangeLoadingScreen());
            }

        }

        public static void MenuStart()
        {
            MelonLogger.Msg("Initializing Hellsing Menu...");
            MelonLogger.Msg("initializing TargetMenu!");

            #region TargetMenu
            //Target
            var TargetMenu = new QMNestedButton("Menu_SelectedUser_Local", 1.5f, -0.7f, "Target", "Target", "Target", true);

            var ExploitsTarget = new QMNestedButton(TargetMenu, 1, 0, "Exploits", "Exploits", "Exploits");
            var AmongUsTarget = new QMNestedButton(TargetMenu, 2, 0, "AmongUs", "AmongUs", "AmongUs");
            var Murder4Target = new QMNestedButton(TargetMenu, 3, 0, "Murder4", "Murder4", "Murder4");


            //worldHacks Target Buttons

            //AmongUs
            new QMSingleButton(AmongUsTarget, 1, 0, "ResetCourpse", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusResetCourpse, "", true);
            new QMSingleButton(AmongUsTarget, 2, 0, "ReportCourpse", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusReportCourpse, "", true);
            new QMSingleButton(AmongUsTarget, 3, 0, "AssignM", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusAssignM, "", true);
            new QMSingleButton(AmongUsTarget, 4, 0, "AssignB", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusAssignB, "", true);
            new QMSingleButton(AmongUsTarget, 2, .5f, "Kill", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusKillTarget, "", true);
            new QMSingleButton(AmongUsTarget, 3, .5f, "VoteOut", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusVoteOutTarget, "", true);


            //Murder4
            new QMSingleButton(Murder4Target, 1, 0, "AssignB", HellsingPc.Exploits.WorldHacks.Murder4.Murder4AssignB, "", true);
            new QMSingleButton(Murder4Target, 2, 0, "AssignM", HellsingPc.Exploits.WorldHacks.Murder4.Murder4AssignM, "", true);
            new QMSingleButton(Murder4Target, 3, 0, "AssignD", HellsingPc.Exploits.WorldHacks.Murder4.Murder4AssignD, "", true);
            new QMSingleButton(Murder4Target, 4, 0, "Clues", HellsingPc.Exploits.WorldHacks.Murder4.Murder4FinishClues, "", true);
            new QMSingleButton(Murder4Target, 2, .5f, "Kill", HellsingPc.Exploits.WorldHacks.Murder4.Murder4TargetKill, "", true);
            new QMSingleButton(Murder4Target, 3, .5f, "Flash", HellsingPc.Exploits.WorldHacks.Murder4.Murder4TargetFlash, "", true);



            //Expoits Target Buttons
            new QMSingleButton(ExploitsTarget, 1, 0, "BringAllPickups", () =>
            {
                foreach (VRC_Pickup VRCPickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                {
                    VRCPickup.transform.position = IUserExtension.SelectedVRCPlayer().transform.position;
                }
            }, "", false);

            //BasePage Buttons
            new QMSingleButton(TargetMenu, 4, 0, "TP", () =>
            {
                VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.TeleportTo(IUserExtension.SelectedVRCPlayer().transform.position, IUserExtension.SelectedVRCPlayer().transform.rotation);
            }, "", false);

            #endregion

            MelonLogger.Msg("initialized TargetMenu!");

            #region MenuStuff

            //Tab
            var tabMenu = new QMTabMenu("Open Hellsing menu", "Hellsing Client", HellsingResources.Resources.LoadSprite("HellsingTab.png"));

            //Exploits Menu
            var ExploitsMenu = new QMNestedButton(tabMenu, 1, 0, "Exploits", "Exploits", "Exploits", true);
            var PickupsMenu = new QMNestedButton(ExploitsMenu, 2, 0, "Pickups", "Pickups", "Pickups", true);
            var MovementsMenu = new QMNestedButton(ExploitsMenu, 1, 0, "Movement", "Movement", "Movement", true);
            var VisualsMenu = new QMNestedButton(ExploitsMenu, 1, 0.5f, "Visuals", "Visuals", "Visuals", true);

            //photon Menu
            var PhotonMenu = new QMNestedButton(tabMenu, 2, 0, "Photon", "Photon", "Photon", true);

            //WorldHacks Menu
            var WorldHacksMenu = new QMNestedButton(ExploitsMenu, 2, .5f, "WorldHack", "WorldHack", "WorldHack", true);
            var MurderHacksMenu = new QMNestedButton(WorldHacksMenu, 1, 0, "Muder4", "Muder4", "Muder4", true);
            var AmongUsHacksMenu = new QMNestedButton(WorldHacksMenu, 2, 0, "AmongUs", "AmongUs", "AmongUs", true);
            var PrisonHacksMenu = new QMNestedButton(WorldHacksMenu, 3, 0, "Prison", "Prison", "Prison", true);
            var JustBHacksMenu = new QMNestedButton(WorldHacksMenu, 4, 0, "JustB", "JustB", "JustB", true);
            //Spoofers Menu
            var SpoofersMenu = new QMNestedButton(tabMenu, 3, 0, "Spoofers", "Spoofers", "Spoofers", true);
            //Antis Menu
            var AntisMenu = new QMNestedButton(tabMenu, 4, 0, "Antis", "Antis", "Antis", true);
            //Options Menu
            var OptionsMenu = new QMNestedButton(tabMenu, 3, 3.5f, "Options", "Options", "Options", true);
            //Credits Menu
            var CreditsMenu = new QMNestedButton(tabMenu, 4, 3.5f, "Credits", "Credits", "Credits", true);

            #endregion

            MelonLogger.Msg("initialized Menus!");


            new QMSingleButton(PickupsMenu, 1, 0, "Bring Pickups", () =>
              {
                  foreach (VRC_Pickup VRCPickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                  {
                      Networking.LocalPlayer.TakeOwnership(VRCPickup.gameObject);
                      VRCPickup.transform.position = Player.prop_Player_0.transform.position;
                  }
              }, "", true);

            new QMSingleButton(PickupsMenu, 2, 0, "Respawn pickups", () =>
            {
                foreach (VRC_Pickup VRCPickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                {
                    Networking.LocalPlayer.TakeOwnership(VRCPickup.gameObject);
                    VRCPickup.transform.position = new Vector3(0, -9999, 0);
                }
            }, "", true);

            new QMSingleButton(PickupsMenu, 3, 0, "Yeet Pickups", () =>
            {
                if (yeet == true)
                {
                    yeet = false;
                    foreach (VRC_Pickup VRCPickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                    {

                        VRCPickup.ThrowVelocityBoostScale = 2;
                    }
                }
                else

               if (yeet == false)
                {
                    yeet = true;
                    foreach (VRC_Pickup VRCPickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                    {

                        VRCPickup.ThrowVelocityBoostScale = 15;
                    }
                }
            }, "", true);

            new QMSingleButton(PickupsMenu, 4, 0, "Drop Pickups", () =>
            {
                foreach (VRC_Pickup VRCPickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                {
                    Networking.LocalPlayer.TakeOwnership(VRCPickup.gameObject);

                }
            }, "", true);

            new QMSingleButton(PickupsMenu, 1, .5f, "Force Pickups", () =>
            {
                if (Main.Force_Pickups)
                {
                    HellsingPc.Main.Force_Pickups = false;

                }
                else
                {
                    HellsingPc.Main.Force_Pickups = true;
                }
            }, "", true);




            MelonLogger.Msg("initialized Pickups Exploits!");



            new QMSingleButton(MovementsMenu, 1, .5f, "DecreaseSpeed", () =>
            {
                VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(Networking.LocalPlayer.GetWalkSpeed() / 2);
                VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(Networking.LocalPlayer.GetRunSpeed() / 2);
                VRC.SDKBase.Networking.LocalPlayer.SetStrafeSpeed(Networking.LocalPlayer.GetRunSpeed() / 2);
            }, "", true);

            new QMSingleButton(MovementsMenu, 1, 0, "IncreaseSpeed", () =>
            {
                VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(Networking.LocalPlayer.GetWalkSpeed() * 2);
                VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(Networking.LocalPlayer.GetRunSpeed() * 2);
                VRC.SDKBase.Networking.LocalPlayer.SetStrafeSpeed(Networking.LocalPlayer.GetRunSpeed() * 2);
            }, "", true);

            new QMSingleButton(MovementsMenu, 2, .5f, "DecreaseJump", () =>
            {
                VRC.SDKBase.Networking.LocalPlayer.SetJumpImpulse(Networking.LocalPlayer.GetJumpImpulse() / 2);
            }, "", true);

            new QMSingleButton(MovementsMenu, 2, 0, "IncreaseJump", () =>
            {
                VRC.SDKBase.Networking.LocalPlayer.SetJumpImpulse(Networking.LocalPlayer.GetJumpImpulse() * 2);
            }, "", true);
            new QMSingleButton(MovementsMenu, 3, 0, "DefaultJump", () =>
            {
                Networking.LocalPlayer.SetJumpImpulse(3);
            }, "", true);
            new QMSingleButton(MovementsMenu, 3, .5f, "DefaultSpeed", () =>
            {
                VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(4);
                VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(3);
                VRC.SDKBase.Networking.LocalPlayer.SetStrafeSpeed(3);
            }, "", true);
            new QMSingleButton(MovementsMenu, 4, 0, "ForceJump", () =>
            {
                Networking.LocalPlayer.SetJumpImpulse(3);
            }, "", true);

            new QMSingleButton(MovementsMenu, 4, .5f, "Fly", () =>
            {
                HellsingPc.Exploits.Fly.togglefly(Fly);
            }, "", true);




            MelonLogger.Msg("initialized Movements Exloits!");

            new QMSingleButton(VisualsMenu, 1, 0, "ESP", () =>
            {
                Exploits.ESP.ToggleESP(toggleesp);
            }
            , "", true);


            MelonLogger.Msg("initialized Visuals Exploits!");

            //Murder

            new QMSingleButton(MurderHacksMenu, 1, 0, "Start", HellsingPc.Exploits.WorldHacks.Murder4.Murder4Start, "", true);
            new QMSingleButton(MurderHacksMenu, 2, 0, "Abort", HellsingPc.Exploits.WorldHacks.Murder4.Murder4Abort, "", true);
            new QMSingleButton(MurderHacksMenu, 3, 0, "WinB", HellsingPc.Exploits.WorldHacks.Murder4.Murder4WinB, "", true);
            new QMSingleButton(MurderHacksMenu, 4, 0, "WinM", HellsingPc.Exploits.WorldHacks.Murder4.Murder4WinM, "", true);
            new QMSingleButton(MurderHacksMenu, 2, .5f, "KillAll", HellsingPc.Exploits.WorldHacks.Murder4.Murder4KillAll, "", true);
            new QMSingleButton(MurderHacksMenu, 3, .5f, "SeeInDark", HellsingPc.Exploits.WorldHacks.Murder4.Murder4SeeInDark, "", true);

            //AmongUs

            new QMSingleButton(AmongUsHacksMenu, 1, 0, "BreakLight", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusBreakLights, "", true);
            new QMSingleButton(AmongUsHacksMenu, 2, 0, "FixLight", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusFixLights, "", true);
            new QMSingleButton(AmongUsHacksMenu, 3, 0, "BreakOxy", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusBreakOxygen, "", true);
            new QMSingleButton(AmongUsHacksMenu, 4, 0, "FixOxygen", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusFixOxygen, "", true);
            new QMSingleButton(AmongUsHacksMenu, 1, .5f, "BreakCom", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusBreakComms, "", true);
            new QMSingleButton(AmongUsHacksMenu, 2, .5f, "FixComm", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusFixComms, "", true);
            new QMSingleButton(AmongUsHacksMenu, 3, .5f, "BreakReact", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusBreakReactor, "", true);
            new QMSingleButton(AmongUsHacksMenu, 4, .5f, "FixReactor", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusFixReactor, "", true);
            new QMSingleButton(AmongUsHacksMenu, 1, 1, "SkipVote", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusSkipVote, "", true);
            new QMSingleButton(AmongUsHacksMenu, 2, 1, "WinC", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusCWin, "", true);
            new QMSingleButton(AmongUsHacksMenu, 3, 1, "WinI", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusIWin, "", true);
            new QMSingleButton(AmongUsHacksMenu, 4, 1, "KillAll", HellsingPc.Exploits.WorldHacks.Murder4.Murder4KillAll, "", true);
            new QMSingleButton(AmongUsHacksMenu, 2, 1.5f, "Abort", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusAbort, "", true);
            new QMSingleButton(AmongUsHacksMenu, 3, 1.5f, "Start", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusStart, "", true);


            MelonLogger.Msg("initialized World Hacks!");

            //Photon
            new QMSingleButton(PhotonMenu, 1, 0, "E1", () =>
            {
                if (Earrape == false)
                {
                    Earrape = true;
                    MelonCoroutines.Start(E1.EarrapeEvent());
                    MelonLogger.Msg("E1 On");
                }
                else
                    if (Earrape == true)
                {
                    Earrape = false;
                    MelonCoroutines.Stop(E1.EarrapeEvent());
                    MelonLogger.Msg("E1 Off");
                }
            }
           , "", true);

            //Options

            new QMSingleButton(OptionsMenu, 1, 0, "Ui", () =>
            {
                MelonLogger.Msg("Switched UI");
                Misc.CustomUi.ToggleUi();

            }
             , "", false);


            MelonLogger.Msg("initialized Options!");


            //Antis


            //spoofers

            //Debug

            new QMSingleButton(OptionsMenu, 2, 0, "DebugMenuOn", () =>
            {
                HellsingCore.ButtonAPI.Debug.lable.SetActive(true);
                MelonLogger.Msg("DebugMenuOn");
            }
         , "", true);

            new QMSingleButton(OptionsMenu, 2, .5f, "DebugMenuOff", () =>
            {
                HellsingCore.ButtonAPI.Debug.lable.SetActive(false);
                MelonLogger.Msg("DebugMenuOff");
            }
        , "", true);

            //test




            //credits
            new QMSingleButton(CreditsMenu, 2, 0, "Discord", () =>
            {
                MelonLogger.Msg("https://discord.gg/7r928aKyGz");
            }, "", false);

            new QMSingleButton(CreditsMenu, 1, 0, "Remi#0666", () =>
            {
            }, "", true);

            new QMSingleButton(CreditsMenu, 1, .5f, "IkariNoKami", () =>
            {
            }, "Helped me with everything", true);


            MelonLogger.Msg("initialized Credits!");
            MelonLogger.Msg("initialized Menu!");

        }


        public void Hooks()
        {
            NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(onplayerjoin));
            NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_2.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(onplayerleave));


        }

        public void onplayerjoin(Player player)
        {

            //Debug
            MelonLogger.Msg($"{player.prop_APIUser_0.displayName} Joined");
            HellsingCore.ButtonAPI.Debug.Message($"{player.prop_APIUser_0.displayName} Joined");
            if (player.prop_VRCPlayerApi_0.isModerator)
            {
                MelonLogger.Msg($" Moderator Joined!!!");
                HellsingCore.ButtonAPI.Debug.Message($" Moderator Joined!!!");
            }
        }

        public void onplayerleave(Player playr)
        {
            //DebugMenu
            MelonLogger.Msg($"{playr.prop_APIUser_0.displayName} Left");
            HellsingCore.ButtonAPI.Debug.Message($"{playr.prop_APIUser_0.displayName} Left");
        }


    }
}
