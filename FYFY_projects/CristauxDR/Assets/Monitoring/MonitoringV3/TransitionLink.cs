﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace monitoring{
	/// <summary>
	/// 	Links on transition
	/// </summary>
	[Serializable]
	public class TransitionLink {
		public List<Link> links;
		public Node transition;
		public bool isSystemAction = false;
		public bool isEndAction = false;
		public string logic;

		public TransitionLink(){
			links = new List<Link>();
		}

		public Link addLink(Node transition, string label, int type, int placeId, GameObject obj, int weight)
        {
            this.transition = transition;
			Link ctr = new Link(label, type, placeId, obj, weight);
            links.Add(ctr);
            return ctr;
        }

        public Link getLabeledLink(string label){
			foreach(Link link in links){
				if (link.label.Equals (label))
					return link;
			}
			return null;
		}
	}
}