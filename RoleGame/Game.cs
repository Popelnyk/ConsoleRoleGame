using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using RoleGame.AbstractClasses;
using RoleGame.Classes;
using RoleGame.Classes.Artifacts;
using RoleGame.Classes.Inventory;
using RoleGame.Classes.Spells;

namespace RoleGame
{
    public class Game
    {
        private static Game instance;
        
        private AddHealthSpell addHealthSpell = new AddHealthSpell();
        private AntidoteSpell antidoteSpell = new AntidoteSpell();
        private ArmorSpell armorSpell = new ArmorSpell();
        private BringToLifeSpell bringToLifeSpell = new BringToLifeSpell();
        private HealSpell healSpell = new HealSpell();
        private WakeUpSpell wakeUpSpell = new WakeUpSpell();
      
        //artifacts
        private BasiliskEyeArtifact basiliskEyeArtifact = new BasiliskEyeArtifact();
      
        private DeathWaterBottleArtifact deathWaterBottleArtifactSmall = new DeathWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Small);
        private DeathWaterBottleArtifact deathWaterBottleArtifactMiddle = new DeathWaterBottleArtifact();
        private DeathWaterBottleArtifact deathWaterBottleArtifactLarge = new DeathWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Big);
      
        private FrogLegsDecoctArtifact frogLegsDecoctArtifact = new FrogLegsDecoctArtifact();
        private LightningStaffArtifact lightningStaffArtifact = new LightningStaffArtifact();
      
        private LivingWaterBottleArtifact livingWaterBottleArtifactSmall = new LivingWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Small);
        private LivingWaterBottleArtifact livingWaterBottleArtifactMiddle = new LivingWaterBottleArtifact();
        private LivingWaterBottleArtifact livingWaterBottleArtifactLarge = new LivingWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Big);
     
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
        private Player simpleTroop6 = new Player("ROCKY", PlayerParams.Race.Goblin, PlayerParams.Sex.Male, 34);

        private Game() {}
        
        public static Game GetInstance()
        {
            if (instance == null)
                instance = new Game();
            return instance;
        }
        
        public void Start()
        {
            Console.WriteLine("Create your character:");
            Console.WriteLine("Choose race: 1 -- Elf, 2 -- Ork, 3 -- Human, 4 -- Gnome, 5 -- Goblin");
            int type = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine(type);
            
            if (type > 4 || type < 0)
            {
                throw new Exception("Error character type");
            }
            
            Console.WriteLine("Choose sex: 1 -- man, 2 -- woman");
            int sex = Convert.ToInt32(Console.ReadLine());
                
            if (sex != 1 && sex != 2)
            {
                throw new Exception("Error character sex");
            }
            
            Console.WriteLine("Enter age:");
            int age = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Name your character");
            string name = Console.ReadLine();
            
            Console.WriteLine("Will your player have magic skills ? 1 -- yes, 2 -- no");
            int isMagic = Convert.ToInt32(Console.ReadLine());
            
            var player = isMagic == 1 ? new PlayerWithMagic(name, (PlayerParams.Race)type, (PlayerParams.Sex)sex, age) 
                : new Player(name, (PlayerParams.Race)type, (PlayerParams.Sex)sex, age);
        }
    }
}