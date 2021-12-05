using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

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
        

        private List<double> wavelength = new List<double>();
        public List<double> Wavelength
        {
            get { return wavelength; }   // get method
            set { Wavelength = value; }  // set method
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


        /* Methods:
        *  
        * 
        *
        * readTextFile(string)
        * 
        */


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //
        //      readTextFile: read spectrum data from txt file
        //      first column gets stored in Member "wavelength"
        //      second colum gets stored in Member "counts"
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int readTextFile(string path)
        {
            double x = 0;                               //buffer for parsed double to add it to list<>
            string buffer1 = " ";                       //buffer for single read lines
 

            using (StreamReader reader = new StreamReader(path)) 
            {
                //read until end of stream
                while (!reader.EndOfStream)
                {
                    buffer1 = reader.ReadLine(); 
                    string[] buffer2 = buffer1.Split("\t".ToCharArray()); //read line ist split into wavelength and counts

                  
                    buffer2[0]=buffer2[0].Replace(',', '.');
                    double.TryParse(buffer2[0], NumberStyles.Any, CultureInfo.InvariantCulture, out x);
                    wavelength.Add(x);

                    buffer2[1] = buffer2[1].Replace(',', '.');
                    double.TryParse(buffer2[1], NumberStyles.Any, CultureInfo.InvariantCulture, out x);
                    counts.Add(x);


                }

            }
            // if wavelength span is smaller or bigger than 180nm to 1400 nm
            // fill or cut Lists to size (filling with zeros)

            // filling to 180nm
   
            int min = Convert.ToInt32(Math.Floor(wavelength.Min())); // gets minimum wavelength

            if (min > 180)
            {
                int index = min - 180;
                for(int i=1;i<=index; i++)
                {
                    x = Convert.ToDouble(min - i);
                    counts.Insert(0, 0);
                    wavelength.Insert(0, x);
                }
            }
            // cut to 180 and 1400nm
            int item_index = 0;
            foreach (double item in wavelength) // Loop through List with foreach
            {
                if (item < 180|item>1400)
                {
                    item_index=wavelength.IndexOf(item);
                    wavelength.Remove(item);
                    counts.RemoveAt(item_index);
                }
            }
            

            // filling to 1400nm
            int max = Convert.ToInt32(Math.Floor(wavelength.Max())); // gets maximum wavelength
            if (max <1400)
            {
                int index = 1400 - max;
                for(int i = 1; i <= 1400-max; i++)
                {
                    x = Convert.ToDouble(max+i);
                    counts.Add(0);
                    wavelength.Add(x);
                }
               
            }

            /*
             #############################################################################################################



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
                            for (int j = 0; j < wavelength.Count; j++)
                            {


                                if (speicherrr[i] == wavelength[j])
                                {
                                    zwwell.Add(wavelength[j]);
                                    zwcount.Add(counts[j]);
                                    zahler++;
                                    if (zahler == 1) { laufindex = wavelength[j] - 180; }
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
                            wavelength.Clear();
                            counts.Clear();
                            for (int i = 0; i < zwwell.Count; i++)
                            {
                                wavelength.Add(zwwell[i]);
                                counts.Add(zwcount[i]);
                            }
                        }
                        else
                        {
                            wavelength.Clear();
                            counts.Clear();

                            if (zwwell[0] != 180 && zwwell[zwwell.Count - 1] != 1400)
                            {

                                while (z <= laufindex - 1)
                                {
                                    wavelength.Add(180 + z);
                                    counts.Add(0);

                                    z++;

                                }
                                for (int i = 0; i < zwwell.Count; i++)
                                {
                                    wavelength.Add(zwwell[i]);
                                    counts.Add(zwcount[i]);

                                }

                                laufindex = 1400 - zwwell[zwwell.Count - 1];
                                index = 0;
                                while (laufindex != index)
                                {

                                    //zwwell.Add(1400-laufindex);
                                    wavelength.Add(1400 - laufindex + 1);
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
                                    wavelength.Add(1400 - laufindex + 1);
                                    counts.Add(0);
                                    laufindex--;

                                }

                            }
                            else if (zwwell[0] != 180 && zwwell[zwwell.Count - 1] == 1400)
                            {

                                while (z <= laufindex - 1)
                                {
                                    wavelength.Add(180 + z);
                                    counts.Add(0);

                                    z++;

                                }

                                for (int i = 0; i < zwwell.Count; i++)
                                {
                                    wavelength.Add(zwwell[i]);
                                    counts.Add(zwcount[i]);

                                }



                            }



                        }

                        double sumup = 0;
                        for (int i = 0; i < wavelength.Count; i++)
                        {

                            sumup = sumup + counts[i];

                        }

                        for (int i = 0; i < wavelength.Count; i++)
                        {

                            counts[i] = counts[i] / sumup;

                        }


            ##########################################################################################################
                        */

            return 0;
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //
        //      Normierung übergabe von Ursprungsliste und Zielliste
        //
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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