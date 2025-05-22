using UnityEngine;

[CreateAssetMenu(fileName = "pai_status", menuName = "Scriptable Objects/pai_status")]
public class pai_status : ScriptableObject
{
    public int id;            // 麻雀牌の種類を区別するためのID
                              //数牌の場合　  十の位の1はマンズ、2はピンズ、3はソウズ、一の位は1～9の牌の数字に対応
                              //字牌の場合　  十の位は全て4　一の位の1は東、2は南、3は西、4は北、5は白、6は發、7は中
                              //赤ドラの識別　十の位は全て5　一の位の1はマンズ、2はピンズ、3はソウズ

    public Sprite image;      // 麻雀牌の画像
}
