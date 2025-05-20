using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MahjongtilesUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Mahjongtiles tileData;                  // ����UI���\������s�[�X�̏��
    private MountainDisplay mountainDisplay;       // �Ăяo�����̊Ǘ��N���X

    private RectTransform rectTransform;           // UI�̈ʒu�𐧌䂷��
    private Canvas canvas;                         // UI�̃X�P�[�����O�����p
    private CanvasGroup canvasGroup;               // �h���b�O���̓����蔻���؂邽��

    /// <summary>
    /// �������i�O����Ă΂��j
    /// </summary>
    public void Initialize(Mahjongtiles tile, MountainDisplay display)
    {
        tileData = tile;
        mountainDisplay = display;

        // �\���摜��ݒ�
        Image image = GetComponent<Image>();
        if (image != null && tile.image != null)
        {
            image.sprite = tile.image;
        }

        // �K�v�ȎQ�Ƃ��擾
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    /// <summary>
    /// �s�[�X���N���b�N���ꂽ�Ƃ��iButton��OnClick�C�x���g�ȂǂŌĂԁj
    /// </summary>
    public void OnClick()
    {
        if (mountainDisplay != null)
        {
            mountainDisplay.OntileClicked(this);
        }
    }

    /// <summary>
    /// �h���b�O�J�n
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false; // �h���b�O���͑���UI�ɔ����ł���悤�ɂ���
    }

    /// <summary>
    /// �h���b�O��
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        if (canvas != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    /// <summary>
    /// �h���b�O�I��
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // �����蔻���߂�
    }
}
