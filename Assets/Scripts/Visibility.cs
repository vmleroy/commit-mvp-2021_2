using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    private Renderer ren;
    
    public bool isVisible = false;
    
    // Start is called before the first frame update
    void Start() {
        ren = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void Update() {
        if (ren.isVisible) {
            isVisible = true;
        }
        if (isVisible && !ren.isVisible) {
            Destroy(gameObject, 1f);
        }
    }


}
