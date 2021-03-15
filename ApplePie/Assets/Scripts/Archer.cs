using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject arrow;
    public bool isShooting;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        arrow.SetActive(false);
    }
    IEnumerator ArrowShooting()
    {
        isShooting = true;
        yield return new WaitForSeconds(2);
        isShooting = false;

        //arrow.transform.position = transform.localPosition + new Vector3(-0.3f,0,0);

        arrow.SetActive(false);
        arrow.transform.position = transform.localPosition;

    }
    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            arrow.transform.Translate(Vector3.forward * 3 * Time.deltaTime);
            arrow.transform.parent = null;
        }
        else if(!isShooting)
        {
            arrow.transform.parent = transform;
        }
    }
    public void OnArrowShoot()
    {
        StartCoroutine(ArrowShooting());
    }
}
