using System.Collections.Generic;
using UnityEngine;

public class Mahjongtiles
{
    public List<pai_status> alltilesTypes; // Inspector��37�̃s�[�X���h���b�O���ēo�^
    public int id;
    public Sprite image;
    public Mahjongtiles(pai_status type)
    {
        id = type.id;
        image = type.image;
    }
}
