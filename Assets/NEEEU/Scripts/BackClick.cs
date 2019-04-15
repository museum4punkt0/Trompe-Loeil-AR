/*

Copyright © 2018 NEEEU Spaces GmbH

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NEEEU.MarkerAR
{

    public class BackClick : MonoBehaviour
    {
        public GameObject removePrefab;
        //public GameObject bubbles;

        void Update()
        {
            foreach (Touch tch in InputHelper.GetTouches())
            {
                int id = tch.fingerId;

                if (tch.phase != TouchPhase.Began) continue;
                Ray ray = Camera.main.ScreenPointToRay(tch.position);
                RaycastHit hit;
                if (!Physics.Raycast(ray, out hit, 100.0F)) continue;

                if (hit.transform.gameObject == gameObject)
                {
                    removePrefab.SetActive(false);
                }

                ////DragTransform drg = hit.transform.gameObject.GetComponent<DragTransform>();
                ////if (drg == null) continue;

                ////GameObject drgtcher = Instantiate(connectPrefab);
                ////DragTransformTouch drgtch = drgtcher.GetComponent<DragTransformTouch>();
                //drgtch.Connect(id, hit.transform.gameObject);

            }
        }
        //bool IsOverGUI(Vector2 pos)
        //{
        //    PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        //    eventDataCurrentPosition.position = pos;
        //    List<RaycastResult> results = new List<RaycastResult>();
        //    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        //    return results.Count > 0;
        //}
    }
}