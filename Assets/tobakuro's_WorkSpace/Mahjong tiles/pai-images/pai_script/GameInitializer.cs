using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public List<pai_status> alltilesTypes; // ScriptableObject�Ƃ��ēo�^�ς�

    public MountainDisplay mountainDisplay;

    public List<Mahjongtiles> mountainDeck; // ��������閃���v�̎R

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

        // �V���b�t���⏉���z�z�Ȃǂ����ő����čs����
    }
}
