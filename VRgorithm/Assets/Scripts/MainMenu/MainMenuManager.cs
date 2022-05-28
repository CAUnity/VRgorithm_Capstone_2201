using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private SelectPanel selectPanel; 
    [SerializeField] private TMP_InputField idField; 
    public void Awake()
    {
        selectPanel.gameObject.SetActive(false);
        idField.text = ProblemData.studentId;
        idField.onValueChanged.AddListener(onIDChanged);
    }
    
    public void onStartClick()
    {
        selectPanel.gameObject.SetActive(true);   
    }
    
    public void onExitClick()
    {
        Application.Quit();
    }
    
    public void onIDChanged(string id)
    {
        ProblemData.studentId = id;
        Debug.Log("studentID = "+ProblemData.studentId);
    }
}
