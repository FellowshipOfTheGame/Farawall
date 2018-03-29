using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {
	public static GameObject music = null;
	public Toggle fullScreen;
	public Dropdown resolutionOption;
	public Dropdown textureQuality;
	public Slider volume;
	public Toggle mute;

	public Resolution[] resolutions;
	public AudioSource musicSource;

	void Start(){
		fullScreen.onValueChanged.AddListener (delegate { OnFullScreenToggle();});
		resolutionOption.onValueChanged.AddListener (delegate { OnResolutionChange();});
		textureQuality.onValueChanged.AddListener (delegate { OnTextureQualityChange();});
		volume.onValueChanged.AddListener (delegate {OnVolumeChange();});
		mute.onValueChanged.AddListener (delegate {Mute();});

		resolutions = Screen.resolutions;
		foreach (Resolution resolution in resolutions) {
			resolutionOption.options.Add (new Dropdown.OptionData(resolution.ToString()));
		}
		if (music == null) {
			music = musicSource.gameObject;
			DontDestroyOnLoad (music);
		} else {
			Destroy (musicSource.gameObject);
			musicSource = music.GetComponent<AudioSource> ();
		}
		fullScreen.isOn = Screen.fullScreen;
		textureQuality.value = QualitySettings.masterTextureLimit;
		volume.value = musicSource.volume;
		mute.isOn = musicSource.mute;
	}

	public void OnFullScreenToggle(){
		Screen.fullScreen = fullScreen.isOn;
	}

	public void OnTextureQualityChange(){
		QualitySettings.masterTextureLimit = textureQuality.value;
	}

	public void OnResolutionChange(){
		Screen.SetResolution (resolutions[resolutionOption.value].width, resolutions[resolutionOption.value].height, Screen.fullScreen);
	}

	public void OnVolumeChange(){
		musicSource.volume = volume.value;
	}

	public void Mute(){
		musicSource.mute = mute.isOn;
	}
}
