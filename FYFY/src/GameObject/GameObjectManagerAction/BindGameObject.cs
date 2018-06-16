﻿using UnityEngine;
using System.Collections.Generic;

namespace FYFY {
	internal class BindGameObject : IGameObjectManagerAction {
		private readonly GameObject _gameObject;
		private readonly string _name;
		private readonly HashSet<uint> _componentTypeIds;
		private readonly string _exceptionStackTrace;

		internal BindGameObject(GameObject gameObject, string exceptionStackTrace) {
			_gameObject = gameObject;
			_name = _gameObject.name;
			_componentTypeIds = new HashSet<uint>();

			foreach(Component c in gameObject.GetComponents<Component>()) {
				System.Type type = c.GetType();
				uint typeId = TypeManager.getTypeId(type);
				_componentTypeIds.Add(typeId);
			}

			_exceptionStackTrace = exceptionStackTrace;
		}
		
		GameObject IGameObjectManagerAction.getTarget(){
			return _gameObject;
		}

		void IGameObjectManagerAction.perform(){ // before this call GO is like a ghost for FYFY (not known by families but present into the scene)
			if(_gameObject == null) { // The GO has been destroyed !!!
				throw new DestroyedGameObjectException("You try to bind a GameObject that will be destroyed during this frame. In a same frame, your must not destroy a GameObject and ask Fyfy to perform an action on it.", _exceptionStackTrace);
			}

			int gameObjectId = _gameObject.GetInstanceID();
			if (!GameObjectManager._gameObjectWrappers.ContainsKey(gameObjectId)){
				GameObjectWrapper gameObjectWrapper = new GameObjectWrapper(_gameObject, _componentTypeIds);
				GameObjectManager._gameObjectWrappers.Add(gameObjectId, gameObjectWrapper);
				GameObjectManager._modifiedGameObjectIds.Add(gameObjectId);
			} else
				throw new FyfyException("A game object can be binded to Fyfy only once. The game object \""+_gameObject.name+"\" is already binded.", _exceptionStackTrace);
		}
	}
}