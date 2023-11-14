using System;
using System.Collections.Generic;
using System.Linq;
using Configs.Scripts;
using Microsoft.MixedReality.Toolkit.UI;
using Redcode.Extensions;
using TMPro;
using UnityEngine;
using Debug = Sisus.Debugging.Debug;

namespace Sections
{
    public class KeyboardSection : SolvableSection
    {
        [SerializeField] private KeyboardSectionConfig _config;
        private KeyboardButton[] _buttons;
        private List<char> _order;
        private List<char> _answer = new();
        private int _step;

        private void Start()
        {
            _order = new List<char>(_config.SymbolOrders.GetRandomElement().ToList());
            _buttons = GetComponentsInChildren<KeyboardButton>();

            var tmpList = new List<char>(_order);
            foreach (var button in _buttons)
            {
                char symbol = tmpList.PopRandom().element;
                button.Symbol = symbol;
                _answer.Add(symbol);
                
                button.GetComponent<Interactable>().OnClick.AddListener(() =>
                {
                    if (_answer[_step++] != button.Symbol)
                    {
                        _step = 0;
                        WrongInteract();
                    }

                    if (_step == 4)
                    {
                        Interact();
                    }
                });
            }

            Debug.Log(_answer);
            _answer.Sort(SortByOrder);
            Debug.Log(_answer);
            Debug.Log(_order);
        }

        private int SortByOrder(char x, char y)
        {
            return _order.IndexOf(x).CompareTo(_order.IndexOf(y));
        }


        public override void Interact()
        {
            base.Interact();
            foreach (var button in _buttons)
                button.GetComponent<Interactable>().OnClick.RemoveAllListeners();
        }
    }
}