﻿using UnityEngine;

namespace FYFY {
	public class GameObjectStateMatcher : Matcher {
		public enum STATE { ACTIVE, INACTIVE };

		private readonly STATE _state;

		public GameObjectStateMatcher(STATE state) {
			_state = state;
			_descriptor = "StateMatcher:" + state;
		}

		internal override bool matches(GameObjectWrapper gameObjectWrapper){
			if(gameObjectWrapper == null || gameObjectWrapper._gameObject == null)
				throw new System.ArgumentNullException();

			return (_state == STATE.ACTIVE) == (gameObjectWrapper._gameObject.activeInHierarchy == true);
		}
	}
}