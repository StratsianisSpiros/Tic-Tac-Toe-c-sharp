using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Triliza
{
    class Program
    {

        static void Main(string[] args)
        {
            Game game = new Game();

            while (true)
            {
                game.Menu();
            }
        }
    }
}
