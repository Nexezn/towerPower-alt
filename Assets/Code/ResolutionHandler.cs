using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionHandler : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        Debug.Log("RefreshRate: " + currentRefreshRate);

        for (int i = 0; i < resolutions.Length; i++){
            Debug.Log("Resolutions:" + resolutions[i]);
            if (resolutions[i].refreshRate == currentRefreshRate){
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();

        for (int i = 0; i < filteredResolutions.Count; i++){
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resolutionOption);

            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height){
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);

        // Store the selected resolution in PlayerPrefs
        PlayerPrefs.SetInt("ScreenWidth", resolution.width);
        PlayerPrefs.SetInt("ScreenHeight", resolution.height);
        PlayerPrefs.SetInt("RefreshRate", resolution.refreshRate);
        PlayerPrefs.Save();

        Debug.Log("RESOLUTION IS: " + resolution.width + "X " + resolution.height + " AT " + resolution.refreshRate);
    }

    public void Awake()
    {
        int screenWidth = PlayerPrefs.GetInt("ScreenWidth", Screen.currentResolution.width);
        int screenHeight = PlayerPrefs.GetInt("ScreenHeight", Screen.currentResolution.height);
        int refreshRate = PlayerPrefs.GetInt("RefreshRate", Screen.currentResolution.refreshRate);

        Screen.SetResolution(screenWidth, screenHeight, true, refreshRate);
        Debug.Log("RESOLUTION IS: " + screenWidth + "X " + screenHeight + " AT " + refreshRate);
    }
}
