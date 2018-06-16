using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour {

    //移動方向のルール決め
    [System.Serializable]
    public class MoveInfo
    {
        [SerializeField] public KeyCode key;
        [SerializeField] public Vector2 force;
    }
    public MoveInfo[] moveInfo;

    //キー入力の方向に対しての移動Vectorを取得する
    public Vector2 GetMove(KeyCode key)
    {
        for (int i = 0; i < moveInfo.Length; i++)
        {
            //Settingに登録があればVector2を返す
            if (moveInfo[i].key == key) return moveInfo[i].force;
        }
        return Vector2.zero;
    }
}
