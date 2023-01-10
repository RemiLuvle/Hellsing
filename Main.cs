using HellsingCore.API.QM;
using HellsingCore.ButtonApi;
using HellsingCore.ButtonAPI;
using HellsingPc.Exploits;
using HellsingPc.Misc;
using Il2CppSystem.Diagnostics;
using MelonLoader;
using System;
using System.Collections;
using UnityEngine;
using VRC.Core;
using VRC.SDKBase;
using static HellsingPc.Misc.Config;
using Color = UnityEngine.Color;
using Player = VRC.Player;
using VRC_Pickup = VRC.SDKBase.VRC_Pickup;
[assembly: MelonInfo(typeof(HellsingPc.Main), "Hellsing Client", "1.0.0", "Remi#0666")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonColor(ConsoleColor.DarkRed)]

namespace HellsingPc
{

    public class Main : MelonMod
    {
        // make antis, make spoofers

        public override void OnUpdate()
        {

            //Esp
            if (Utils.esp.ESP == true)
            {

                Utils.esp.espmethod();
            }
            //item orbit
            if (ItemOrbit1.ItemOrbitToggle)
            {
                ItemOrbit1.ItemOrbit(IUserExtension.SelectedVRCPlayer());
            }
            //forcepickups Laggy
            if (Force_Pickups == true)
            {
                new WaitForSeconds(20f);
                Exploits.ForcePickups.ForcePickup();
            }
            //fly
            HellsingPc.Exploits.Fly.fly();
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    HellsingPc.Exploits.Fly.togglefly(Config.Fly);
                }
            }
        }

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("=-------------------------------------------------------------------------------------=");
            MelonLogger.Msg("=---------------------------------=HellsingClient=------------------------------------=");
            MelonLogger.Msg("=----------------------------------=By Remi#0666=-------------------------------------=");
            MelonLogger.Msg("=-------------------------------------------------------------------------------------=");
            HellsingCore.ButtonAPI.Nameplates.LoadTags();
            MelonCoroutines.Start(WaitForUI());
            IEnumerator WaitForUI()
            {
                while (VRCUiManager.field_Private_Static_VRCUiManager_0 == null) yield return null;
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
            OnPreferencesLoaded();
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

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {

        }

        public override void OnPreferencesLoaded()
        {

        }

        public override void OnApplicationQuit()
        {

        }

        public static void MenuStart()
        {
            HellsingPc.Misc.LogHandler.Pass("Initializing Hellsing Menu...");
            HellsingPc.Misc.LogHandler.Pass("initializing TargetMenu!");

            #region TargetMenu
            //Target
            var TargetMenu = new QMNestedButton("Menu_SelectedUser_Local", 1.5f, -0.7f, "<color=#FF0000>Target</color>", "Target", "<color=#FF0000>Target</color>", true);
            var AmongUsTarget = new QMNestedButton(TargetMenu, 2, .5f, "<color=#FF0000>AmongUs</color>", "AmongUs", "<color=#FF0000>AmongUs</color>", true);
            var Murder4Target = new QMNestedButton(TargetMenu, 3, .5f, "<color=#FF0000>Murder4</color>", "Murder4", "<color=#FF0000>Murder4</color>", true);

            //worldHacks Target Buttons

            //AmongUs
            new QMSingleButton(AmongUsTarget, 1, 0, "<color=#FF0000>ResetCourpse</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusResetCourpse, "", true);
            new QMSingleButton(AmongUsTarget, 2, 0, "<color=#FF0000>ReportCourpse</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusReportCourpse, "", true);
            new QMSingleButton(AmongUsTarget, 3, 0, "<color=#FF0000>AssignM</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusAssignM, "", true);
            new QMSingleButton(AmongUsTarget, 4, 0, "<color=#FF0000>AssignB</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusAssignB, "", true);
            new QMSingleButton(AmongUsTarget, 2, .5f, "<color=#FF0000>Kill</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusKillTarget, "", true);
            new QMSingleButton(AmongUsTarget, 3, .5f, "<color=#FF0000>VoteOut</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusVoteOutTarget, "", true);


            //Murder4
            new QMSingleButton(Murder4Target, 1, 0, "<color=#FF0000>AssignB</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4AssignB, "", true);
            new QMSingleButton(Murder4Target, 2, 0, "<color=#FF0000>AssignM</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4AssignM, "", true);
            new QMSingleButton(Murder4Target, 3, 0, "<color=#FF0000>AssignD</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4AssignD, "", true);
            new QMSingleButton(Murder4Target, 4, 0, "<color=#FF0000>Clues</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4FinishClues, "", true);
            new QMSingleButton(Murder4Target, 1, .5f, "<color=#FF0000>Explode</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4ExplodeTarget, "", true);
            new QMSingleButton(Murder4Target, 2, .5f, "<color=#FF0000>Kill</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4TargetKill, "", true);
            new QMSingleButton(Murder4Target, 3, .5f, "<color=#FF0000>Flash</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4TargetFlash, "", true);
            new QMSingleButton(Murder4Target, 4, .5f, "<color=#FF0000>ExlpodeLoop</color>", () =>
            {
                if (!Murder4ExplodeLoop)
                {
                    Murder4ExplodeLoop = true;
                    MelonCoroutines.Start(Exploits.WorldHacks.Murder4.Murder4LoopExplodeTarget());
                }
                else
                if (Murder4ExplodeLoop)
                {
                    Murder4ExplodeLoop = false;


                }

            }, "", true);



            //Expoits Target Buttons

            //general 


            //pickups
            new QMSingleButton(TargetMenu, 1, 0, "<color=#FF0000>Orbit</color>", () =>
            {
                if (!ItemOrbit1.ItemOrbitToggle)
                {
                    HellsingPc.Misc.LogHandler.Alert("Pickup Orbiting [" + IUserExtension.SelectedVRCPlayer().field_Private_VRCPlayerApi_0.displayName + "]");
                    ItemOrbit1.ItemOrbitToggle = true;
                    ItemOrbit1.Recache();
                    return;
                }
                if (ItemOrbit1.ItemOrbitToggle)
                {
                    HellsingPc.Misc.LogHandler.Alert("Pickup Orbiting [" + IUserExtension.SelectedVRCPlayer().field_Private_VRCPlayerApi_0.displayName + "] Stopped");
                    ItemOrbit1.ItemOrbitToggle = false;
                    ItemOrbit1.Recache();
                }

            }, "", true);

            new QMSingleButton(TargetMenu, 2, 0, "<color=#FF0000>Bring</color>", () =>
            {
                foreach (VRC_Pickup VRCPickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                {
                    Networking.SetOwner(Networking.LocalPlayer, VRCPickup.gameObject);
                    VRCPickup.transform.position = IUserExtension.SelectedVRCPlayer().transform.position;
                }
            }, "", true);


            //BasePage Buttons
            new QMSingleButton(TargetMenu, 4, 0, "<color=#FF0000>TP</color>", () =>
            {
                VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.TeleportTo(IUserExtension.SelectedVRCPlayer().transform.position, IUserExtension.SelectedVRCPlayer().transform.rotation);
            }, "", true);

            new QMSingleButton(TargetMenu, 3, 0, "<color=#FF0000>CloneOn</color>", () =>
            {
                IUserExtension.SelectedVRCPlayer().field_Private_APIUser_0.allowAvatarCopying = true;
            }, "", true);

            #endregion

            HellsingPc.Misc.LogHandler.Pass("initialized TargetMenu!");

            #region MenuStuff

            //Tab
            
             tabMenu = new QMTabMenu("Open Hellsing menu", "<color=#FF0000>Hellsing Client</color>", HellsingResources.Resources.LoadSprite("HellsingTab.png"));

            //Exploits Menu
            var ExploitsMenu = new QMNestedButton(tabMenu, 1, 3, "<color=#FF0000>Exploits", "Exploits", "<color=#FF0000>Exploits</color>", true);
            //worldHacks Menu
            var WorldHacksMenu = new QMNestedButton(ExploitsMenu, 4, 3.5f, "<color=#FF0000>WorldHack</color>", "WorldHack", "<color=#FF0000>WorldHack</color>", true);
            var MurderHacksMenu = new QMNestedButton(WorldHacksMenu, 1, 0, "<color=#FF0000>Muder4</color>", "Muder4", "<color=#FF0000>Muder4</color>", true);
            var AmongUsHacksMenu = new QMNestedButton(WorldHacksMenu, 2, 0, "<color=#FF0000>AmongUs</color>", "AmongUs", "<color=#FF0000>AmongUs</color>", true);
            var PrisonHacksMenu = new QMNestedButton(WorldHacksMenu, 3, 0, "<color=#FF0000>Prison</color>", "Prison", "<color=#FF0000>Prison</color>", true);
            var JustBHacksMenu = new QMNestedButton(WorldHacksMenu, 4, 0, "<color=#FF0000>JustB</color>", "JustB", "<color=#FF0000>JustB</color>", true);
            //movements menu
            var MovementsMenu = new QMNestedButton(ExploitsMenu, 4, 3, "<color=#FF0000>Movement</color>", "Movement", "<color=#FF0000>Movement</color>", true);
            //visuals menu
            var VisualsMenu = new QMNestedButton(tabMenu, 1, 3.5f, "<color=#FF0000>Visuals</color>", "Visuals", "<color=#FF0000>Visuals</color>", true);
            //photon
            var PhotonMenu = new QMNestedButton(tabMenu, 2, 3, "<color=#FF0000>Photon</color>", "Photon", "<color=#FF0000>Photon</color>", true);

            //Protections Menu
            var ProtectionsMenu = new QMNestedButton(tabMenu, 2, 3.5f, "<color=#FF0000>Protection</color>", "Protection", "<color=#FF0000>Protection</color>", true);
            var SpoofersMenu = new QMNestedButton(ProtectionsMenu, 2, 0, "<color=#FF0000>Spoofers</color>", "Spoofers", "<color=#FF0000>Spoofers</color>", true);
            var AntisMenu = new QMNestedButton(ProtectionsMenu, 3, 0, "<color=#FF0000>Antis</color>", "Antis", "<color=#FF0000>Antis</color>", true);
  
            //Options Menu
            var OptionsMenu = new QMNestedButton(tabMenu, 3, 3, "<color=#FF0000>Options</color>", "Options", "<color=#FF0000>Options</color>", true);

            //Credits Menu
            var CreditsMenu = new QMNestedButton(tabMenu, 3, 3.5f, "<color=#FF0000>Credits</color>", "Credits", "<color=#FF0000>Credits</color>", true);

            #endregion

            HellsingPc.Misc.LogHandler.Pass("initialized Menus!");


            //exploits
            new QMSingleButton(ExploitsMenu, 2, 0, "<color=#FF0000>TPose</color>", () =>
            {
                if (Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled == true)
                    Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled = false;
                else if (Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled == false)
                {
                    Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled = true;
                }
            }
        , "", true);

            new QMSingleButton(ExploitsMenu, 2, .5f, "<color=#FF0000>SlowMo</color>", () =>
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = .25f;
                }
                else if (Time.timeScale != 1)
                {
                    Time.timeScale = 1;
                }

            }
          , "", true);


            new QMSingleButton(ExploitsMenu, 1, 0, "<color=#FF0000>Bring Pickups</color>", () =>
              {
                  foreach (VRC_Pickup VRCPickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                  {
                      Networking.LocalPlayer.TakeOwnership(VRCPickup.gameObject);
                      VRCPickup.transform.position = Player.prop_Player_0.transform.position;
                  }
              }, "", true);

            new QMSingleButton(ExploitsMenu, 1, 0.5f, "<color=#FF0000>Respawn pickups</color>", () =>
            {
                foreach (VRC_Pickup VRCPickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                {
                    Networking.LocalPlayer.TakeOwnership(VRCPickup.gameObject);
                    VRCPickup.transform.position = new Vector3(0, -9999, 0);
                }
            }, "", true);

            new QMSingleButton(ExploitsMenu, 1, 1, "<color=#FF0000>Yeet Pickups</color>", () =>
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


            new QMSingleButton(ExploitsMenu, 1, 1.5f, "<color=#FF0000>Force Pickups</color>", () =>
            {
                if (Force_Pickups)
                {
                    Force_Pickups = false;

                }
                else
                {
                    Force_Pickups = true;
                }
            }, "", true);




            HellsingPc.Misc.LogHandler.Pass("initialized Exploits!");


            //Murder

            new QMSingleButton(MurderHacksMenu, 1, 0, "<color=#FF0000>Start</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4Start, "", true);
            new QMSingleButton(MurderHacksMenu, 2, 0, "<color=#FF0000>Abor</color>t", HellsingPc.Exploits.WorldHacks.Murder4.Murder4Abort, "", true);
            new QMSingleButton(MurderHacksMenu, 3, 0, "<color=#FF0000>WinB</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4WinB, "", true);
            new QMSingleButton(MurderHacksMenu, 4, 0, "<color=#FF0000>WinM</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4WinM, "", true);
            new QMSingleButton(MurderHacksMenu, 1, .5f, "<color=#FF0000>TPKnife</color>", HellsingPc.Exploits.WorldHacks.Murder4.Knife, "", true);
            new QMSingleButton(MurderHacksMenu, 2, .5f, "<color=#FF0000>TpRevolver</color>", HellsingPc.Exploits.WorldHacks.Murder4.Revolver, "", true);
            new QMSingleButton(MurderHacksMenu, 3, .5f, "<color=#FF0000>TPLuger</color>", HellsingPc.Exploits.WorldHacks.Murder4.Luger, "", true);
            new QMSingleButton(MurderHacksMenu, 4, .5f, "<color=#FF0000>TPBeartrap</color>", HellsingPc.Exploits.WorldHacks.Murder4.Beartrap, "", true);
            new QMSingleButton(MurderHacksMenu, 1, 1, "<color=#FF0000>TP Bedroom</color>", HellsingPc.Exploits.WorldHacks.Murder4.TeleportToBedroom, "", true);
            new QMSingleButton(MurderHacksMenu, 3, 3.5f, "<color=#FF0000>Poison Wine</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4PosionWine, "", true);
            new QMSingleButton(MurderHacksMenu, 4, 3.5f, "<color=#FF0000>KillAll</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4KillAll, "", true);


            //AmongUs

            new QMSingleButton(AmongUsHacksMenu, 1, 0, "<color=#FF0000>BreakLight</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusBreakLights, "", true);
            new QMSingleButton(AmongUsHacksMenu, 2, 0, "<color=#FF0000>FixLight</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusFixLights, "", true);
            new QMSingleButton(AmongUsHacksMenu, 3, 0, "<color=#FF0000>BreakOxy</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusBreakOxygen, "", true);
            new QMSingleButton(AmongUsHacksMenu, 4, 0, "<color=#FF0000>FixOxygen</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusFixOxygen, "", true);
            new QMSingleButton(AmongUsHacksMenu, 1, .5f, "<color=#FF0000>BreakCom</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusBreakComms, "", true);
            new QMSingleButton(AmongUsHacksMenu, 2, .5f, "<color=#FF0000>FixComm</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusFixComms, "", true);
            new QMSingleButton(AmongUsHacksMenu, 3, .5f, "<color=#FF0000>BreakReact</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusBreakReactor, "", true);
            new QMSingleButton(AmongUsHacksMenu, 4, .5f, "<color=#FF0000>FixReactor</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusFixReactor, "", true);
            new QMSingleButton(AmongUsHacksMenu, 1, 1, "<color=#FF0000>SkipVote</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusSkipVote, "", true);
            new QMSingleButton(AmongUsHacksMenu, 2, 1, "<color=#FF0000>WinC</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusCWin, "", true);
            new QMSingleButton(AmongUsHacksMenu, 3, 1, "<color=#FF0000>WinI</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusIWin, "", true);
            new QMSingleButton(AmongUsHacksMenu, 4, 1, "<color=#FF0000>KillAll</color>", HellsingPc.Exploits.WorldHacks.Murder4.Murder4KillAll, "", true);
            new QMSingleButton(AmongUsHacksMenu, 2, 1.5f, "<color=#FF0000>Abort</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusAbort, "", true);
            new QMSingleButton(AmongUsHacksMenu, 3, 1.5f, "<color=#FF0000>Start</color>", HellsingPc.Exploits.WorldHacks.AmongUs.AmongSusStart, "", true);


            HellsingPc.Misc.LogHandler.Pass("initialized World Hacks!");


            new QMSingleButton(MovementsMenu, 1, .5f, "<color=#FF0000>DecreaseSpeed</color>", () =>
            {
                VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(Networking.LocalPlayer.GetWalkSpeed() / 2);
                VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(Networking.LocalPlayer.GetRunSpeed() / 2.5f);
                VRC.SDKBase.Networking.LocalPlayer.SetStrafeSpeed(Networking.LocalPlayer.GetRunSpeed() / 1.5f);
            }, "", true);

            new QMSingleButton(MovementsMenu, 1, 0, "<color=#FF0000>IncreaseSpeed</color>", () =>
            {
                VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(Networking.LocalPlayer.GetWalkSpeed() * 2);
                VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(Networking.LocalPlayer.GetRunSpeed() * 2.5f);
                VRC.SDKBase.Networking.LocalPlayer.SetStrafeSpeed(Networking.LocalPlayer.GetRunSpeed() * 1.5f);
            }, "", true);

            new QMSingleButton(MovementsMenu, 2, .5f, "<color=#FF0000>DecreaseJump</color>", () =>
            {
                VRC.SDKBase.Networking.LocalPlayer.SetJumpImpulse(Networking.LocalPlayer.GetJumpImpulse() / 2);
            }, "", true);

            new QMSingleButton(MovementsMenu, 2, 0, "<color=#FF0000>IncreaseJump</color>", () =>
            {
                VRC.SDKBase.Networking.LocalPlayer.SetJumpImpulse(Networking.LocalPlayer.GetJumpImpulse() * 2);
            }, "", true);
            new QMSingleButton(MovementsMenu, 3, 0, "<color=#FF0000>DefaultJump</color>", () =>
            {
                HellsingPc.Misc.LogHandler.Alert("DefaultJump");
                Networking.LocalPlayer.SetJumpImpulse(3);
            }, "", true);
            new QMSingleButton(MovementsMenu, 3, .5f, "<color=#FF0000>DefaultSpeed</color>", () =>
            {
                HellsingPc.Misc.LogHandler.Alert("DefaultSpeed");
                VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(4);
                VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(3);
                VRC.SDKBase.Networking.LocalPlayer.SetStrafeSpeed(3);
            }, "", true);
            new QMSingleButton(MovementsMenu, 4, 0, "<color=#FF0000>ForceJump</color>", () =>
            {
                Networking.LocalPlayer.SetJumpImpulse(3);
            }, "", true);

            new QMSingleButton(MovementsMenu, 4, .5f, "<color=#FF0000>Fly</color>", () =>
            {
                HellsingPc.Exploits.Fly.togglefly(Config.Fly);
            }, "", true);




            HellsingPc.Misc.LogHandler.Pass("initialized Movements Exloits!");

            new QMSingleButton(VisualsMenu, 1, 0, "<color=#FF0000>ESP</color>", () =>
            {
                Exploits.ESP.ToggleESP(toggleesp);
            }
            , "", true);

            new QMSingleButton(VisualsMenu, 2, 0, "<color=#FF0000>Light</color>", () =>
            {
                if (light == false)
                {
                    light = true;
                    HellsingPc.Misc.LogHandler.Alert("Light On");
                    UserInterface.transform.Find("MenuContent/Backdrop/Avatar").gameObject.SetActive(true);
                }
                else
                     if (light == true)
                {
                    light = false;
                    HellsingPc.Misc.LogHandler.Alert("Light Off");
                    UserInterface.transform.Find("MenuContent/Backdrop/Avatar").gameObject.SetActive(false);
                }
            }, "", true);
            HellsingPc.Misc.LogHandler.Pass("initialized Visuals Exploits!");


            //Photon
            new QMSingleButton(PhotonMenu, 2, 0, "<color=#FF0000>E1</color>", () =>
            {
                if (Earrape == false)
                {
                    HellsingPc.Misc.LogHandler.Alert("E1 On");
                    Earrape = true;
                    MelonCoroutines.Start(E1.EarrapeEvent());
                }
                else
                    if (Earrape == true)
                {
                    HellsingPc.Misc.LogHandler.Alert("E1 Off");
                    Earrape = false;
                    MelonCoroutines.Stop(E1.EarrapeEvent());

                }
            }
          , "", true);

            new QMSingleButton(PhotonMenu, 3, 0, "<color=#FF0000>E6</color>", () =>
            {
                if (E6Enabled == false)
                {
                    HellsingPc.Misc.LogHandler.Alert("E6 On");
                    E6Enabled = true;
                    MelonCoroutines.Start(E6.Event6Spam());
                }
                else
                    if (E6Enabled == true)
                {
                    HellsingPc.Misc.LogHandler.Alert("E6 Off");
                    E6Enabled = false;
                    MelonCoroutines.Stop(E6.Event6Spam());

                }
            }
         , "", true);
            HellsingPc.Misc.LogHandler.Pass("initialized Photon!");

            //Protections 

            HellsingPc.Misc.LogHandler.Pass("initialized Protections!");

            //Options


          


            new QMSingleButton(OptionsMenu, 1, 0, "<color=#FF0000>DebugOn</color>", () =>
            {
                HellsingCore.ButtonAPI.Debug.lable.SetActive(true);
                HellsingCore.ButtonAPI.Debug.background.SetActive(true);
                HellsingPc.Misc.LogHandler.Alert("DebugMenuOn");
            }
        , "", true);

            new QMSingleButton(OptionsMenu, 1, .5f, "<color=#FF0000>DebugOff</color>", () =>
            {
                HellsingCore.ButtonAPI.Debug.lable.SetActive(false);
                HellsingCore.ButtonAPI.Debug.background.SetActive(false);
                HellsingPc.Misc.LogHandler.Alert("DebugMenuOff");
            }
        , "", true);

            HellsingPc.Misc.LogHandler.Pass("initialized Options!");



            //credits
            new QMSingleButton(CreditsMenu, 1, 0, "<color=#FF0000>Discord</color>", () =>
            {
                Application.OpenURL("https://discord.gg/7r928aKyGz");
                MelonLogger.Msg("https://discord.gg/7r928aKyGz");
            }, "", false);

            new QMSingleButton(CreditsMenu, 2, 0, "<color=#FF0000>Remi</color>", () =>
            {
            }, "", true);

            new QMSingleButton(CreditsMenu, 2, .5f, "<color=#FF0000>IkariNoKami</color>", () =>
            {
            }, "Helped me with everything", true);


            HellsingPc.Misc.LogHandler.Pass("initialized Credits!");

            new QMSingleButton(tabMenu, 4, 3, "<color=#FF0000>Logout</color>", () =>
            {

                APIUser.Logout();
                HellsingPc.Misc.LogHandler.Alert("Logged Out of " + APIUser.CurrentUser.displayName);
            }
         , "", true);


            new QMSingleButton(tabMenu, 4, 3.5f, "<color=#FF0000>Quit</color>", () =>
            {
                Process.GetCurrentProcess().Kill();
            }, "", true);

            HellsingPc.Misc.LogHandler.Pass("initialized Menu!");
            ;
        }


        public void Hooks()
        {
            NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(OnPlayerJoin));
            NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_2.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(OnPlayerLeave));


        }

        public void OnPlayerJoin(Player player)
        {
            //Debug
            MelonLogger.Msg($"Player Join [{player.prop_APIUser_0.displayName}]");
            HellsingCore.ButtonAPI.Debug.Message($"<color=#FF0000>Player Join</color> <color=#FF00FF>[{player.prop_APIUser_0.displayName}]</color>");
            if (player.prop_VRCPlayerApi_0.isModerator)
            {
                MelonLogger.Msg($" Moderator Joined!!!");
                HellsingCore.ButtonAPI.Debug.Message($"<color=#FF0000>Moderator Joined!!!</color>");
            }
            NameplateStructure nameplate = new NameplateStructure();
            nameplate.component = Nameplates.AddTag(Color.black, player);
            nameplate.ID = player.field_Private_APIUser_0.id;
            Nameplates.userTags.Add(nameplate);
        }

        public void OnPlayerLeave(Player playr)
        {
            //DebugMenu
            MelonLogger.Msg($"Player Left [{playr.prop_APIUser_0.displayName}]");
            HellsingCore.ButtonAPI.Debug.Message($"<color=#FF0000>Player Left</color> <color=#FF00FF>[{playr.prop_APIUser_0.displayName}]</color>");
        }


    }
}
