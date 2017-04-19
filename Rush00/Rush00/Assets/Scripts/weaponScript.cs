using UnityEngine;
using System.Collections;

public class weaponScript: MonoBehaviour {

	public int				ammo;
	public Sprite			droppedSprite;
	public Sprite			equipedSprite;
	
	public float			fireRate;
	public GameObject		bullet;

	public AudioClip		shootSound;
	public AudioClip		grabSound;

	private float 			timer;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}
	
	public void equip(){
		player.p.weaponSprite.sprite = equipedSprite;
		player.p.weapon = gameObject;
		GetComponent<SpriteRenderer> ().sprite = null;
		transform.position = player.p.gameObject.transform.position;
		transform.parent = player.p.gameObject.transform;
		soundManager.sm.playSound(GetComponent<AudioSource>(), grabSound);
	}

	public void drop(){
		GetComponent<SpriteRenderer> ().sprite = droppedSprite;
		throwWeapon(player.p.dir);
		player.p.weapon = null;
		player.p.weaponSprite.sprite = null;
		transform.parent = null;
	}

	private void throwWeapon(Vector3 dir)
	{
		transform.Translate (dir * 0.5f, Space.World);
	}

	public void shoot(Vector3 dir, string layerName){
		GameObject tmp;

		if (timer < fireRate)
			return;
		timer = 0;
		if (ammo != 0) {
			ammo--;
			tmp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
			tmp.GetComponent<bulletScript>().init(transform.position, dir, layerName);
			soundManager.sm.playSound(GetComponent<AudioSource>(), shootSound);
			return;
		}
	}
}
