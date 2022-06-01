using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProbEntity : MonoBehaviour
{
    private Problem problem;
    private SelectPanel parent;
    [SerializeField] private TextMeshProUGUI id;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI description;

    public void SetEntity(Problem prob, SelectPanel parent)
    {
        problem = prob;
        this.parent = parent;
        id.text = problem.id.ToString();
        name.text = problem.name;
        description.text = problem.description;
    }

    public void onClick()
    {
        parent.setLoading(true);
        ProblemData.decription = problem.description;
        ProblemData.problemId = problem.id;
        ProblemData.name = problem.name;
        ProblemData.inputs = new ArrayList(problem.input.Split(' '));
        ProblemData.outputs = new ArrayList(problem.output.Split(' '));
        SceneManager.LoadScene("Stage");
    }
}
