using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace GGHN_PRGA
{
    class Program
    {
        public static byte kword(int i, int j, int m, int n, int r)
        {
            int N = (int)System.Math.Pow(2, n);
            int M = (int)System.Math.Pow(2, m);
            int[] S = new int[N];
            int[] SS = new int[N];
            int k = 0;
            int count = 1;
            BigInteger deg = 0;
            System.IO.StreamWriter FileOut = new System.IO.StreamWriter("output.txt");
            System.IO.StreamWriter CFO = new System.IO.StreamWriter("CFO.txt");
          //  System.IO.StreamWriter ZCFO = new System.IO.StreamWriter("Z CFO.txt");
            //k
          
            //S
                for (SS[0] = 0; SS[0] < N; SS[0]++)
                    for (SS[1] = 0; SS[1] < N; SS[1]++)
                        for (SS[2] = 0; SS[2] < N; SS[2]++)
                            for (SS[3] = 0; SS[3] < N; SS[3]++)
                                for (SS[4] = 0; SS[4] < N; SS[4]++)
                                    for (SS[5] = 0; SS[5] < N; SS[5]++)
                                        for (SS[6] = 0; SS[6] < N; SS[6]++)
                                            for (SS[7] = 0; SS[7] < N; SS[7]++)
                                                
                            {
                               
                                for (int kk = 0; kk < N; kk++)
                                {//r
                                    S[0] = SS[0];
                                    S[1] = SS[1];
                                    S[2] = SS[2];
                                    S[3] = SS[3];
                                    S[4] = SS[4];
                                    S[5] = SS[5];
                                    S[6] = SS[6];
                                    S[7] = SS[7];
                                    k = kk;
                                    i = 0;
                                    j = 0;

                                    bool stateZ = false;
                                    bool stateCFO = false;

                                    List<string> ControlList = new List<string>();
                                    List<string> ZControlList = new List<string>();
                                    deg++;
                                    count = 0;
                                    string output = "Прогон номер:" + deg.ToString() + "\r\n"; 
                                    for (int f = 0; f < r; f++)
                                    {
                                       output += "\t" + count + ") i = " + (int)i + " j = " + (int)j + " k = " + (int)k;
                                        count++;
                                        string stateCycle = String.Format("i={0};j={1};k={2};S=", i, j, k);
                                        for (int d = 0; d < S.Length; d++)
                                        {
                                            output += " S[" + d + "] = " + S[d];
                                            stateCycle += S[d];
                                        }

                                       
                                        if (ControlList.Count == 0)
                                            ControlList.Add(stateCycle);
                                        else
                                        {
                                            var indexCycle = ControlList.IndexOf(stateCycle);
                                            if (indexCycle >= 0 && !stateCFO)
                                            {
                                              //  FileOut.WriteLine(output);
                                                stateCFO = true;
                                               string outputCFO = String.Format("Прогон номер: {0} \n\t Длина до цикла: {1}\n\t Длина цикла: {2} \n Начальное состоние: S= {3} {4} {5} {6} {7} {8} {9} {10}, k = {11}\n", deg, indexCycle, count - indexCycle - 1,S[0], S[1], S[2], S[3], S[4], S[5], S[6], S[7],k);
                                              // string outputCFO = String.Format("Прогон номер: {0} \n\t Длина до цикла: {1}\n\t Длина цикла: {2} \n Начальное состоние: S= {3} {4} {5} {6} , k = {7}\n", deg, indexCycle, count - indexCycle - 1, S[0], S[1], S[2], S[3], k);

                                             
                                                    CFO.WriteLine(outputCFO);
                                                 //   break;
                                            }

                                        }


                                        i = (i + 1) % N;
                                        j = (j + S[i]) % N;
                                        k = (k + S[j]) % M;
                                        int z = (S[(((S[i]) + S[j]) % N)] + k) % M;
                                        S[(S[i] + S[j]) % N] = (byte)((k + S[i]) % M);


                                        output += "   z = " + z;
                                        output += "\r\n";
                                        if (stateCFO)
                                        {
                                            FileOut.WriteLine(output);
                                            break;
                                        }
                                      ////  output += " z=" + z;
                                      ////  output += "\r\n";

                                      //          string ZstateCycle = String.Format("z={0}",z);
                                                
                                      //          if (ZControlList.Count == 0)
                                      //              ZControlList.Add(ZstateCycle);
                                      //          else
                                      //          {
                                      //              var ZindexCycle = ZControlList.IndexOf(ZstateCycle);
                                      //             // if (ZindexCycle >= 0 && stateCFO && !stateZ)
                                      //              if(ZindexCycle >= 0)
                                      //              {
                                      //                  stateZ = true;
                                      //                  string ZoutputCFO = String.Format("Прогон номер: {0} \n\t Длина до цикла: {1}\n\t Длина цикла: {2}\n\n", deg, ZindexCycle, count - ZindexCycle - 1);
                                      //           //       ZCFO.WriteLine(ZoutputCFO);
                                                        
                                      //              }
                                      //          }




                                        

                                        //  return z;            
                                    }

                                    Console.WriteLine("Номер прохода:" + deg);
                                //    FileOut.WriteLine(output);
                                }
                                
                            }
                
            
           FileOut.Close();
            CFO.Close();
         //   ZCFO.Close();
            return 0;
        }

        static void Main(string[] args)
        {
            int i = 0;
            int j = 0;
         

            Console.Write("n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("m: ");
            int m = Convert.ToInt32(Console.ReadLine());

            

            Console.Write("r: ");
            int r = Convert.ToInt32(Console.ReadLine());

          

            kword(i,j,m,n,r);
            return;


        }



    }
}
