using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeTextMeshProText : MonoBehaviour
{
    Slider slider;
    [SerializeField]
    TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.transform.parent.gameObject.GetComponent<Slider>();
        textMesh.text = ((int)(slider.value * 100)).ToString() + " %";
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = ((int)(slider.value * 100)).ToString() + " %";
    }
}
