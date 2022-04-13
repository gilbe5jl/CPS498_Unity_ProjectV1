/*@author Jalen Gilbert
 * Main Menu Controller Script 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added this namespace, useed for accessing UI components 
using UnityEngine.SceneManagement; //added this namespace, used for loading scenes
using TMPro; //added this namespace for using tmp

public class MainMenuController : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null; //TMP text mesh pro
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;
    [Header("Confirmation")]
    [SerializeField] private GameObject comfirmationPrompt = null;

    [Header("Gameplay setting")]
    [SerializeField] private TMP_Text controllerSenTextValue = null;
    [SerializeField] private Slider controllerSenSilder = null;
    [SerializeField] private int defaultSen = 4;
    public int mainControllerSen = 4;

    [Header("Toggle Settings")]
    [SerializeField] private Toggle invertYToggle = null;

    [Header("Graphics Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;
    [SerializeField] private float defalutBrightness = 1;

    [Space(10)]
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullscreenToggle;


    private int _qualityLevel;
    private bool _isFullscreen;
    private float _brightnessLevel;

    [Header("Levels To Load")]
    public string _newGameLevel; //level that is going to be loaded
    private string levelToLoad; //will load the level when needed
    [SerializeField] private GameObject noSavedGameDialog = null; //get noSavedGame Dialog

    [Header("Resolution Dropdown")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        /*Get all the resolution that are currently available 
         * create a list of options 
         * search through lenght of the array
         * put into string the width and the height 
         * check is resolutions found is equal to user screen width or height 
         * Then set to current resolution from options 
         */
        //find all needed resolutions 
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();//clear values in current dropdown list 
        List<string> options = new List<string>();//create new list for names of options 
        int currentResolutionIndex = 0; //index of resolution from list 
        //search through length of array for amount of resolutions
        for (int i = 0; i < resolutions.Length; i++)
        {
            //width string x height string
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);//add local variable to array list 

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {//check if resolutions found are equal to screen width & height and set to current resolution 
                currentResolutionIndex = i; 
            }
        }

        resolutionDropdown.AddOptions(options);//add options to display 
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];//local var for resolution equal to found resolutions, specified resolutionIndex from the parameter
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //method for when the 'yes' button is slected in the New Game Dialog Panel
    public void NewGameDialogYes()
    {
        //when clicking 'yes' button load requested scene
        SceneManager.LoadScene(_newGameLevel);
    }//end NewGameDialogYes

    //method for selecting the 'yes' button in the Load Game Dialog Panel 
    public void LoadGameDialogYes()
    {
        //load game button, PlayerPrefs used to save data, check if PlayerPrefs has file that would be saved 
        if (PlayerPrefs.HasKey("SavedLevel"))//check if file SavedLevel exists 
        {
            //checking that when 'yes' button is selected a game is loaded 
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad); //specifiy the level to load 
        }
        else
        {
            //if no saved game is available to load - click new game 
            noSavedGameDialog.SetActive(true);

        }
    }//end LoadGameDialogYes method 

    //method for the 'exit' button in the main menu 
    public void ExitButton()
    {
        Application.Quit();

    }

    //Method for controlling how volume settings works.
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    //Method for applying volume in audio settings dialog panel 
    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //show prompt 
        StartCoroutine(ConfirmationBox());
    }

    public void DefaultButton(string MenuType)
    {
        if(MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }

        if(MenuType == "Gameplay")
        {
            controllerSenTextValue.text = defaultSen.ToString("0");
            controllerSenSilder.value = defaultSen;
            mainControllerSen = defaultSen;
            invertYToggle.isOn = false;
            GameplayApply();
        }

        if(MenuType == "Graphics")
        {
            //reset brightness value
            brightnessSlider.value = defalutBrightness;
            brightnessTextValue.text = defalutBrightness.ToString("0.0");
            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);

            fullscreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply();
        }
    }

    public void SetControllerSen(float sensitivity)
    {
        mainControllerSen = Mathf.RoundToInt(sensitivity);//needs to be converted to int to work
        controllerSenTextValue.text = sensitivity.ToString("0"); //set controller sensitivity value 
    }

    public void GameplayApply()
    {
        if (invertYToggle.isOn)//ture
        {
            PlayerPrefs.SetInt("masterInvertY", 1); //invert y
        }
        else //false
        {
            PlayerPrefs.SetInt("masterInvertY", 0);//non invert y
        }

        PlayerPrefs.SetFloat("masterSen",mainControllerSen);
        StartCoroutine(ConfirmationBox());
    }

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        brightnessTextValue.text = brightness.ToString("0.0");

    }

    public void SetFullscreen(bool fullscreen)
    {
        _isFullscreen = fullscreen;

    }

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);
        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);
        PlayerPrefs.SetInt("masterFullscreen", (_isFullscreen ? 1 : 0));
        Screen.fullScreen = _isFullscreen;
        StartCoroutine(ConfirmationBox());
    }
    public IEnumerator ConfirmationBox()
    {
        comfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        comfirmationPrompt.SetActive(false);
       
    }

}//end class
