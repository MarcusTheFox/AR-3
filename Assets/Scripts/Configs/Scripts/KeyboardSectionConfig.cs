using System.Collections.Generic;
using UnityEngine;

namespace Configs.Scripts
{
	[CreateAssetMenu(menuName = "Sections/KeyboardSectionConfig", fileName = "KeyboardSectionConfig")]
	public class KeyboardSectionConfig : ScriptableObject
	{
		public List<string> SymbolOrders;
	}
}
