using UnityEngine;
using System.Collections;

public class WeaponFactory : MonoBehaviour
{



        public static NSGun CreateMKIV127()
        {

            NSGun newGun = new NSGun("Mark IV 127mm Gun", 10, 4, 800, 37, 31.75F, 20, .87F, 6, 35, 5);
            return newGun;
        }

            public static NSGun CreateMKV407mm()
        {

            NSGun newGun = new NSGun("Mark V 407mm Gun", 10, 4, 80, 30, 862F, 3, .82F, 16, 30, 16);
            return newGun;
        }


        public static NSWMissleLauncher CreateVenomSTSLauncher(int ammo, int tubes, string faction)
        {
            NSWMissleLauncher newLauncher = new NSWMissleLauncher("Venom STS Launcher", 10, 4, ammo, NSMissleFactory.createVenomSTSM(faction), tubes);
            return newLauncher;
        }

            public static NSWMissleLauncher CreateBallistaCMLauncher(int ammo, int tubes, string faction)
        {
            NSWMissleLauncher newLauncher = new NSWMissleLauncher("Ballista CM Launcher", 12, 4, ammo, NSMissleFactory.createBallistaCM(faction), tubes);
            return newLauncher;
        }

        public static NSWMissleLauncher CreateBoltCruiseMissleLauncher(int ammo, int tubes, string faction)
        {
            NSWMissleLauncher newLauncher = new NSWMissleLauncher("Bolt Cruise Missle Launcher", 10, 2, ammo, NSMissleFactory.createBoltCM(faction), tubes);
            return newLauncher;
        }
}