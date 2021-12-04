using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TestBench_Class_Spektrum
{
    public class Spectrum
    {

        private double[] speicherrr;
        public double[] Speicherrr
        {
            get { return speicherrr; }
            set { speicherrr = value; }
        }




        private List<string> spalte1 = new List<string>();
        public List<string> Spalte1
        {
            get { return spalte1; }
            set { spalte1 = value; }
        }

        private List<string> spalte2 = new List<string>();
        public List<string> Spalte2
        {
            get { return spalte2; }
            set { spalte2 = value; }
        }

        string zwspeicher = " ";

        private int x1;   //x1 auf 0gesetzt
        public int X1
        {
            get { return x1; }
            set { x1 = value; }
        }
        private int x2; //x2 auf 100 gesetzt
        public int X2
        {
            get { return x2; }
            set { x2 = value; }
        }



        /* Eigenschaften
         *  
         * 
         */
        private string error;
        public string Error
        {
            get { return error; }
            set { error = value; }

        }
        /* private bool flag;
         public bool Flag
         {
             get { return flag; }
             set { flag = value; }
         }*/

        /*private string path = "";
        public string Path
        {
            get { return path; }   // get method
            set { path = value; }  // set method
        }*/



        private List<double> wellenlaenge = new List<double>();
        public List<double> Wellenlaenge
        {
            get { return wellenlaenge; }   // get method
            set { wellenlaenge = value; }  // set method
        }

        private List<double> counts = new List<double>();
        public List<double> Counts
        {
            get { return counts; }   // get method
            set { counts = value; }  // set method
        }


        private List<double> einsnormiert = new List<double>();
        public List<double> Einsnormiert
        {
            get { return einsnormiert; }   // get method
            set { einsnormiert = value; }  // set method
        }

        private List<double> offset_liste = new List<double>();
        public List<double> Offset_liste
        {
            get { return offset_liste; }   // get method
            set { offset_liste = value; }  // set method
        }


        private List<double> offset_einsnormiert = new List<double>();
        public List<double> Offset_einsnormiert
        {
            get { return offset_einsnormiert; }   // get method
            set { offset_einsnormiert = value; }  // set method
        }

        private List<double> well_segment = new List<double>();
        public List<double> Well_segment
        {
            get { return well_segment; }
            set { well_segment = value; }
        }
        private List<double> counts_segment = new List<double>();
        public List<double> Counts_segment
        {
            get { return counts_segment; }
            set { counts_segment = value; }
        }

        private List<double> zwwell = new List<double>();
        public List<double> Zwwell
        {
            get { return zwwell; }
            set { zwwell = value; }
        }


        private List<double> zwcount = new List<double>();
        public List<double> Zwcount
        {
            get { return zwcount; }
            set { zwcount = value; }
        }




        int index = 0;
        int flagg = 0;


        /* Methoden
        *  
        * 
        */


        public int readTextFile(string path)
        {
            //lese aus file(tabelle in 2 Listen speichern, aufgeteilt in Wellenlänge und counts)

            using (StreamReader lesen = new StreamReader(path))
            {
                //solange Daten lesen bis zum ende des Streams
                while (!lesen.EndOfStream)
                {
                    zwspeicher = lesen.ReadLine();
                    string[] speicher = zwspeicher.Split("\t".ToCharArray());
                    spalte1.Add(speicher[0]);
                    spalte2.Add(speicher[1]);

                }


                //Wellenlänge =Spalte 1 der excel Tabelle, Counts =spalte 2 und konvertieren in double
                wellenlaenge = spalte1.Select(s => double.Parse(s)).ToList();
                counts = spalte2.Select(r => double.Parse(r)).ToList();

            }



            //wende Methoden auf Inhalt an. Die Ursprungslisten bleibt dabei erhalten
            //  zieht offset von counts ab und schiebt das Ergebniss in offset_liste
            /* normierung(counts, einsnormiert); //normiert counts und schiebt Ergebniss in einsnormiert
                                               //normierung(offset_liste, offset_einsnormiert);                                    //normiert offset_liste und schiebt Ergebniss in einsnormiert
             offsetabziehen(X1, X2, counts, offset_liste);
             segmentausschneiden(X1, X2, counts, counts_segment);
             segmentausschneiden(X1, X2, wellenlaenge, well_segment);*/

            speicherrr = new double[1221];
            int z = 0;
            for (int i = 180; i <= 1400; i++)
            {
                speicherrr[z] = i;
                z++;

            }
            int zahler = 0;
            double laufindex = 0.0;
            for (int i = 0; i < speicherrr.Length; i++)
            {
                for (int j = 0; j < wellenlaenge.Count; j++)
                {


                    if (speicherrr[i] == wellenlaenge[j])
                    {
                        zwwell.Add(wellenlaenge[j]);
                        zwcount.Add(counts[j]);
                        zahler++;
                        if (zahler == 1) { laufindex = wellenlaenge[j] - 180; }
                        else { }


                    }
                    else
                    {

                    }

                }
            }

            z = 0;

            if (zwwell.Count == 1221 && zwwell[0] == 380)
            {
                wellenlaenge.Clear();
                counts.Clear();
                for (int i = 0; i < zwwell.Count; i++)
                {
                    wellenlaenge.Add(zwwell[i]);
                    counts.Add(zwcount[i]);
                }
            }
            else
            {
                wellenlaenge.Clear();
                counts.Clear();

                if (zwwell[0] != 180 && zwwell[zwwell.Count - 1] != 1400)
                {

                    while (z <= laufindex - 1)
                    {
                        wellenlaenge.Add(180 + z);
                        counts.Add(0);

                        z++;

                    }
                    for (int i = 0; i < zwwell.Count; i++)
                    {
                        wellenlaenge.Add(zwwell[i]);
                        counts.Add(zwcount[i]);

                    }

                    laufindex = 1400 - zwwell[zwwell.Count - 1];
                    index = 0;
                    while (laufindex != index)
                    {

                        //zwwell.Add(1400-laufindex);
                        wellenlaenge.Add(1400 - laufindex + 1);
                        counts.Add(0);
                        laufindex--;

                    }


                }




                else if (zwwell[0] == 180 && zwwell[zwwell.Count - 1] != 1400)
                {
                    laufindex = 1400 - zwwell[zwwell.Count - 1];
                    index = 0;
                    while (laufindex != index)
                    {

                        //zwwell.Add(1400-laufindex);
                        wellenlaenge.Add(1400 - laufindex + 1);
                        counts.Add(0);
                        laufindex--;

                    }

                }
                else if (zwwell[0] != 180 && zwwell[zwwell.Count - 1] == 1400)
                {

                    while (z <= laufindex - 1)
                    {
                        wellenlaenge.Add(180 + z);
                        counts.Add(0);

                        z++;

                    }

                    for (int i = 0; i < zwwell.Count; i++)
                    {
                        wellenlaenge.Add(zwwell[i]);
                        counts.Add(zwcount[i]);

                    }



                }



            }

            double sumup = 0;
            for (int i = 0; i < wellenlaenge.Count; i++)
            {

                sumup = sumup + counts[i];

            }

            for (int i = 0; i < wellenlaenge.Count; i++)
            {

                counts[i] = counts[i] / sumup;

            }





            return 0;
        }



        //Normierung übergabe von Ursprungsliste und Zielliste
        public int normierung(List<double> Ursprungsliste, List<double> Zielliste, bool flag)
        {
            flagg = 0;
            //wenn flag ==false starte normieren, 1. maximalen Wert aus liste Counts.2. neuer eintrag=Counts an der Stelle i geteilt durch Anzahl einträge
            if (flag == false)
            {
                double maxcount = Ursprungsliste.Max();

                for (int i = 0; i <= Ursprungsliste.Count - 1; i++)
                {

                    double ergebnis = Ursprungsliste[i] / maxcount;
                    Zielliste.Add(ergebnis);

                }
                flagg = 1;
                flag = true;
                return 0;
            }
            else
            {

                //Wenn flag = true Liste bereits normiert=> Ursprungsliste=Zielliste
                for (int i = 0; i <= Ursprungsliste.Count - 1; i++)
                {

                    Zielliste.Add(Ursprungsliste[i]);
                }

                return 0;
            }

        }

        //Offset 

        public int offsetabziehen(int x1, int x2, List<double> Ursprungsliste, List<double> Zielliste)
        {
            double zwmittelwert = 0;
            int distanz = x2 - x1 + 1;
            //Mittelwert im Bereich zwischen x1 und x2 berechnen
            for (int i = x1; i <= x2; i++)
            {

                zwmittelwert = zwmittelwert + Ursprungsliste[i];

            }
            double mittelwert = zwmittelwert / distanz;


            for (int k = 0; k <= Ursprungsliste.Count - 1; k++)
            {

                Zielliste.Add(Ursprungsliste[k] - mittelwert);

            }//Wenn bereits normiert, muss danach nochmal normiert werden
            if (flagg == 1)
            {
                flagg = 0;
                normierung(offset_liste, offset_einsnormiert, true);

            }
            else { }

            return 0;
        }

        //Segment ausschneiden
        public int segmentausschneiden(int x1, int x2, List<double> Ursprungsliste, List<double> Zielliste)
        {
            /*I ist Zählindex und läuft komplette Liste durch, wenn i zwischen x1 und x2 ist soll dieser Wert an der stelle i and die stelle i in der zielliste 
             gespeichert werden, wenn i ausserhalb x1 und x2 soll eine 0 an die Stelle i*/

            for (int i = 0; i <= counts.Count - 1; i++)
            {
                if (i < x1 || i > x2)
                {

                    Zielliste.Add(0);

                }
                else
                {
                    Zielliste.Add(Ursprungsliste[i]);
                }

            }
            return 0;

        }




    }
}