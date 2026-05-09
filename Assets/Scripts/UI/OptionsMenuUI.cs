using System;
using UnityEngine;

namespace UI
{
    public class OptionsMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject placeNodeMenu;
        [SerializeField] private GameObject modifyNodeMenu;
        public void Execute(OptionMenuType type)
        {
            switch (type)
            {
                case OptionMenuType.PlaceNode:
                    placeNodeMenu.SetActive(true);
                    modifyNodeMenu.SetActive(false);
                    break;
                case OptionMenuType.ModifyNode:
                    placeNodeMenu.SetActive(false);
                    modifyNodeMenu.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}