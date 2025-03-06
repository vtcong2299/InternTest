using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundTrap : MonoBehaviour
{
    [SerializeField] Vector3 oldPos;
    [SerializeField] Vector3 newPos;
    [SerializeField] float time = 0.3f;
    void Start()
    {
        oldPos = transform.position;
    }
    private void Update()
    {
        if (!PlayerCtrl.Instance.isReset) return;        
        transform.position = oldPos;
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
        transform.DOLocalMove(newPos, time)
            .SetEase(Ease.Linear);
    }    
}
