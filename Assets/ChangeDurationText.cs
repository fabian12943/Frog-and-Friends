using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeDurationText : MonoBehaviour
{
    Slider slider;
    [SerializeField]
    TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.transform.parent.gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value % 2 == 0)
        {
            textMesh.text = "0" + ((int)(slider.value/2)).ToString() + ":00 min";
        }
        else 
        {
            textMesh.text = "0" + ((int)(slider.value/2)).ToString() + ":30 min";
        }
    }
}
