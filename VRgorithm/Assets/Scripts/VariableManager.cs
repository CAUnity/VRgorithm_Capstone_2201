using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : MonoBehaviour {
    public List<IVariable> variables;
    public Stack<List<IntVariable>> changed_variables;

    public void Start(){
        variables = new List<IVariable>();
    }

    public void start_save(){
        changed_variables= new Stack<List<IntVariable>>();
    }

    public void check_change(){
        List<IntVariable> changed_list = new List<IntVariable>();
        for(int i=0; i<variables.Capacity; i++){
            if(variables[i] is IntVariable) {
                if(((IntVariable)variables[i]).stack.Peek() != ((IntVariable)variables[i]).Value){
                    ((IntVariable)variables[i]).stack.Push(((IntVariable)variables[i]).Value);
                    changed_list.Add((IntVariable)variables[i]);
                }
            }
            else {
                for(int j=0;j<((ArrayVariable)variables[i]).Size;j++){
                    if(((ArrayVariable)variables[i])[j].stack.Peek() != ((ArrayVariable)variables[i])[j].Value){
                        ((ArrayVariable)variables[i])[j].stack.Push(((ArrayVariable)variables[i])[j].Value);
                        changed_list.Add(((ArrayVariable)variables[i])[j]);
                    }
                } 
            }
        }
        changed_variables.Push(changed_list);
    }

    public void undo_variables(){
        List<IntVariable> undo_list = changed_variables.Pop();

        for (int i=0;i<undo_list.Capacity;i++) {
            undo_list[i].undo();
        }
    }
}
