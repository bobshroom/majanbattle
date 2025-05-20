using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MahjongtilesUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Mahjongtiles tileData;                  // このUIが表示するピースの情報
    private MountainDisplay mountainDisplay;       // 呼び出し元の管理クラス

    private RectTransform rectTransform;           // UIの位置を制御する
    private Canvas canvas;                         // UIのスケーリング調整用
    private CanvasGroup canvasGroup;               // ドラッグ中の当たり判定を切るため

    /// <summary>
    /// 初期化（外から呼ばれる）
    /// </summary>
    public void Initialize(Mahjongtiles tile, MountainDisplay display)
    {
        tileData = tile;
        mountainDisplay = display;

        // 表示画像を設定
        Image image = GetComponent<Image>();
        if (image != null && tile.image != null)
        {
            image.sprite = tile.image;
        }

        // 必要な参照を取得
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    /// <summary>
    /// ピースがクリックされたとき（ButtonのOnClickイベントなどで呼ぶ）
    /// </summary>
    public void OnClick()
    {
        if (mountainDisplay != null)
        {
            mountainDisplay.OntileClicked(this);
        }
    }

    /// <summary>
    /// ドラッグ開始
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false; // ドラッグ中は他のUIに反応できるようにする
    }

    /// <summary>
    /// ドラッグ中
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        if (canvas != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    /// <summary>
    /// ドラッグ終了
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // 当たり判定を戻す
    }
}
