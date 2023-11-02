using System;
using UnityEngine;

namespace Configs.Scripts
{
	[CreateAssetMenu(fileName = "ButtonSectionConfig", menuName = "Sections/ButtonSectionConfig", order = 0)]
	public class ButtonSectionConfig : ScriptableObject
	{
		public Color[] Colors;
		public string[] Texts;
	}
}