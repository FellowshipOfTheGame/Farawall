using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {
	public Toggle fullScreen;
	public Dropdown resolution;
	public Dropdown textureQuality;
	public Slider volume;

	public Resolution[] resolutions;


	void OnEnable(){

		fullScreen.onValueChanged.AddListener (delegate { OnFullScreenToggle();});
		resolution.onValueChanged.AddListener (delegate { OnResolutionChange();});
		textureQuality.onValueChanged.AddListener (delegate { OnTextureQualityChange();});
		volume.onValueChanged.AddListener (delegate {OnVolumeChange();});

		resolutions = Screen.resolutions;
	}

	public void OnFullScreenToggle(){
		Screen.fullScreen = fullScreen.isOn;
	}

	public void OnTextureQualityChange(){
		QualitySettings.masterTextureLimit = textureQuality.value;
	}

	public void OnResolutionChange(){

	}

	public void OnVolumeChange(){

	}
}
