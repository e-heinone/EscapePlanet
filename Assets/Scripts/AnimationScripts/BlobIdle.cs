using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class BlobIdle : MonoBehaviour
{
    [Header ("Default size is 1,1,1")]
    [SerializeField]
    private Vector3 maxIdleSize;
    [SerializeField]
    private Vector3 minIdleSize;
    [SerializeField]
    [Tooltip("Size Change Per Frame")]
    private Vector3 sizeChangeSpeed;


    bool scalingUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localScale.z > minIdleSize.z && !scalingUp)
        {
           
            StartCoroutine(BlobShrink());
        }

        else if (gameObject.transform.localScale.z < maxIdleSize.z && scalingUp)
        {
            StartCoroutine(BlobGrowth());
        }
    }
    IEnumerator BlobShrink()
    {
        while (gameObject.transform.localScale.z > minIdleSize.z)
        {
            gameObject.transform.localScale = gameObject.transform.localScale - sizeChangeSpeed;
            yield return null;
        }
        scalingUp = true;
    }

    IEnumerator BlobGrowth()
    {
        while (gameObject.transform.localScale.z < maxIdleSize.z)
        {
            gameObject.transform.localScale = gameObject.transform.localScale + sizeChangeSpeed;
            yield return null;
        }
        scalingUp = false;
    }

  
}
