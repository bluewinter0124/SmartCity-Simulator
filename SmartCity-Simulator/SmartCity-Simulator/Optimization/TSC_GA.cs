using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace signalAI
{
    class TSC_GA
    {
        public int id;
        public int vector;
        public int[] result;
        public int self_id, right_id, left_id;
        public int GTmax, GTmin;

        //private int PreGtA, PreGtB, PreGtC;
        private double Qright, Qleft;
        private double AvgUp, AvgDown;
        //private int popNumber;
        private int generation;
        private int popNumber;
        private int chromosomLength;
        private int geneOffset;
        private double TFP;
        private int replace;
        private int great;
        private int crossoverProb;
        private int mutationProb;
        private int[] GTpast;
        private int[,] chromosom;
        private int[] fitValue;
        private int[] tempfitValue;
        private int[,] replaceChro;
        private int[,] greatChro;
        private int fitValuetotal;


        public void GAmain(Map_initial MapIni, int id1, int v, double QR, double QL, double AU, double AD, int PreA, int PreB, int PreC)
        {
            int i;

            initial(MapIni, id1, v, QR, QL, AU, AD, PreA, PreB, PreC);
            initialPopulation();

            for(i=0;i<generation;i++)
            {
                evolution();
            }
            findans();

            return;
        }

        public void initial(Map_initial MapIni, int id1, int v, double QR, double QL, double AU, double AD, int PreA, int PreB, int PreC)
        {
            id=id1;
            vector=v;
            popNumber=100;
            generation=30;
            chromosomLength=3;
            geneOffset=10;
            TFP=1.5;
            replace=70;
            great=popNumber-replace;
            crossoverProb=8;
            mutationProb=1;
            GTmax=45;
            GTmin=15;

            self_id=MapIni.neighbor[vector,id-1,0];
            right_id=MapIni.neighbor[vector,id-1,1];
            left_id=MapIni.neighbor[vector,id-1,2];

            MapIni.past[vector,self_id-1]=PreA;
            MapIni.past[vector,right_id-1]=PreB;
            MapIni.past[vector,left_id-1]=PreC;

            GTpast = new int [chromosomLength];
            GTpast[0]=MapIni.past[vector,self_id-1];
            if(right_id!=0)
            {
                GTpast[1]=MapIni.past[vector,right_id-1];
            }
            else
            {
                GTpast[1]=0;
            }

            if(left_id!=0)
            {
                GTpast[2]=MapIni.past[vector,left_id-1];
            }
            else
            {
                GTpast[2]=0;
            }

            Qright=QR;
            Qleft=QL;
            AvgUp=AU/60;
            AvgDown=AD/60;

            fitValue = new int [popNumber];
            tempfitValue = new int [popNumber];

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
                    chromosom[i, j] = ran.Next(0,GTmax);                   //version 3
                    /*chromosom[i][j]=GTmin+rand()%(GTmax-GTmin);     //version 2*/
                    /*chromosom[i][j]=(GTpast[j]-geneOffset)+rand()%(geneOffset*2+1);
                    if(chromosom[i][j]<GTmin)
                        chromosom[i][j]=GTmin;
                    if(chromosom[i][j]>GTmax)
                        chromosom[i][j]=GTmax;*/          //version 1

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
            int selection, temp, cal=0;
            Random ran = new Random(Guid.NewGuid().GetHashCode());

            temp = ran.Next(0,fitValuetotal-1);

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
                        replaceChro[t,i]=ran.Next(1,GTmax);                     //version 3
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
            int i, j, s, k=0, c;

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
            int E1,E2,E3;
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

                E2 = (int)(chromosom[i,0]*AvgUp + chromosom[i,0]*AvgDown +0.5);

                E3 = Math.Abs(chromosom[i,1]-chromosom[i,0]) + Math.Abs(chromosom[i,1]-GTpast[1])
                   + Math.Abs(chromosom[i,2]-chromosom[i,0]) + Math.Abs(chromosom[i,2]-GTpast[2]);

                fitValue[i] = E1*6 + E2*2 + E3;
                //fitValue[i] = E1;
                fitValuetotal+=fitValue[i];
                //cout << chromosom[i][0] << ' ' << chromosom[i][1] << ' ' << chromosom[i][2] << ' ' << "E1=" <<E1 << ' ' << "E2=" << E2 << ' ' << "E3=" << E3 << ' ' << "fitValue=" << fitValue[i] << endl;
            }

            return;
        }

        public void findans()
        {
            int i, s, f=0;
            int flag = 0;

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

        public void bubblesort(int[] A,int l)
        {
            int temp,i,j;

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