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

    public class BubbleClickManager : MonoBehaviour
    {
        // public GameObject Showspawn;
        // public GameObject Showback;
        // public GameObject Hidebubbles;
        // public GameObject Hidenext;
        // public GameObject Hidetext;
        // public GameObject Hidemap;
        public GameObject PlayaudioSource;

        public Card _cardObject;
        public PaintIntro _paintObject;


        void Update()
        {
            foreach (Touch tch in InputHelper.GetTouches())
            {
                int id = tch.fingerId;

                if (tch.phase != TouchPhase.Began) continue;

                Ray ray = Camera.main.ScreenPointToRay(tch.position);
                RaycastHit hit;

                if (!Physics.Raycast(ray, out hit, 100.0F)) continue;

                Debug.Log("You hit a bubble!"); // Raph: the hit always gets detected as this line shows

                var inst = hit.transform.gameObject.GetComponent<BubbleClick>();

                if(inst == null) continue;

                Debug.Log("We found an instance: ", inst); // On some bubbles, sometimes (?), no instance is found

                if(inst.cardToActivate != null){
                    _cardObject.SetCard(inst.cardToActivate);
                    _cardObject.gameObject.SetActive(true);
                    _paintObject.gameObject.SetActive(false);
                } else if(inst.paintingToActivate != null){
                    _paintObject.SetPaintIntro(inst.paintingToActivate);
                    _paintObject.gameObject.SetActive(true);
                    _cardObject.gameObject.SetActive(false);
                    // PlayaudioSource.GetComponent<AudioSource>().Play();
                } else {
                    Debug.Log("No _cardObject or _paintObject was found.");
                }

                inst.clicked.Invoke();


                // if (hit.transform.gameObject != gameObject) continue;

                // Showspawn.SetActive(true);
                // Showback.SetActive(true);
                // Hidebubbles.SetActive(false);
                // Hidenext.SetActive(false);
                // Hidetext.SetActive(false);
                // Hidemap.SetActive(false);
                // PlayaudioSource.GetComponent<AudioSource>().Play();
                // POI_to_activate.gameObject.SetActive(true);
                // Paint_card_to_deactivate.gameObject.SetActive(false);
                          


            }
        }
    }
}



