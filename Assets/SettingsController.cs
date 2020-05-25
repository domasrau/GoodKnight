using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SettingsController : MonoBehaviour
{
    public AudioSource audio;
    public PostProcessVolume postProcessing;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("MusicToggle", 0) == 1)
        {
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
        if (PlayerPrefs.GetInt("ColorToggle", 1) == 1)
        {
            ColorGrading colorGrading;
            postProcessing.profile.TryGetSettings(out colorGrading);
            colorGrading.active = true;
        }
        else
        {
            ColorGrading colorGrading;
            postProcessing.profile.TryGetSettings(out colorGrading);
            colorGrading.active = false;
        }
        if (PlayerPrefs.GetInt("NewGame") == 1)
        {
            PlayerPrefs.SetInt("NewGame", 0);
            PlayerPrefs.DeleteAll();
        }
    }
}
