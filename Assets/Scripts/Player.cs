using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //地面の判定に使うレイヤー
    public LayerMask groundLayer;

    //3Dモデル
    public GameObject model;

    //キー操作をチェックする
    void Update()
    {
        PlayerSetting setting = gameObject.GetComponent<PlayerSetting>();

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Move(setting.GetMove(KeyCode.UpArrow));
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Move(setting.GetMove(KeyCode.DownArrow));
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Move(setting.GetMove(KeyCode.LeftArrow));
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Move(setting.GetMove(KeyCode.RightArrow));
        }
    }

    //可能なら移動する
    void Move(Vector2 force)
    {
        if (HasNextStep(force))
        {
            transform.Translate(force.x, 0, force.y);
        }

        //移動できなくても回転はする
        Rotate(force);
    }

    //モデルを回転させる
    void Rotate(Vector2 force)
    {
        model.transform.rotation = Quaternion.LookRotation(new Vector3(force.x, 0, force.y));
    }

    //移動先に地面があるかどうかチェック
    bool HasNextStep(Vector2 force)
    {
        RaycastHit hit;

        // Rayを飛ばして移動先の地面の有無を調べる
        Ray ray = new Ray(transform.position + new Vector3(force.x, 0, force.y), Vector3.down);
        if (Physics.Raycast(ray, out hit, 10.0f, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
