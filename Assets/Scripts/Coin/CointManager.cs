using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointManager : ObjectManager
{
    protected override void Update()
    {
        base.Update();
        //����� ������� ����� ��������
        /*Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));
        */
    }
}
