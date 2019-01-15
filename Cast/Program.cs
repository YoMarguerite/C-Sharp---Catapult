using Cast.Package.Soldier;

//Classe Program

namespace Catapulte.Package
{
    //Program contient les instructions de déroulement du programme
    class Program
    {
        //Méthode static Main 
        static void Main(string[] args)
        {
            Chief chief = new Chief();
            chief.hireSoldier();
            bool proceed = true;
            chief.setWork(proceed);
        }
    }
}
