using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNiveau1 : MonoBehaviour
{
    public GameObject TarteAuCitron;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CRainingPie());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator CRainingPie()
    {
        while (true)
        {
            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;
            yield return new WaitForSeconds(Random.Range(0f, 3.0f));
            Instantiate(TarteAuCitron, new Vector2(Random.Range(width * -1 / 2, width/2), this.transform.position.y), Quaternion.identity);
        }
    }
}
