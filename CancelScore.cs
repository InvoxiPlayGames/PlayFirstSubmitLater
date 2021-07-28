﻿using TMPro;
using System.Linq;
using UnityEngine;
using IPA.Utilities;
using System.Collections;
using BeatSaberMarkupLanguage;
using HarmonyLib;
using System.Reflection;


namespace PlayFirst
{
    public class CancelScore : MonoBehaviour
    {
        public static float pausetime = 0.1f;
        public static bool paused_yet = false;

        public static AudioTimeSyncController audiocontroller;
        public static SongController songcontroller;
        //public static IAudioTimeSource songAudio;

        /*public void OnActiveSceneChanged(UnityEngine.SceneManagement.Scene prevScene, UnityEngine.SceneManagement.Scene nextScene)
        {
            Logger.log.Debug("ACTIVE SCENE CHANGED");
            songcontroller = Resources.FindObjectsOfTypeAll<SongController>().LastOrDefault();

            if (songcontroller != null)
                Logger.log.Debug("SongController Found" + songcontroller.ToString());

        }*/


        /*[Inject]
        public void Construct(IVRPlatformHelper vrPlatformHelper, BeatmapObjectCallbackController callbackController, AudioTimeSyncController audioTimeSyncController, VRControllersInputManager vrControllersInputManager)
        {
            _vrPlatformHelper = vrPlatformHelper;
            _callbackController = callbackController;
            _audioTimeSyncController = audioTimeSyncController;
            _vrControllersInputManager = vrControllersInputManager;
        }*/

        /*public void OnStart()
        {
            Logger.log.Debug("In CancelScore Start!");

            //audiocontroller = GameObject.FindObjectOfType<AudioTimeSyncController>();
            //Logger.log.Debug(audiocontroller.songEndTime.ToString());
            //Logger.log.Debug(audiocontroller.songLength.ToString());
            //Logger.log.Debug(audiocontroller.songTime.ToString());

            //Plugin.harmony.PatchAll(Assembly.GetExecutingAssembly());

            //Logger.log.Debug(songendtime.ToString());
            //Logger.log.Debug(songlength.ToString());
            //Logger.log.Debug(songcurrenttime.ToString());

            //CreatePrompt();
            //_songAudio = _audioTimeSyncController.GetField<AudioSource, AudioTimeSyncController>("_audioSource");
            //_songAudio = _audioTimeSyncController.GetField<IAudioTimeSource, AudioTimeSyncController>("songEndTime");
            //_audioTimeSyncController = audioTimeSyncController;
            //endtime = _songAudio.songEndTime;

            Logger.log.Debug("End CancelScore Start!");
        }*/

        public void Update()
        {
            //Logger.log.Debug("In Update!");

            if (audiocontroller != null && songcontroller != null)
            {
                Logger.log.Debug("Current:" + audiocontroller.songTime.ToString());

                if (Config.UserConfig.mod_enabled)
                {
                    if (audiocontroller.songTime >= pausetime && !paused_yet)
                    {
                        Logger.log.Debug("#####################");
                        songcontroller.PauseSong();
                        Logger.log.Debug("Song Paused");
                        paused_yet = true;
                        
                        //songAudio = audiocontroller.GetField<IAudioTimeSource, AudioTimeSyncController>("_audioSource");
                        //Logger.log.Debug(songAudio.songTime.ToString());

                    }

                    else if (audiocontroller.songTime >= pausetime + 0.2f)
                    {
                        Logger.log.Debug("#############################################################");
                    }
                }
            }
        }
    }
}