using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundTrap : MonoBehaviour
{
    [SerializeField] float oldPosY;
    [SerializeField] float newPosY;
    void Start()
    {
        oldPosY = transform.position.y;
    }
    private void Update()
    {
        if (!PlayerCtrl.Instance.isReset) return;
        Vector3 pos = transform.position;   
        pos.y = oldPosY;
        transform.position = pos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            TrapMove();
        }
    }
    void TrapMove()
    {
        transform.DOLocalMoveY(newPosY, 0.5f)
            .SetEase(Ease.Linear);
    }    
}
