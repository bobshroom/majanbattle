using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MountainDisplay : MonoBehaviour
{
    // �R��ɕ��ׂ�p�l���iGrid Layout Group�Ȃǁj
    public Transform mountainPanel;

    // �v���C���[�̎�D�\���p�p�l���iUI��ɗp�Ӂj
    public Transform playerHandPanel;

    // �\���p�̃s�[�XUI�v���n�u�i1�����j
    public GameObject MahjongtilesUIPrefab;

    // �v���C���[�̎�D�f�[�^
    public List<Mahjongtiles> playerHand = new List<Mahjongtiles>();

    // ���݂̎R��̃s�[�X�f�[�^
    private List<Mahjongtiles> currentMountain = new List<Mahjongtiles>();

    /// <summary>
    /// �R��̔v��UI�ɕ\��
    /// </summary>
    public void DisplayMountain(List<Mahjongtiles> mountainDeck)
    {
        currentMountain = mountainDeck;

        // ����UI���폜
        foreach (Transform child in mountainPanel)
        {
            Destroy(child.gameObject);
        }

        // UI�𐶐�
        foreach (Mahjongtiles tile in mountainDeck)
        {
            GameObject obj = Instantiate(MahjongtilesUIPrefab, mountainPanel);

            // �����_���Ȉʒu�ɔz�u�i�d�Ȃ�OK�j
            RectTransform rt = obj.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(

                //()���͉�ʃT�C�Y�ɉ����Ē���
                //()���͉�ʃT�C�Y�ɉ����Ē���
                Random.Range(-100f, 100f),
                Random.Range(-100f, 100f)
            );

            MahjongtilesUI tileUI = obj.GetComponent<MahjongtilesUI>();
            if (tileUI != null)
            {
                tileUI.Initialize(tile, this); // �� this ��n��
            }
        }
    }

    /// <summary>
    /// �����v���N���b�N�������ɌĂ΂��
    /// </summary>
    public void OntileClicked(MahjongtilesUI tileUI)
    {
        Mahjongtiles clickedTile = tileUI.tileData;

        // ��D�ɒǉ�
        playerHand.Add(clickedTile);

        // �R�ꂩ��폜
        currentMountain.Remove(clickedTile);

        // �R��UI����폜
        Destroy(tileUI.gameObject);

        // ��DUI�ɒǉ�
        GameObject newObj = Instantiate(MahjongtilesUIPrefab, playerHandPanel);
        Image img = newObj.GetComponent<Image>();
        if (img != null)
        {
            img.sprite = clickedTile.image;
        }
    }
}
