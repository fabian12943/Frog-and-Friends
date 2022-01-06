using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DurationManager : MonoBehaviour
{
    [SerializeField] Slider durationSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("matchDuration"))
        {
            PlayerPrefs.SetInt("matchDuration", 4);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeDuration()
    {
        Save();
    }

    private void Load()
    {
        durationSlider.value = PlayerPrefs.GetInt("matchDuration");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("matchDuration", (int)durationSlider.value);
    }
}
