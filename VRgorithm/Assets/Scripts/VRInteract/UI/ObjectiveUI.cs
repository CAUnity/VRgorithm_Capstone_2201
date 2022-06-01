using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro titleUI;
    [SerializeField] private TextMeshPro descriptionUI;

    public void SetObjective(string title,string description)
    {
        titleUI.text = title;
        descriptionUI.text = description;
    }
}
