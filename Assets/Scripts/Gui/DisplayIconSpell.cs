using UnityEngine;
using System.Collections.Generic;

public class DisplayIconSpell : MonoBehaviour
{
	public Vector2 Position;
	public Vector2 Size;
	public Character Character;
	public Vector2 IconSize;
	public List<IconSpell> IconSpells = new List<IconSpell>();

	public void Awake()
	{
		Character = this.gameObject.GetComponent<Character>();
		Character.OnAuraAdded += AddAura;
		Character.OnAuraRemoved += RemoveAura;
	}

	public void Update()
	{
	}

	public void AddAura(SpellPrefab spellPrefab)
	{
		Object prefab = Resources.Load("Prefabs/Spells/IconSpell");
		if (prefab != null)
		{
			GameObject iconSpellObj = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
			IconSpell iconSpell = iconSpellObj.GetComponent<IconSpell>();
			iconSpell.SetSpellPrefab(spellPrefab);
			iconSpell.SetIconSize(IconSize);
			IconSpells.Add(iconSpell);
			Debug.Log(spellPrefab.Name + " added to display icon");
		}
	}

	public void RemoveAura(SpellPrefab spellPrefab)
	{
		//TODO : remove instance of IconSpell GameObject

		IconSpells.RemoveAll(p => p.SpellPrefab == spellPrefab);

		Debug.Log(spellPrefab.Name + " removed from display icon");
	}
}