using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    
    public GameObject arrow;
    public bool isShooting;
    public Transform barrel;
    [SerializeField] private int arrowSpeed;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        arrow.SetActive(false);
    }
    IEnumerator ArrowShooting()
    {
        isShooting = true;
        GameObject newArrow = Instantiate(arrow,barrel.position,barrel.rotation);
        newArrow.GetComponent<Rigidbody>().AddForce(newArrow.transform.forward * arrowSpeed);
        Destroy(newArrow, 1.5f);
        yield return new WaitForSeconds(1.5f);
        isShooting = false;
        //arrow.transform.position = transform.localPosition + new Vector3(-0.3f,0,0);
    }
    // Update is called once per frame
    void Update()
    {
       /* if (isShooting)
        {
            arrow.transform.Translate(new Vector3(3,transform.rotation.y,0) * Time.deltaTime);
            arrow.transform.parent = null;
        }
        else if(!isShooting)
        {
            arrow.transform.parent = transform;
        }*/
    }
    public void OnArrowShoot()
    {
        if (!isShooting)
        {
            StartCoroutine(ArrowShooting());
        }
    }
}
