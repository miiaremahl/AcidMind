using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitScript : MonoBehaviour
{
	//how big area is counted for hit
	public float hitRadius=0.5f;

	//have we hit ground
	private bool hitGround = false;

	//how many second till we can interact w ground again
	public float SecondsTillNextHit = 2;

	//the particle systems to spawn
	public GameObject trailsVFX;
	public GameObject particlesVFX;

	//how many can we spawn / how many have been spawned
	public int maxSystemCount = 10;
	private int particleSystemCount = 0;
	public float vfxLifetime = 3f;


	void Start()
	{
		particleSystemCount = 0;
	}

	public void Update()
	{
        if (!hitGround)
        {
			RaycastHit hit;
			if (Physics.SphereCast(transform.position, hitRadius, transform.TransformDirection(Vector3.down), out hit, 0.5f))
			{
                if (hit.transform.tag.Equals("Floor"))
                {
					hitGround = true;
					StartCoroutine(WaitTillNextHit());
					if (particleSystemCount < maxSystemCount)
					{
						particleSystemCount++;
						//spawn particle system too spot the hit
						GameObject particles = Instantiate(trailsVFX, hit.point, Quaternion.Euler(-90, 0, 0));
						GameObject vfx = Instantiate(particlesVFX, hit.point, Quaternion.identity);

						//destroy the vfx effects after a certain time
						Destroy(vfx, vfxLifetime);
						Destroy(particles, vfxLifetime);

						StartCoroutine(ParticleDissapearTimer());
					}

				}
			}
		}
	}

	IEnumerator WaitTillNextHit()
	{
		yield return new WaitForSeconds(SecondsTillNextHit);
		hitGround = false;
	}

	private IEnumerator ParticleDissapearTimer()
	{
		yield return new WaitForSeconds(vfxLifetime);
		particleSystemCount--;
	}
}
