using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
    
public class VolumeHandler : MonoBehaviour
{
[SerializeField] private AudioMixer musicMixer;
[SerializeField] private Slider musicSlider;
[SerializeField] private Slider SfxSlider;
[SerializeField] private Toggle muteToggle;
private const string musicVol = "MusicVol";
private const string sfxVol = "SfxVol";
private const string masterVol = "MasterVol";

/// <summary>
/// Set previous value onto the sliders
/// <summary>

private void Start(){
    float masterValue;
    bool result =  musicMixer.GetFloat("MasterVol", out masterValue);

    if(result)
     muteToggle.isOn = false;

}
/// <summary>
/// Updates the music volume when the player changes its value on a slider.
/// </summary>

public void SetLevelMusic(){
    
    musicMixer.SetFloat(musicVol, Mathf.Log10(musicSlider.value)*20);
}

/// <summary>
/// Updates the sfx volume when the player changes its value on a slider
/// </summary>
public void SetLevelSFX(){
    
    musicMixer.SetFloat(sfxVol, Mathf.Log10(SfxSlider.value)*20);
}
public void ToggleMute(){
    if(muteToggle.isOn)
    {
    musicMixer.SetFloat(masterVol,  Mathf.Log10(0.0001f)*20);
    }
    else
    {
    musicMixer.ClearFloat(masterVol);
    }
}


}