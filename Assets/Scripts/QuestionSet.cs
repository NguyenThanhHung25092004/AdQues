using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionSet", menuName = "Scriptable Objects/QuestionSet")]
public class QuestionSet : ScriptableObject
{
    public List<QuestionDataBase> questions;
}
