using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TruthOrDareData", menuName = "ScriptableObjects/TruthOrDareSO")]
public class TruthOrDareSO : CardSO
{
    public string structuredText;
    public float factor1,factor2;
    public int x1, x2, y1, y2;
}
