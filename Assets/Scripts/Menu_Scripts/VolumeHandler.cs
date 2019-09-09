using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace PeppaSquad.Menu_Scripts
{
    public class VolumeHandler : MonoBehaviour
    {
        //An audio mixer to split the sound in the game under Music and Sfx
        [SerializeField] private AudioMixer musicMixer;
        //A slider for the Sfx and the Music
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider SfxSlider;
        //A toggle to completely mute the master volume
        [SerializeField] private Toggle muteToggle;

        //The strings should be the same as the public parameters in the Audio mixer
        private const string musicVol = "MusicVol";
        private const string sfxVol = "SfxVol";
        private const string masterVol = "MasterVol";

        /// <summary>
        /// Set previous value onto the sliders
        /// <summary>

        private void Start()
        {
            float masterValue;
            bool result = musicMixer.GetFloat("MasterVol", out masterValue);

            if (result)
                muteToggle.isOn = false;

        }
        /// <summary>
        /// Updates the music volume when the player changes its value on a slider.
        /// </summary>

        public void SetLevelMusic()
        {

            musicMixer.SetFloat(musicVol, Mathf.Log10(musicSlider.value) * 20);
        }

        /// <summary>
        /// Updates the sfx volume when the player changes its value on a slider
        /// </summary>
        public void SetLevelSFX()
        {

            musicMixer.SetFloat(sfxVol, Mathf.Log10(SfxSlider.value) * 20);
        }
        public void ToggleMute()
        {
            if (muteToggle.isOn)
            {
                musicMixer.SetFloat(masterVol, Mathf.Log10(0.0001f) * 20);
            }
            else
            {
                musicMixer.ClearFloat(masterVol);
            }
        }

    }
}