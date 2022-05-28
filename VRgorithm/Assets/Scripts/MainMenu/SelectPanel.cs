using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : MonoBehaviour
{
    private List<Problem> problems;
    [SerializeField] private GameObject entityPrefab;
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject scrollContent;
    private List<ProbEntity> entities = new List<ProbEntity>();
    private bool isReci = false;
    
    void OnEnable()
    {
        setLoading(true);
        foreach (Transform child in scrollContent.transform)
        {
            Destroy(child.gameObject);
        }
        RequestManager.ReqProbs(onProbsReci);
    }

    private void Update()
    {
        if (isReci)
        {
            foreach (Problem prob in problems)
            {
                GameObject entity = Instantiate(entityPrefab, transform);
                entity.GetComponent<ProbEntity>().SetEntity(prob, this);
                entity.transform.SetParent(scrollContent.transform);
            }
            setLoading(false);
            isReci = false;
        }
    }

    public void onProbsReci(string data)
    {
        ProblemRes res = JsonUtility.FromJson<ProblemRes>(data);
        problems = res.data;
        isReci = true;
    }
    
    public void setLoading(bool isActive)
    {
        loading.SetActive(isActive);
    }

    public void onCloseClick()
    {
        gameObject.SetActive(false);
    }
}
