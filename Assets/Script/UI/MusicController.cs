using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Slider slider; // Reference to the UI slider
    public AudioSource audioSource; // Reference to the audio source

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the slider to detect changes in its value
        slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });

        // Initialize the audio source volume to the slider value
        audioSource.volume = slider.value / 100.0f;
    }

    // Update the audio source volume when the slider value changes
    void OnSliderValueChanged()
    {
        audioSource.volume = slider.value / 100.0f;
    }
}
