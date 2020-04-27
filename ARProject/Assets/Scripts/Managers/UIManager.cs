using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button toggleUIButton;

    [SerializeField]
    private RectTransform background;

    public void ToggleUI()
    {
        //toggling the background
        background.gameObject.SetActive(!background.gameObject.activeSelf);

        // get text
        var textMeshProButtonText = toggleUIButton.gameObject.GetComponentInChildren<TextMeshProUGUI>();

        // changing the
        textMeshProButtonText.text = toggleUIButton.gameObject.activeSelf ? "SHOW UI" : "HIDE UI";
    }

}
