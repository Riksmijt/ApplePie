using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    private bool isShooting;
    private float timer;
    private int amountArrows;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        arrow.SetActive(false);
        timer = 0;
        amountArrows = 2;
    }
    IEnumerator ArrowShooting()
    {
        isShooting = true;
        arrow.SetActive(true);
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
            arrow.transform.Translate(Vector3.back * 30 * Time.deltaTime);
            arrow.transform.parent = null;
        }
        if(amountArrows <= 0)
        {
            timer += 1 * Time.deltaTime;
            if(timer >= 3)
            {
                timer = 0;
                amountArrows = 2;
            }
        }
        
        else if(!isShooting)
        {
            arrow.transform.parent = transform;
        }
        Debug.Log(timer);
    }
    public void OnArrowShoot()
    {
        if (amountArrows >= 2)
        {
            isShooting = true;
            amountArrows -= 1;
        }
    }
}
