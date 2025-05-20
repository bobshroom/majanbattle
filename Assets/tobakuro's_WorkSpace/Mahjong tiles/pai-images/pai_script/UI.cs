using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MountainDisplay : MonoBehaviour
{
    // 山場に並べるパネル（Grid Layout Groupなど）
    public Transform mountainPanel;

    // プレイヤーの手札表示用パネル（UI上に用意）
    public Transform playerHandPanel;

    // 表示用のピースUIプレハブ（1枚分）
    public GameObject MahjongtilesUIPrefab;

    // プレイヤーの手札データ
    public List<Mahjongtiles> playerHand = new List<Mahjongtiles>();

    // 現在の山場のピースデータ
    private List<Mahjongtiles> currentMountain = new List<Mahjongtiles>();

    /// <summary>
    /// 山場の牌をUIに表示
    /// </summary>
    public void DisplayMountain(List<Mahjongtiles> mountainDeck)
    {
        currentMountain = mountainDeck;

        // 既存UIを削除
        foreach (Transform child in mountainPanel)
        {
            Destroy(child.gameObject);
        }

        // UIを生成
        foreach (Mahjongtiles tile in mountainDeck)
        {
            GameObject obj = Instantiate(MahjongtilesUIPrefab, mountainPanel);

            // ランダムな位置に配置（重なりOK）
            RectTransform rt = obj.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(

                //()内は画面サイズに応じて調整
                //()内は画面サイズに応じて調整
                Random.Range(-100f, 100f),
                Random.Range(-100f, 100f)
            );

            MahjongtilesUI tileUI = obj.GetComponent<MahjongtilesUI>();
            if (tileUI != null)
            {
                tileUI.Initialize(tile, this); // ← this を渡す
            }
        }
    }

    /// <summary>
    /// 麻雀牌をクリックした時に呼ばれる
    /// </summary>
    public void OntileClicked(MahjongtilesUI tileUI)
    {
        Mahjongtiles clickedTile = tileUI.tileData;

        // 手札に追加
        playerHand.Add(clickedTile);

        // 山場から削除
        currentMountain.Remove(clickedTile);

        // 山場UIから削除
        Destroy(tileUI.gameObject);

        // 手札UIに追加
        GameObject newObj = Instantiate(MahjongtilesUIPrefab, playerHandPanel);
        Image img = newObj.GetComponent<Image>();
        if (img != null)
        {
            img.sprite = clickedTile.image;
        }
    }
}
