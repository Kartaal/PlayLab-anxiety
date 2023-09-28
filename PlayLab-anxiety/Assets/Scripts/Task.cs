using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField] private Toggle taskToggle;
    [SerializeField] private TextMeshProUGUI taskText;

    public void ToggleStrikeThrough()
    {
        if (taskToggle.isOn)
        {
            if (taskText.fontStyle != FontStyles.Strikethrough)
            {
                taskText.fontStyle = FontStyles.Strikethrough;
            }
        }
        else
        {
            taskText.fontStyle = FontStyles.Normal;
        }
    }
}
