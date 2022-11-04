using MelonLoader;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using Il2CppSystem;

[assembly: MelonInfo(typeof(BarjiKart.CheckpointView.CheckpointView), "BarjiKart.CheckpointView","1.0.0","o7Moon")]
namespace BarjiKart.CheckpointView {
    [HarmonyPatch]
    public class CheckpointView : MelonMod
    {
        [HarmonyPatch(typeof(Barji.Tracks.TrackManager),nameof(Barji.Tracks.TrackManager.Update))]
        [HarmonyPostfix]
        public static void onTrackUpdate(Barji.Tracks.TrackManager __instance){
            if (!(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.C))) return;
            foreach (Barji.Tracks.Checkpoint c in __instance.checkpoints){
                var m = c.GetComponent<MeshRenderer>();
                m.enabled = true;
            }
        }
    }
}