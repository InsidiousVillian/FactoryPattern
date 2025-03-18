using UnityEngine;

public interface ISpell 
{
    int manaCost { get; }
    float castTime { get; }

    void Cast();

}
