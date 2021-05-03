using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using RoleGame.AbstractClasses;
using RoleGame.Classes;
using RoleGame.Classes.Artifacts;
using RoleGame.Classes.Inventory;
using RoleGame.Classes.Spells;

namespace RoleGame {
  public class Game {
    private static Game instance;

    private AddHealthSpell addHealthSpell = new AddHealthSpell();
    private AntidoteSpell antidoteSpell = new AntidoteSpell();
    private ArmorSpell armorSpell = new ArmorSpell();
    private BringToLifeSpell bringToLifeSpell = new BringToLifeSpell();
    private HealSpell healSpell = new HealSpell();
    private WakeUpSpell wakeUpSpell = new WakeUpSpell();

    //artifacts
    private BasiliskEyeArtifact basiliskEyeArtifact = new BasiliskEyeArtifact();

    private DeathWaterBottleArtifact deathWaterBottleArtifactSmall =
      new DeathWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Small);

    private DeathWaterBottleArtifact deathWaterBottleArtifactMiddle = new DeathWaterBottleArtifact();

    private DeathWaterBottleArtifact deathWaterBottleArtifactLarge =
      new DeathWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Big);

    private FrogLegsDecoctArtifact frogLegsDecoctArtifact = new FrogLegsDecoctArtifact();
    private LightningStaffArtifact lightningStaffArtifact = new LightningStaffArtifact();

    private LivingWaterBottleArtifact livingWaterBottleArtifactSmall =
      new LivingWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Small);

    private LivingWaterBottleArtifact livingWaterBottleArtifactMiddle = new LivingWaterBottleArtifact();

    private LivingWaterBottleArtifact livingWaterBottleArtifactLarge =
      new LivingWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Big);

    private PoisonousSalivaArtifact poisonousSalivaArtifact = new PoisonousSalivaArtifact();

    private PlayerWithMagic wizard = new PlayerWithMagic("Alex", PlayerParams.Race.Elf, PlayerParams.Sex.Female, 19);
    private PlayerWithMagic wizard1 = new PlayerWithMagic("Hleb", PlayerParams.Race.Goblin, PlayerParams.Sex.Male, 4);
    private PlayerWithMagic wizard2 = new PlayerWithMagic("Danik", PlayerParams.Race.Human, PlayerParams.Sex.Female, 44);
    private PlayerWithMagic wizard3 = new PlayerWithMagic("vfvf", PlayerParams.Race.Orc, PlayerParams.Sex.Male, 76);
    private PlayerWithMagic wizard4 = new PlayerWithMagic("FFFF", PlayerParams.Race.Orc, PlayerParams.Sex.Male, 43);
    private PlayerWithMagic wizard5 = new PlayerWithMagic("OPOKL", PlayerParams.Race.Gnome, PlayerParams.Sex.Male, 34);

    private Player simpleTroop = new Player("Alex", PlayerParams.Race.Elf, PlayerParams.Sex.Male, 19);
    private Player simpleTroop1 = new Player("Hleeb", PlayerParams.Race.Gnome, PlayerParams.Sex.Male, 1);
    private Player simpleTroop2 = new Player("Daniil", PlayerParams.Race.Human, PlayerParams.Sex.Male, 88);
    private Player simpleTroop3 = new Player("OLPe", PlayerParams.Race.Orc, PlayerParams.Sex.Female, 77);
    private Player simpleTroop4 = new Player("ASOP", PlayerParams.Race.Gnome, PlayerParams.Sex.Male, 54);
    private Player simpleTroop5 = new Player("ASAP", PlayerParams.Race.Orc, PlayerParams.Sex.Female, 34);

    private Game() { }

    public static Game GetInstance() {
      if (instance == null)
        instance = new Game();
      return instance;
    }

    public void Start() {
      Console.WriteLine("Create your character:");
      Console.WriteLine("Choose race:\n \t" +
                        "1 -- Elf\n \t" +
                        "2 -- Ork\n \t" +
                        "3 -- Human\n \t" +
                        "4 -- Gnome\n \t" +
                        "5 -- Goblin");
      int type = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine(type);

      if (type > 4 || type < 0) {
        throw new Exception("Error character type");
      }

      Console.WriteLine("Choose sex:\n \t" +
                        "1 -- man\n \t" +
                        "2 -- woman");
      int sex = Convert.ToInt32(Console.ReadLine());

      if (sex != 1 && sex != 2) {
        throw new Exception("Error character sex");
      }

      Console.WriteLine("Enter age:");
      int age = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Name your character");
      string name = Console.ReadLine();

      Console.WriteLine("Will your player have magic skills ?\n \t" +
                        "1 -- yes\n \t" +
                        "2 -- no");
      int isMagic = Convert.ToInt32(Console.ReadLine());

      var player = isMagic == 1
        ? new PlayerWithMagic(name, (PlayerParams.Race) type, (PlayerParams.Sex) sex, age)
        : new Player(name, (PlayerParams.Race) type, (PlayerParams.Sex) sex, age);

      while (true) {
        Console.WriteLine("\n");
        Console.WriteLine("Enter q to quit\n \t" +
                          "enter 1 to cast spell\n \t" +
                          "enter 2 to use artifact\n \t" +
                          "enter 3 to pick up artifact\n \t" +
                          "enter 4 to throw away artifact\n \t" +
                          "enter 5 to give artifact to another player\n \t" +
                          "enter 6 to learn spell\n \t" +
                          "enter 7 to forget spell\n \t" +
                          "enter 8 to output info about player\n \t");
        string command = Console.ReadLine();
        int commandCode = Convert.ToInt32(command);
        if (command == "q") {
          break;
        }

        switch (commandCode) {
          case 1: {
            if (player.GetType() == typeof(Player)) {
              Console.WriteLine("You cant use spells for not wizards!");
              break;
            }

            Console.WriteLine("Choose spell:\n \t" +
                              "1 -- Add Health Spell\n \t" +
                              "2 -- Antidote Spell\n \t" +
                              "3 -- Armor Spell\n \t" +
                              "4 -- Bring to life Spell\n \t" +
                              "5 -- Heal Spell\n \t" +
                              "6 -- Wake Up Spell");
            int spellCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter power of spell");
            int powerForSpell = Convert.ToInt32(Console.ReadLine());
            switch (spellCode) {
              case 1: {
                ((PlayerWithMagic) player).CastSpell(addHealthSpell.UseMagic, wizard, powerForSpell);
                break;
              }
              case 2: {
                ((PlayerWithMagic) player).CastSpell(antidoteSpell.UseMagic, wizard1, powerForSpell);
                break;
              }
              case 3: {
                ((PlayerWithMagic) player).CastSpell(armorSpell.UseMagic, simpleTroop, powerForSpell);
                break;
              }
              case 4: {
                ((PlayerWithMagic) player).CastSpell(bringToLifeSpell.UseMagic, simpleTroop4, powerForSpell);
                break;
              }
              case 5: {
                ((PlayerWithMagic) player).CastSpell(healSpell.UseMagic, wizard2, powerForSpell);
                break;
              }
              case 6: {
                ((PlayerWithMagic) player).CastSpell(wakeUpSpell.UseMagic, simpleTroop3, powerForSpell);
                break;
              }
              default: {
                Console.WriteLine("Wrong number of spell!");
                break;
              }
            }
            break;
          }
          case 2: {
            Console.WriteLine("Choose artifact:\n \t" +
                              "1 -- Basilisk eye Artifact\n \t" +
                              "2 -- Death water bottle Artifact\n \t" +
                              "3 -- Frog legs decoct Artifact\n \t" +
                              "4 -- Lightning staff Artifact\n \t" +
                              "5 -- Living water bottle Artifact\n \t" +
                              "6 -- Poisonous saliva Artifact");
            int artifactCode = Convert.ToInt32(Console.ReadLine());
            switch (artifactCode) {
              case 1: {
                player.CastArtifact(basiliskEyeArtifact.UseMagic, wizard);
                break;
              }
              case 2: {
                player.CastArtifact(deathWaterBottleArtifactLarge.UseMagic, simpleTroop);
                break;
              }
              case 3: {
                player.CastArtifact(frogLegsDecoctArtifact.UseMagic, simpleTroop5);
                break;
              }
              case 4: {
                Console.WriteLine("Enter power of artifact");
                int powerForArtifact = Convert.ToInt32(Console.ReadLine());
                player.CastArtifact(lightningStaffArtifact.UseMagic, simpleTroop, powerForArtifact);
                break;
              }
              case 5: {
                player.CastArtifact(livingWaterBottleArtifactLarge.UseMagic, wizard3);
                break;
              }
              case 6: {
                player.CastArtifact(poisonousSalivaArtifact.UseMagic, wizard5);
                break;
              }
              default: {
                Console.WriteLine("Wrong number of artifact!");
                break;
              }
            }
            break;
          }
          case 3: {
            Console.WriteLine("Choose artifact to pick up:\n \t" +
                              "1 -- Basilisk eye Artifact\n \t" +
                              "2 -- Death water bottle Artifact\n \t" +
                              "3 -- Frog legs decoct Artifact\n \t" +
                              "4 -- Lightning staff Artifact\n \t" +
                              "5 -- Living water bottle Artifact\n \t" +
                              "6 -- Poisonous saliva Artifact");
            int artifactCode = Convert.ToInt32(Console.ReadLine());
            switch (artifactCode) {
              case 1: {
                player.Inventory.PickUpArtifact(basiliskEyeArtifact);
                break;
              }
              case 2: {
                player.Inventory.PickUpArtifact(deathWaterBottleArtifactLarge);
                break;
              }
              case 3: {
                player.Inventory.PickUpArtifact(frogLegsDecoctArtifact);
                break;
              }
              case 4: {
                player.Inventory.PickUpArtifact(lightningStaffArtifact);
                break;
              }
              case 5: {
                player.Inventory.PickUpArtifact(livingWaterBottleArtifactLarge);
                break;
              }
              case 6: {
                player.Inventory.PickUpArtifact(poisonousSalivaArtifact);
                break;
              }
              default: {
                Console.WriteLine("Wrong number of artifact!");
                break;
              }
            }
            break;
          }
          case 4: {
            Console.WriteLine("Choose artifact to throw away:\n \t" +
                              "1 -- Basilisk eye Artifact\n \t" +
                              "2 -- Death water bottle Artifact\n \t" +
                              "3 -- Frog legs decoct Artifact\n \t" +
                              "4 -- Lightning staff Artifact\n \t" +
                              "5 -- Living water bottle Artifact\n \t" +
                              "6 -- Poisonous saliva Artifact");
            int artifactCode = Convert.ToInt32(Console.ReadLine());
            switch (artifactCode) {
              case 1: {
                player.Inventory.ThrowAwayArtifact(basiliskEyeArtifact);
                break;
              }
              case 2: {
                player.Inventory.ThrowAwayArtifact(deathWaterBottleArtifactLarge);
                break;
              }
              case 3: {
                player.Inventory.ThrowAwayArtifact(frogLegsDecoctArtifact);
                break;
              }
              case 4: {
                player.Inventory.ThrowAwayArtifact(lightningStaffArtifact);
                break;
              }
              case 5: {
                player.Inventory.ThrowAwayArtifact(livingWaterBottleArtifactLarge);
                break;
              }
              case 6: {
                player.Inventory.ThrowAwayArtifact(poisonousSalivaArtifact);
                break;
              }
              default: {
                Console.WriteLine("Wrong number of artifact!");
                break;
              }
            }
            break;
          }
          case 5: {
            Console.WriteLine("Choose artifact to transfer:\n \t" +
                              "1 -- Basilisk eye Artifact\n \t" +
                              "2 -- Death water bottle Artifact\n \t" +
                              "3 -- Frog legs decoct Artifact\n \t" +
                              "4 -- Lightning staff Artifact\n \t" +
                              "5 -- Living water bottle Artifact\n \t" +
                              "6 -- Poisonous saliva Artifact");
            int artifactCode = Convert.ToInt32(Console.ReadLine());
            switch (artifactCode) {
              case 1: {
                player.Inventory.TransferArtifactToAnotherPlayer(basiliskEyeArtifact, wizard2);
                break;
              }
              case 2: {
                player.Inventory.TransferArtifactToAnotherPlayer(deathWaterBottleArtifactLarge, simpleTroop2);
                break;
              }
              case 3: {
                player.Inventory.TransferArtifactToAnotherPlayer(frogLegsDecoctArtifact, simpleTroop4);
                break;
              }
              case 4: {
                player.Inventory.TransferArtifactToAnotherPlayer(lightningStaffArtifact, wizard4);
                break;
              }
              case 5: {
                player.Inventory.TransferArtifactToAnotherPlayer(livingWaterBottleArtifactLarge, wizard4);
                break;
              }
              case 6: {
                player.Inventory.TransferArtifactToAnotherPlayer(poisonousSalivaArtifact, simpleTroop3);
                break;
              }
              default: {
                Console.WriteLine("Wrong number of artifact!");
                break;
              }
            }
            break;
          }
          case 6: {
            if (player.GetType() == typeof(Player)) {
              Console.WriteLine("You cant use spells for not wizards!");
              break;
            }

            Console.WriteLine("Choose spell to learn:\n \t" +
                              "1 -- Add Health Spell\n \t" +
                              "2 -- Antidote Spell\n \t" +
                              "3 -- Armor Spell\n \t" +
                              "4 -- Bring to life Spell\n \t" +
                              "5 -- Heal Spell\n \t" +
                              "6 -- Wake Up Spell");
            int spellCode = Convert.ToInt32(Console.ReadLine());
            switch (spellCode) {
              case 1: {
                ((PlayerWithMagic) player).LearnSpell(addHealthSpell);
                break;
              }
              case 2: {
                ((PlayerWithMagic) player).LearnSpell(antidoteSpell);
                break;
              }
              case 3: {
                ((PlayerWithMagic) player).LearnSpell(armorSpell);
                break;
              }
              case 4: {
                ((PlayerWithMagic) player).LearnSpell(bringToLifeSpell);
                break;
              }
              case 5: {
                ((PlayerWithMagic) player).LearnSpell(healSpell);
                break;
              }
              case 6: {
                ((PlayerWithMagic) player).LearnSpell(wakeUpSpell);
                break;
              }
              default: {
                Console.WriteLine("Wrong number of spell!");
                break;
              }
            }
            break;
          }
          case 7: {
            if (player.GetType() == typeof(Player)) {
              Console.WriteLine("You cant use spells for not wizards!");
              break;
            }

            Console.WriteLine("Choose spell to forget:\n \t" +
                              "1 -- Add Health Spell\n \t" +
                              "2 -- Antidote Spell\n \t" +
                              "3 -- Armor Spell\n \t" +
                              "4 -- Bring to life Spell\n \t" +
                              "5 -- Heal Spell\n \t" +
                              "6 -- Wake Up Spell");
            int spellCode = Convert.ToInt32(Console.ReadLine());
            switch (spellCode) {
              case 1: {
                ((PlayerWithMagic) player).ForgetSpell(addHealthSpell);
                break;
              }
              case 2: {
                ((PlayerWithMagic) player).ForgetSpell(antidoteSpell);
                break;
              }
              case 3: {
                ((PlayerWithMagic) player).ForgetSpell(armorSpell);
                break;
              }
              case 4: {
                ((PlayerWithMagic) player).ForgetSpell(bringToLifeSpell);
                break;
              }
              case 5: {
                ((PlayerWithMagic) player).ForgetSpell(healSpell);
                break;
              }
              case 6: {
                ((PlayerWithMagic) player).ForgetSpell(wakeUpSpell);
                break;
              }
              default: {
                Console.WriteLine("Wrong number of spell!");
                break;
              }
            }
            break;
          }
          case 8: {
            Console.WriteLine("Enter type of characters to show info:\n \t" +
                              "1 -- this person\n \t" +
                              "2 -- wizards\n \t" +
                              "3 -- players");
            int classCharacter = Convert.ToInt32(Console.ReadLine());
            switch (classCharacter) {
              case 1: {
                Console.WriteLine(player);
                break;
              }
              case 2: {
                Console.WriteLine("Enter number of wizard(1-6):\n \t");
                int wizardNumber = Convert.ToInt32(Console.ReadLine());
                switch (wizardNumber) {
                  case 1: {
                    Console.WriteLine(wizard);
                    break;
                  }
                  case 2: {
                    Console.WriteLine(wizard1);
                    break;
                  }
                  case 3: {
                    Console.WriteLine(wizard2);
                    break;
                  }
                  case 4: {
                    Console.WriteLine(wizard3);
                    break;
                  }
                  case 5: {
                    Console.WriteLine(wizard4);
                    break;
                  }
                  case 6: {
                    Console.WriteLine(wizard5);
                    break;
                  }
                  default: {
                    Console.WriteLine("There is no wizards with this number");
                    break;
                  }
                }
                break;
              }
              case 3: {
                Console.WriteLine("Enter number of player(1-6):\n \t");
                int playerNumber = Convert.ToInt32(Console.ReadLine());
                switch (playerNumber) {
                  case 1: {
                    Console.WriteLine(simpleTroop);
                    break;
                  }
                  case 2: {
                    Console.WriteLine(simpleTroop1);
                    break;
                  }
                  case 3: {
                    Console.WriteLine(simpleTroop2);
                    break;
                  }
                  case 4: {
                    Console.WriteLine(simpleTroop3);
                    break;
                  }
                  case 5: {
                    Console.WriteLine(simpleTroop4);
                    break;
                  }
                  case 6: {
                    Console.WriteLine(simpleTroop5);
                    break;
                  }
                  default: {
                    Console.WriteLine("There is no troops with this number");
                    break;
                  }
                }
                break;
              }
              default: {
                Console.WriteLine("Wrong type");
                break;
              }
            }


            break;
          }
        }

        //Thread.Sleep(5000);
      }
    }
  }
}