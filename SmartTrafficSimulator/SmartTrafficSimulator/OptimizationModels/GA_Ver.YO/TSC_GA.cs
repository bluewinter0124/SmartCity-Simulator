using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator.OptimizationModels.GA_Yo
{
    class TSC_GA
    {
        public int id;
        public int vector;
        public int[] result;
        public int self_id, right_id, left_id;
        public int GTmax, GTmin;
        public int cycle_time;
        public int offset;

        //private int PreGtA, PreGtB, PreGtC;
        private double Qright, Qleft;
        private double AvgUp, AvgDown;
        private int generation;
        private int popNumber;
        private int chromosomLength;
        private double TFP;
        private int replace;
        private int great;
        private int crossoverProb;
        private int mutationProb;
        private int[] GTpast;
        private int[,] chromosom;
        private double[] fitValue;
        private double[] tempfitValue;
        private int[,] replaceChro;
        private int[,] greatChro;
        private double fitValuetotal;
        private bool E1_bool, E2_bool, E3_bool;


        public int GAmain(int v, double QR, double QL, double AU, double AD, int PreA, int PreB, int PreC)
        {
            int i;

            initial(v, QR, QL, AU, AD, PreA, PreB, PreC);
            initialPopulation();

            for(i=0;i<generation;i++)
            {
                evolution();
            }
            findans();

            return result[0];
        }

        public void initial(int v, double QR, double QL, double AU, double AD, int PreA, int PreB, int PreC)
        {
            /*******setting******/
            popNumber = 100;
            generation = 30;
            chromosomLength = 3;
            replace = 70;
            crossoverProb = 8;
            mutationProb = 1;
            TFP = 1.5;
            GTmax = 45;
            GTmin = 15;
            offset = 10;
            E1_bool = true;
            E2_bool = true;
            E3_bool = true;
            cycle_time = 1;
            /*********************/

            vector=v;
            great=popNumber-replace;
            

            /*self_id=MapIni.neighbor[vector,id-1,0];
            right_id=MapIni.neighbor[vector,id-1,1];
            left_id=MapIni.neighbor[vector,id-1,2];

            MapIni.past[vector,self_id-1]=PreA;
            MapIni.past[vector,right_id-1]=PreB;
            MapIni.past[vector,left_id-1]=PreC;*/

            GTpast = new int [chromosomLength];
            GTpast[0]=PreA;
            if (PreB != -1)
            {
                GTpast[1] = PreB;
            }
            else
            {
                GTpast[1]=0;
            }

            if (PreC != -1)
            {
                GTpast[2] = PreC;
            }
            else
            {
                GTpast[2]=0;
            }

            if (QR == -1)
            {
                Qright = -1;
            }
            else
            {
                Qright = QR*10;
            }
            if (QL == -1)
            {
                Qleft = -1;
            }
            else
            {
                Qleft = QL*10;
            }
            
            //Simulator.UI.AddMessage("AI", "  Qright:" + Qright + "  Qleft:" + Qleft);

            if (AU == -1)
            {
                AvgUp = -1;
            }
            else
            {
                AvgUp = AU / 60;
            }
            if (AD == -1)
            {
                AvgDown = -1;
            }
            else
            {
                AvgDown = AD / 60;
            }

            fitValue = new double [popNumber];
            tempfitValue = new double [popNumber];

            result = new int [chromosomLength];

            return;
        }

        public void initialPopulation()
        {
            int i,j;
            Random ran = new Random(Guid.NewGuid().GetHashCode());

            chromosom = new int[popNumber,chromosomLength];
            replaceChro = new int[replace,chromosomLength];
            greatChro = new int[great,chromosomLength];

            for (i=0; i<popNumber; i++)
            {
                for (j=0; j<chromosomLength; j++)
                {
                    chromosom[i, j] = ran.Next(GTmin,GTmax);              //version 3
                    /*chromosom[i][j]=GTmin+rand()%(GTmax-GTmin);     //version 2*/
                    /*chromosom[i][j]=(GTpast[j]-geneOffset)+rand()%(geneOffset*2+1);
                    if(chromosom[i][j]<GTmin)
                        chromosom[i][j]=GTmin;
                    if(chromosom[i][j]>GTmax)
                        chromosom[i][j]=GTmax;*/                      //version 1

                    //cout << chromosom[i][j] << ' ';
                }
                //cout << endl;
            }
            return;
        }

        public void evolution()
        {
            int selectionA,selectionB;
            int i;

            fitness();

            for(i=0;i<replace;i+=2)
            {
                selectionA = selection();
                selectionB = selection();
                crossover(selectionA,selectionB,i);
            }

            for(i=0;i<replace;i++)
            {
                mutation(i);
            }

            findgreat();

            survivor();

            return;
        }

        public int selection()
        {
            int selection, temp;
            double cal=0;
            Random ran = new Random(Guid.NewGuid().GetHashCode());

            int t;
            t=(int)(fitValuetotal-1);
            temp = ran.Next(0,t);

            for(selection=0;selection<popNumber;selection++)
            {
                cal+=fitValue[selection];
                if(cal>=temp)
                {
                    return selection;
                }
            }
            return 0;
        }

        public void crossover(int selA, int selB, int t)
        {
            int cut, i, p;
            Random ran = new Random(Guid.NewGuid().GetHashCode());

            cut = ran.Next(0,chromosomLength-2);
            p = ran.Next(0,9);

            if(p<crossoverProb)
            {
                for(i=0;i<=cut;i++)
                {
                    replaceChro[t,i]=chromosom[selA,i];
                    replaceChro[t+1,i]=chromosom[selB,i];
                }
                for(i=cut+1;i<chromosomLength;i++)
                {
                    replaceChro[t,i]=chromosom[selB,i];
                    replaceChro[t+1,i]=chromosom[selA,i];
                }
            }
            else
            {
                for(i=0;i<chromosomLength;i++)
                {
                    replaceChro[t,i]=chromosom[selA,i];
                    replaceChro[t+1,i]=chromosom[selB,i];
                }
            }

            return;
        }

        public void mutation(int t)
        {
            int m, i, p;
            Random ran = new Random(Guid.NewGuid().GetHashCode());

            m=ran.Next(0,chromosomLength-1);
            p = ran.Next(0,9);

            if(p<mutationProb)
            {
                for(i=0;i<chromosomLength;i++)
                {
                    if(i==m)
                    {
                        replaceChro[t,i]=ran.Next(GTmin,GTmax);                  //version 3
                        //replaceChro[t][i]=GTmin+rand()%(GTmax-GTmin);      //version 2
                        /*replaceChro[t][i]=(GTpast[i]-geneOffset)+rand()%(geneOffset*2+1);
                        if(replaceChro[t][i]<GTmin)
                            replaceChro[t][i]=GTmin;
                        if(replaceChro[t][i]>GTmax)
                            replaceChro[t][i]=GTmax;*/           //version 1
                    }
                }
            }
            return;
        }

        public void findgreat()
        {
            int i, j, k=0, c;
            double s;

            for(i=0;i<popNumber;i++)
            {
                tempfitValue[i]=fitValue[i];
            }
            bubblesort(tempfitValue, popNumber);

            s = tempfitValue[great-1];

            for(i=0;i<popNumber;i++)
            {
                if(fitValue[i]<s)
                {
                    for(j=0;j<chromosomLength;j++)
                    {
                        greatChro[k,j]=chromosom[i,j];
                    }
                    k++;
                }
            }

            c=great-k;

            for(i=0;i<popNumber;i++)
            {
                if(k==great)
                {
                    break;
                }
                else if(fitValue[i]==s)
                {
                    for(j=0;j<chromosomLength;j++)
                    {
                        greatChro[k,j]=chromosom[i,j];
                    }
                    k++;
                }
            }

            return;
        }

        public void survivor()
        {
            int i, j;

            for(i=0;i<great;i++)
            {
                for(j=0;j<chromosomLength;j++)
                {
                    chromosom[i,j]=greatChro[i,j];
                }
            }

            for(i=0;i<replace;i++)
            {
                for(j=0;j<chromosomLength;j++)
                {
                    chromosom[i+great,j]=replaceChro[i,j];
                }
            }

            return;
        }

        public void fitness()
        {
            double E1 = 0, E2 = 0, E3 = 0;
            int i;

            fitValuetotal=0;

            for(i=0; i<popNumber; i++)
            {
                if((chromosom[i,0]<=(int)(Qright*TFP)&&chromosom[i,0]>=(int)(Qleft*TFP))
                   ||(chromosom[i,0]>=(int)(Qright*TFP)&&chromosom[i,0]<=(int)(Qleft*TFP)))
                {
                    E1 = Math.Abs(Math.Abs(chromosom[i,0]-(int)(Qright*TFP)) - Math.Abs(chromosom[i,0]-(int)(Qleft*TFP)))/2;
                    //E1 = (int(Qright*TFP)+int(Qleft*TFP))/2;
                }
                else
                {
                    E1 = Math.Abs(Math.Abs(chromosom[i,0]-(int)(Qright*TFP)) + Math.Abs(chromosom[i,0]-(int)(Qleft*TFP)))/2;
                    //E1 = (int(Qright*TFP)+int(Qleft*TFP))/2;
                }
                if (Qright == -1 && Qleft!=-1)
                {
                    E1 = Math.Abs(chromosom[i, 0] - (int)(Qleft * TFP));
                }
                else if (Qleft == -1 && Qright !=-1)
                {
                    E1 = Math.Abs(chromosom[i, 0] - (int)(Qright * TFP));
                }
                else if (Qleft == -1 && Qright == -1)
                {
                    E1 = 0;
                }


                if (AvgUp == -1 && AvgDown!=-1)
                {
                    E2 = (int)(chromosom[i, 0] * AvgDown + 0.5);
                }
                else if (AvgUp!=-1 && AvgDown == -1)
                {
                    E2 = (int)(chromosom[i, 0] * AvgUp + 0.5);
                }
                else if (AvgUp != -1 && AvgDown != -1)
                {
                    E2 = (int)(chromosom[i, 0] * AvgUp + chromosom[i, 0] * AvgDown + 0.5);
                }
                else if (AvgUp == -1 && AvgDown == -1)
                {
                    E2 = 0;
                }

                /*E3 = Math.Abs(chromosom[i,1]-chromosom[i,0]) + Math.Abs(chromosom[i,1]-GTpast[1])
                   + Math.Abs(chromosom[i,2]-chromosom[i,0]) + Math.Abs(chromosom[i,2]-GTpast[2]);
                if (GTpast[1] == -1)
                {
                    E3 = Math.Abs(chromosom[i, 2] - chromosom[i, 0]) + Math.Abs(chromosom[i, 2] - GTpast[2]);
                }
                if (GTpast[2] == -1)
                {
                    E3 = Math.Abs(chromosom[i, 1] - chromosom[i, 0]) + Math.Abs(chromosom[i, 1] - GTpast[1]);
                }

                if (E1_bool == false)
                {
                    E1 = 0;
                }
                if (E2_bool == false)
                {
                    E2 = 0;
                }
                if (E3_bool == false)
                {
                    E3 = 0;
                }*/

                fitValue[i] = E1*6 + E2*2 + E3;
                
                fitValuetotal+=fitValue[i];
            }

            return;
        }

        public void findans()
        {
            int i, f=0;
            int flag = 0;
            double s;

            for(i=0;i<popNumber;i++)
            {
                tempfitValue[i]=fitValue[i];
            }
            bubblesort(tempfitValue, popNumber);

            s = tempfitValue[0];

            for(i=0;i<popNumber;i++)
            {
                if(fitValue[i]==s&&flag==0)
                {
                    f=i;
                    flag = 1;
                }
            }

            for(i=0;i<chromosomLength;i++)
            {
                result[i]=chromosom[f,i];
            }
            //Console.WriteLine(result[0]);
            return;
        }

        public void bubblesort(double[] A,int l)
        {
            int i,j;
            double temp;

            for (j=0; j<l-1; j++)
            {
                for (i=0; i<l-1-j; i++)
                {
                    if (A[i]>A[i+1])
                    {
                        temp = A[i];
                        A[i] = A[i+1];
                        A[i+1] = temp;
                    }
                }
            }
        }

    }
}