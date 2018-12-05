using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Classe
{
    class Catapult : ArmeDeJet
    {
        protected Spoon spoon = new Spoon();
        protected Rope rope = new Rope();
        protected Trigger trigger = new Trigger();
        protected Arm arm = new Arm();
        protected Beam beam = new Beam();

        private double power;

        public Catapult()
        {
            spoon.Name = "Spoon";
            rope.Name = "Rope";
            trigger.Name = "Trigger";
            arm.Name = "Arm";
            beam.Name = "Beam";            
        }

        public void PrepaTir(int vie_spoon, int vie_rope, int vie_trigger, int vie_arm, int vie_beam)
        {
            spoon.Life = vie_spoon;
            rope.Life = vie_rope;
            trigger.Life = vie_trigger;
            arm.Life = vie_arm;
            beam.Life = vie_beam;
        }

        public override bool Tir()
        {
            Random rand = new Random();

            if (
                (spoon.LoadTheRock(rand.Next(3, 10))) &&
                (rope.LowerTheSpoon()) &&
                (trigger.Fire()) &&
                (arm.Move()) &&
                (beam.StopTheArm())
            ) {
                power = arm.LaunchTheSpoon(spoon.Rock, rope.Tension);
                Console.WriteLine("Chief, Catapult is firing !");
                return true;
            }

            return false;
        }

    }
}
