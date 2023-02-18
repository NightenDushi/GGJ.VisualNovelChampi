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

    [YarnCommand("SetVariable")]
    public static void SetYarnVariable()
    {
        Variable.SetValue("$name", CharacterSprite.Name);

        string gender_pronoun = "nb";
        switch (CharacterSprite.Pronoun)
        {
            case Pronoun.IL:
                gender_pronoun = "m";
                break;
            case Pronoun.ELLE:
                gender_pronoun = "f";
                break;
        }
        Variable.SetValue("$gender", gender_pronoun);
    }

    //public bool TryGetValue<T>(string variableName, out T result);
    //public void SetValue(string variableName, string stringValue);
    //public void SetValue(string variableName, float floatValue);
    //public void SetValue(string variableName, bool boolValue);
    //public void Clear();
    //public bool Contains(string variableName);


}
