using System.Collections.Generic;
using UnityEngine;

public class Mahjongtiles
{
    public List<pai_status> alltilesTypes; // Inspectorに37個のピースをドラッグして登録
    public int id;
    public Sprite image;
    public Mahjongtiles(pai_status type)
    {
        id = type.id;
        image = type.image;
    }
}
