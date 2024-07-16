using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    //color
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    //这个是unity自己的method
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("You collision the object!");//tell the unity user the object indeed collision something
    }

    void OnTriggerEnter2D(Collider2D other) {
        // if (the thing we trigger is the package) then print "package picked"
        if (other.tag == "Package" && !hasPackage){
            Debug.Log("Package Picked");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);// Destroy the object after the car touch it
        }
        else if (other.tag == "Customer" && hasPackage){
            Debug.Log("Delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
