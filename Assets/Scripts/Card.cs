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
using UnityEngine.UI;

namespace NEEEU {
    public class Card : MonoBehaviour {
        public GameObject _paintintro;

        public Text _title;
        public Text _subtitle;
        public Text _body;
        public Image _image;
        public GameObject _audio;

        public void SetCard(CardSettings card) {
            _title.text = card.title;
            _subtitle.text = card.subtitle;
            _body.text = card.body;
            _image.sprite = card.image;

            var audioSource = _audio.GetComponent<AudioSource>();
            audioSource.clip = card.audio;
            if (LanguageSelector.language == LanguageSelector.Lang.De) {
                _title.text = card.title_de;
                _subtitle.text = card.subtitle_de;
                _body.text = card.body_de;
                audioSource.clip = card.audio_de;
            }
            audioSource.Play();

            _paintintro.SetActive(false);
        }
    }
}