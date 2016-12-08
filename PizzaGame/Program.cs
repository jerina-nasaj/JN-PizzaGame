using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PizzaGame
{
    public class Giocatore
    {
      public  bool Perde;
      public int NrPizzeMangiate;
        
    }



    class Program
    {
       
        static void Main(string[] args)
        {
            Random rnd = new Random();

            //Si generà un numero totale delle pizze
            int NumerodiPizze = rnd.Next(10, 30);
            Console.Title = "Pizza Game";

            Giocatore gA = new Giocatore();
            Giocatore gB = new Giocatore();

            Console.WriteLine("\nPizza Game \nIl numero totale di pizze è " + NumerodiPizze);

            //Si chiama il metodo Game che calcola il numero di pizze che mangia ogni giocatore e quante pizze rimangono
            Game(NumerodiPizze, gA, gB);

            string message = "";
            if (gB.Perde == true) { message = "\nIl giocatore B ha perso! Fine del gioco. "; }
            else { message = "\nIl giocatore A ha perso! Fine del gioco. "; }

            Console.WriteLine(message);


            Console.ReadLine();

        }


        /// <summary>
        /// Questo metodo calcola il numero di pizze che rimane quando ogni giocatore mangia
        /// </summary>
        /// <param name="NumerodiPizze">Il numero totale delle pizze </param>
        /// <param name="gA">Il giocatore A </param>
        /// <param name="gB">Il giocatore B </param>

        private static void Game(int NumerodiPizze, Giocatore gA, Giocatore gB)
        {
            while (NumerodiPizze > 0)
            {
                #region  Primo giocatore                   
                //Il turno del primo giocatore
                while (true)
                {
                    if (NumerodiPizze == 0) break;
                    Console.WriteLine("\nA: Scrivi il numero di pizze che mangia il giocatore A: ");
                    int input;
                    bool res = Int32.TryParse(Console.ReadLine(),out input);

                    //Si controlla se i giocatori usano lo stesso numero in un turno e i valori sono 1,2 o 3
                    bool result = (controllaNumero(input) && controllaNumeroMaggiore(input, NumerodiPizze) && (input != gB.NrPizzeMangiate));
                    if (result)
                    {
                        NumerodiPizze = CalcolatePizza(NumerodiPizze, gA, input, "A");
                        if ((NumerodiPizze == 0)) { gA.Perde = true; gB.Perde = false; }
                        if ((NumerodiPizze == 2))
                        {
                            gA.Perde = false; gB.Perde = true;
                            NumerodiPizze = 0;
                            Console.WriteLine("\nIl giocatore B ha perso. Se mangia 2 pizze perde. Se decide di mangiare 1 pizza,\n allora il giocatore A è costretto a saltare il turno in quanto non puó applicare le proprie mosse");
                            
                        }

                        break;
                    }

                    else
                    {
                        Console.WriteLine("\nQuesto formato di numero non è correto!! Il numero deve essere 1,2 oppure 3, non uguale al turno precedente e minore del numero di pizze rimaste.");
                        continue;
                    }
                   

                }

                #endregion

                #region Secondo giocatore               
                //Il turno del secondo giocatore
                while (true)
                {
                    if (NumerodiPizze == 0) break;
                    Console.WriteLine("\nB: Scrivi il numero di pizze che mangia il giocatore B: ");
                    int input2;
                    bool res = Int32.TryParse(Console.ReadLine(), out input2);

                    //Si controlla se i giocatori usano lo stesso numero in un turno e i valori sono 1,2 o 3
                    bool result = (controllaNumero(input2) && controllaNumeroMaggiore(input2, NumerodiPizze) && (input2 != gA.NrPizzeMangiate));
                    if (result)
                    {
                        NumerodiPizze = CalcolatePizza(NumerodiPizze, gB, input2, "B");
                        if ((NumerodiPizze == 0)) { gB.Perde = true; gA.Perde = false; }
                        if ((NumerodiPizze == 2))
                        {
                            gA.Perde = true; gB.Perde = false;
                            NumerodiPizze = 0;
                            Console.WriteLine("\nIl giocatore A ha perso. Se mangia 2 pizze perde. Se decide di mangiare 1 pizza, \nallora il giocatore B è costretto a saltare il turno in quanto non puó applicare le proprie mosse");
                            
                        }

                        break;
                    }

                    else
                    {
                        Console.WriteLine("\nQuesto formato di numero non è correto!! Il numero deve essere 1,2 oppure 3, non uguale al turno precedente e minore del numero di pizze rimaste ");                      
                        continue;
                    }
                    
                }               

                #endregion
            }

        }


        /// <summary>
        /// Questo metodo calcola il numero di pizze che rimangono dopo ogni turno
        /// </summary>
        private static int CalcolatePizza(int NumerodiPizze, Giocatore gA, int input, string name)
        {
            gA.NrPizzeMangiate = input;
            NumerodiPizze = NumerodiPizze - gA.NrPizzeMangiate;

            string msg1 = "\nIl giocatore " + name + " ha mangiato " + gA.NrPizzeMangiate + " pizze" + "\nIl numero di pizze rimaste è  " + NumerodiPizze;
            Console.WriteLine(msg1);
            return NumerodiPizze;
        }

        /// <summary>
        /// Questo metodo controlla se il numero scelto dal giocatore è 1,2 oppure 3
        /// </summary>
        public static Boolean controllaNumero(int numero)
        {
            if ((numero == 3) || (numero == 2) || (numero == 1)) return true;
            else
                return false;
        }

        /// <summary>
        /// Questo metodo controlla se il numero scelto dal giocatore è inferiore al numero rimasto di pizze
        /// </summary>
        public static Boolean controllaNumeroMaggiore(int input, int nrpizze)
        {
            if (input > nrpizze) return false;
            else return true;
        }

    }
}
