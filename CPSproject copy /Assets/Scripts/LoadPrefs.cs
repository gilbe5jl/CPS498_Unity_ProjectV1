/*@author Jalen Gilbert 
 * Script to loading player preferences 
 *
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added this namespace, useed for accessing UI components 
using TMPro; //added this namespace for using text mesh pro


public class LoadPrefs : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private MainMenuController mainMenuController;

    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null; //TMP text mesh pro
    [SerializeField] private Slider volumeSlider = null;

    [Header("Brightness Setting")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;

    [Header("Quality Level Setting")]
    [SerializeField] private TMP_Dropdown qualityDropdown;

    [Header("Fullscreen Setting")]
    [SerializeField] private Toggle fullscreenToggle;

    [Header("Sensitivity Setting")]
    [SerializeField] private TMP_Text controllerSenTextValue = null;
    [SerializeField] private Slider controllerSenSilder = null;

    [Header("Invert Y Setting")]
    [SerializeField] private Toggle invertYToggle = null;

private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");
                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                mainMenuController.DefaultButton("Audio");
            }
            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);

            }

            if (PlayerPrefs.HasKey("masterFullscreen"))
            {
                int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");
                if(localFullscreen == 1)
                {
                    Screen.fullScreen = true;
                        fullscreenToggle.isOn = true;

                }
                else
                {
                    Screen.fullScreen = false;
                    fullscreenToggle.isOn = false;
                }
                if (PlayerPrefs.HasKey("masterBrightness"))
                {
                    float localBright = PlayerPrefs.GetFloat("masterBrightness");
                    brightnessTextValue.text = localBright.ToString("0.0");
                    brightnessSlider.value = localBright;
                    //change the brightness 
                }
                if (PlayerPrefs.HasKey("masterSen"))
                {
                    float localSen = PlayerPrefs.GetFloat("masterSen");
                    controllerSenTextValue.text = localSen.ToString("0.0");
                    controllerSenSilder.value = localSen;
                    mainMenuController.mainControllerSen = Mathf.RoundToInt(localSen);
                }

                if (PlayerPrefs.HasKey("masterInvertY"))
                {
                    if(PlayerPrefs.GetInt("masterInvertY") == 1)
                    {
                        invertYToggle.isOn = true;
                    }
                    else
                    {
                        invertYToggle.isOn = false;

                    }
                }
            }
        }
    }
}//end class
