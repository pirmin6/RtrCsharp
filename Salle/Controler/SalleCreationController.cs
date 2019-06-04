using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Model.Salle;
using Salle.Model.Commun;

namespace Salle.Controler
{
    class SalleCreationController
    {
        Carre Carre1;
        Carre Carre2;
        ChefRang ChefRangCarre1;
        ChefRang ChefRangCarre2;
        Carte Carte1;
        
        public MaitreHotel  monMaitre;

        public SalleCreationController()
        {
            this.CreationChefsRang();

            this.CreationTable();

            this.CreationMaitreHotel();

            this.CreationServeur();

            this.CreationCarte();

        }

        private void CreationTable()
        {
            /********************CREER TABLEAU POUR PREMIER CARRE******************************/

            int[][] TablesCarre1 = new int[3][];
            TablesCarre1[0] = new int[5];
            TablesCarre1[0][0] = 2;
            TablesCarre1[0][1] = 4;
            TablesCarre1[0][2] = 6;
            TablesCarre1[0][3] = 8;
            TablesCarre1[0][4] = 4;

            TablesCarre1[1] = new int[5];
            TablesCarre1[1][0] = 2;
            TablesCarre1[1][1] = 4;
            TablesCarre1[1][2] = 6;
            TablesCarre1[1][3] = 8;
            TablesCarre1[1][4] = 4;

            TablesCarre1[2] = new int[6];
            TablesCarre1[2][0] = 2;
            TablesCarre1[2][1] = 4;
            TablesCarre1[2][2] = 6;
            TablesCarre1[2][3] = 2;
            TablesCarre1[2][4] = 2;
            TablesCarre1[2][5] = 10;


            /********************DEUXIEME CARRE******************************/

            int[][] TablesCarre2 = new int[3][];
            TablesCarre2[0] = new int[6];
            TablesCarre2[0][0] = 2;
            TablesCarre2[0][1] = 4;
            TablesCarre2[0][2] = 8;
            TablesCarre2[0][3] = 6;
            TablesCarre2[0][4] = 4;
            TablesCarre2[0][5] = 2;

            TablesCarre2[1] = new int[6];
            TablesCarre2[1][0] = 2;
            TablesCarre2[1][1] = 4;
            TablesCarre2[1][2] = 8;
            TablesCarre2[1][3] = 6;
            TablesCarre2[1][4] = 4;
            TablesCarre2[1][5] = 2;

            TablesCarre2[2] = new int[4];
            TablesCarre2[2][0] = 2;
            TablesCarre2[2][1] = 4;
            TablesCarre2[2][2] = 8;
            TablesCarre2[2][3] = 10;

            Carre1 = new Carre(TablesCarre1, ChefRangCarre1);
            Carre2 = new Carre(TablesCarre2, ChefRangCarre2);
        }


        private void CreationMaitreHotel()
        {
            monMaitre = new MaitreHotel(Carre1, Carre2);

        }

        private void CreationChefsRang()
        {
            ChefRangCarre1 = new ChefRang();
            ChefRangCarre2 = new ChefRang();
        }

        private void CreationServeur()
        {
            
        }

        private void CreationCarte()
        {
            Carte1 = new Carte();
        }

    }
}
