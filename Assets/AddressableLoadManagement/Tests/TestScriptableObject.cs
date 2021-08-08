/// Created by: Kirk George
/// Copyright: Kirk George
/// Website: https://github.com/foozlemoozle?tab=repositories
/// See upload date for date created.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "TestSO", menuName = "KEG Addressables/Create TestSO", order = 1 )]
public class TestScriptableObject : ScriptableObject
{
    public string test = "Hello!";
}
