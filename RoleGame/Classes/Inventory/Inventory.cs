using System;
using System.Collections.Generic;
using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Inventory {
  public class Inventory {

    public Inventory() {
      _bag = new List<AbstractArtifact>();
    }

    public void PickUpArtifact(AbstractArtifact artifact) {
      Bag.Add(artifact);
    }

    public void ThrowAwayArtifact(AbstractArtifact artifact) {
      if (Bag.Contains(artifact)) {
        Bag.Remove(artifact);
      } else {
        Console.WriteLine("There is no such artifact in inventory!");
      }
    }

    public void TransferArtifactToAnotherPlayer(AbstractArtifact artifact, Player playerReceiver) {
      ThrowAwayArtifact(artifact);
      playerReceiver.Inventory.PickUpArtifact(artifact);
    }

    public bool ContainsArtifact(AbstractArtifact artifact) {
      return Bag.Contains(artifact);
    }

    public List<AbstractArtifact> Bag {
      get => _bag;
      private set => _bag = value;
    }
    
    
    private List<AbstractArtifact> _bag;
  }
}