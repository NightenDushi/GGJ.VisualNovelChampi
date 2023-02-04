using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnInstance : MonoBehaviour
{
    [SerializeField] VariableStorageBehaviour _variable;
    public static VariableStorageBehaviour Variable;
    
    [SerializeField] DialogueRunner _dial;
    public static DialogueRunner Dial;


    private void Awake()
    {
        Variable = _variable;
        Dial = _dial;
    }

    //public bool TryGetValue<T>(string variableName, out T result);
    //public void SetValue(string variableName, string stringValue);
    //public void SetValue(string variableName, float floatValue);
    //public void SetValue(string variableName, bool boolValue);
    //public void Clear();
    //public bool Contains(string variableName);


}
