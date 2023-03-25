using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonColorBase : MonoBehaviour
{
    public Color color;

    [Header("References")]
    public Image uiImage;

    public Player myPlayer;

    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    private void Start()
    {
        uiImage.color = color;
    }

    public void OnClick()
    {
        myPlayer.ChangeColor(color);
    }
}
