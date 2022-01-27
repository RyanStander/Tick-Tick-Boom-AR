using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScript : MonoBehaviour
{
   [SerializeField] private  GameObject target=null;
    // Start is called before the first frame update
    void Start()
    {
        target.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
