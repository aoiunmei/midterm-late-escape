using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ISelectable
{
    void OnHoverEnter();
    void OnHoverExit();
    void OnSelect();
}