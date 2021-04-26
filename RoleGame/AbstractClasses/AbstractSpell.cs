using RoleGame.Classes;
using RoleGame.Interfaces;

namespace RoleGame.AbstractClasses
{
  public abstract class AbstractSpell : IMagic
  {
    
    public AbstractSpell(int minManaValueForSpell, bool verbalComponent, bool motorComponent)
    {
      MinManaValueForSpell = minManaValueForSpell;
      VerbalComponent = verbalComponent;
      MotorComponent = motorComponent;
    }

    public abstract void UseSpell(PlayerWithMagic playerSender, Player player, int power = 0);

    public int MinManaValueForSpell
    {
      get => _minManaValueForSpell;
      set
      {
        if (value >= 0)
        {
          _minManaValueForSpell = value;
        }
      }
    }

    public bool VerbalComponent
    {
      get => _verbalComponent;
      set => _verbalComponent = value;
    }

    public bool MotorComponent
    {
      get => _motorComponent;
      set => _motorComponent = value;
    }

    private int _minManaValueForSpell;
    private bool _verbalComponent;
    private bool _motorComponent;
  }
}