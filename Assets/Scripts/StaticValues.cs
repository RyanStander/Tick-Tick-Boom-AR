using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticValues : MonoBehaviour
{
    static private List<int> shardPresetNumbers = new List<int>();
    static private List<int> cloudPresetNumbers = new List<int>();
    static private List<int> crownPresetNumbers = new List<int>();
    static private List<int> tubePresetNumbers = new List<int>();

    public static void SetPresetNumbers(List<int> shardNumbers, List<int> cloudNumbers, List<int> crownNumbers, List<int> tubeNumbers)
    {
        shardPresetNumbers = shardNumbers;
        cloudPresetNumbers = cloudNumbers;
        crownPresetNumbers = crownNumbers;
        tubePresetNumbers = tubeNumbers;
    }

    public static List<int> GetShardPresetNumbers()
    {
        return shardPresetNumbers;
    }
    public static List<int> GetCloudPresetNumbers()
    {
        return cloudPresetNumbers;
    }
    public static List<int> GetCrownPresetNumbers()
    {
        return crownPresetNumbers;
    }
    public static List<int> GetTubePresetNumbers()
    {
        return tubePresetNumbers;
    }
}
