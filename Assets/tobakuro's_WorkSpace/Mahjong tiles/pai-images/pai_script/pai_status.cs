using UnityEngine;

[CreateAssetMenu(fileName = "pai_status", menuName = "Scriptable Objects/pai_status")]
public class pai_status : ScriptableObject
{
    public int id;            // �����v�̎�ނ���ʂ��邽�߂�ID
                              //���v�̏ꍇ�@  �\�̈ʂ�1�̓}���Y�A2�̓s���Y�A3�̓\�E�Y�A��̈ʂ�1�`9�̔v�̐����ɑΉ�
                              //���v�̏ꍇ�@  �\�̈ʂ͑S��4�@��̈ʂ�1�͓��A2�͓�A3�͐��A4�͖k�A5�͔��A6��ᢁA7�͒�
                              //�ԃh���̎��ʁ@�\�̈ʂ͑S��5�@��̈ʂ�1�̓}���Y�A2�̓s���Y�A3�̓\�E�Y

    public Sprite image;      // �����v�̉摜
}
