using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
	[SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
	[SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
	bool hasPackage;
	int score = 0;
	SpriteRenderer spriteRenderer;

 void Start()
 {
  	spriteRenderer = GetComponent<SpriteRenderer>();
 }

 void OnTriggerEnter2D(Collider2D other) 
 {
		if(other.tag == "Package" && !hasPackage)
		{
			hasPackage = true;
			spriteRenderer.color = hasPackageColor;
			Destroy(other.gameObject);
		}
		else if(other.tag == "Customer" && hasPackage)
		{
			hasPackage = false;
			score += 1;
			Debug.Log("Score:" + score);
			spriteRenderer.color = noPackageColor;
		}
 }
}
