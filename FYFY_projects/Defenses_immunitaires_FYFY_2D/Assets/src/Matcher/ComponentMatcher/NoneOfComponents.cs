﻿namespace FYFY {
	public class NoneOfComponents : ComponentMatcher {
		public NoneOfComponents(params System.Type[] componentTypes) : base(componentTypes) {
		}

		internal override bool matches(GameObjectWrapper gameObjectWrapper){
			for (int i = 0; i < _componentTypeIds.Length; ++i)
				if(gameObjectWrapper._componentTypeIds.Contains(_componentTypeIds[i]) == true)
					return false;
			return true;
		}
	}
}