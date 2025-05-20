using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public List<pai_status> alltilesTypes; // ScriptableObjectとして登録済み

    public MountainDisplay mountainDisplay;

    public List<Mahjongtiles> mountainDeck; // 生成される麻雀牌の山

    void Start()
    {
        GenerateMountainDeck();
        mountainDisplay.DisplayMountain(mountainDeck);
    }

    void GenerateMountainDeck()
    {
        mountainDeck = new List<Mahjongtiles>();

        foreach (var type in alltilesTypes)
        {
            for (int i = 0; i < 4; i++)
            {
                mountainDeck.Add(new Mahjongtiles(type));
            }
        }

        // シャッフルや初期配布などここで続けて行える
    }
}
