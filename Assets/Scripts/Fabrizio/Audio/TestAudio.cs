using UnityEngine;

namespace Fabrizio.Audio
{
    public class TestAudio : MonoBehaviour
    {
        public AudioController audioController;

        #region Unity Functions

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.T))
                audioController.PlayAudio(AudioKind.Ost01);
            if (Input.GetKeyUp(KeyCode.G))
                audioController.StopAudio(AudioKind.Ost01);
            if (Input.GetKeyUp(KeyCode.B))
                audioController.RestartAudio(AudioKind.Ost01);

            if (Input.GetKeyUp(KeyCode.R))
                audioController.PlayAudio(AudioKind.Sfx01);
            if (Input.GetKeyUp(KeyCode.F))
                audioController.StopAudio(AudioKind.Sfx01);
            if (Input.GetKeyUp(KeyCode.V))
                audioController.RestartAudio(AudioKind.Sfx01);
        }
#endif

        #endregion
    }
}