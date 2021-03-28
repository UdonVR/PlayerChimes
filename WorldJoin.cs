using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonVR.Childofthebeast
{
    public class WorldJoin : UdonSharpBehaviour
    {
        public AudioSource Bell;
        public AudioClip Join;
        public AudioClip Leave;
        private bool JoinEnable = true;
        private bool LeaveEnable = true;
        private int _numPlayers;
        private int _numJoins;


        private void Start()
        {
            _numPlayers = VRCPlayerApi.GetPlayerCount();
        }
        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            _numJoins = _numJoins + 1;
            if (Join != null && JoinEnable && _numJoins > _numPlayers)
            {
                Bell.clip = Join;
                Bell.Play();
            }
        }
        public override void OnPlayerLeft(VRCPlayerApi player)
        {
            if (Leave != null && LeaveEnable)
            {
                Bell.clip = Leave;
                Bell.Play();
            }
        }

        public void JoinToggle()
        {
            JoinEnable = !JoinEnable;
        }
        public void LeaveToggle()
        {
            LeaveEnable = !LeaveEnable;
        }
    }
}