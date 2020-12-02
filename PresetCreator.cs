using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetCreator : MonoBehaviour
{
    [SerializeField] private List<int> ShardPresetNumbers = new List<int>();
    [SerializeField] private List<int> CloudPresetNumbers = new List<int>();
    [SerializeField] private List<int> CrownPresetNumbers = new List<int>();
    [SerializeField] private List<int> TubePresetNumbers = new List<int>();

    public void AddValues()
    {
        StaticValues.SetPresetNumbers(ShardPresetNumbers, CloudPresetNumbers, CrownPresetNumbers, TubePresetNumbers);
    }
}
