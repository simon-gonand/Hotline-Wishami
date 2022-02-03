using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;


namespace UI.PlainButton
{
    public class PlainButton : Button
    {
        public new class UxmlFactory : UxmlFactory<PlainButton, UxmlTraits> { }

        public PlainButton()
        {
            RemoveFromClassList("unity-button");
            AddToClassList("MainMenuButton");
           
        }

    }
}