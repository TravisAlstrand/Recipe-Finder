using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		public bool locked;
		public Transform Player;
		private readonly float _maxInteractDistance = 5f;
		
		void Start()
		{
			open = false;
		}

		void OnMouseOver()
		{
			if (Player)
			{
				if (!locked)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist <= _maxInteractDistance)
					{
						if (open == false)
						{
							if (Input.GetMouseButtonDown(0))
							{
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetMouseButtonDown(0))
								{
									StartCoroutine(closing());
								}
							}

						}

					}
				}
				else
				{
					// display locked text
				}
			}
		}

		IEnumerator opening()
		{
			// print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			// print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}