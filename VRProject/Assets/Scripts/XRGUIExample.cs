using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XRGUIExample : MonoBehaviour
{   
    [SerializeField]
    private RawImage background;

    [SerializeField]
    private Button lightButton;

    [SerializeField]
    private Button cloudsButton;

    [SerializeField]
    private GameObject clouds;
    
    [SerializeField]
    private Slider fontSlider;

    [SerializeField]
    private TextMeshProUGUI fontText;

    [SerializeField]
    private Button creditsButton;

    [SerializeField]
    private ScrollRect creditsInfo;

    [SerializeField]
    private TextMeshProUGUI creditsInfoDetails;

    [SerializeField]
    private Material skyMaterial;

    [SerializeField]
    private Toggle alphaToggle;
    
    void Start()
    {
        creditsButton.onClick.AddListener(() => 
        {
            creditsInfo.gameObject.SetActive(!creditsInfo.gameObject.activeSelf);

            creditsButton.GetComponentInChildren<TextMeshProUGUI>().text = creditsInfo.gameObject.activeSelf ? 
                "CREDITS ON" : "CREDITS OFF";
        });

        cloudsButton.onClick.AddListener(() => 
        {
            clouds.gameObject.SetActive(!clouds.gameObject.activeSelf);

            cloudsButton.GetComponentInChildren<TextMeshProUGUI>().text = clouds.gameObject.activeSelf ? 
                "CLOUDS ON" : "CLOUDS OFF";
        });

        lightButton.onClick.AddListener(() => 
        {
            if(skyMaterial.GetFloat("_Exposure") > 0)
            {
                skyMaterial.SetFloat("_Exposure", 0);
                lightButton.GetComponentInChildren<TextMeshProUGUI>().text = "NIGHT TIME";
            }
            else
            {    
                skyMaterial.SetFloat("_Exposure", 1.3f);
                lightButton.GetComponentInChildren<TextMeshProUGUI>().text = "DAY TIME";
            }
        });

        alphaToggle.onValueChanged.AddListener((value) => 
        {
            Color currColor = background.color;
            currColor.a = value ? 0.7f : 0;
            background.color = currColor;
        });

        fontSlider.onValueChanged.AddListener((value) => 
        {
            creditsInfoDetails.fontSize = value;
            fontText.text = $"FONT SIZE: {value}";
        });
    }
}
