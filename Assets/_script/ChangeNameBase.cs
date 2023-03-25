using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChangeNameBase : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI uiTextName;
    public TMP_InputField uiInputField;
    public GameObject changeNameInput;
    public Player player;

    private string playerName;

    public void ChangeName()
    {
        playerName = uiInputField.text;
        uiTextName.text = playerName;
        changeNameInput.SetActive(false);
        player.SetName(playerName);
    }
}
