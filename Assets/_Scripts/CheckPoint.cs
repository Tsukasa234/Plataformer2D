using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<Respawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
            _anim.SetTrigger("FlagStart");
        }
    }

    public void FlagUp()
    {
        _anim.SetTrigger("FlagUp");
    }
}
