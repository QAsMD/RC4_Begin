using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int deg = 0;
            System.IO.StreamWriter FileOut = new System.IO.StreamWriter("output.txt");
            System.IO.StreamWriter CFO = new System.IO.StreamWriter("CFO.txt");
            //k
          
            //S
                for (SS[0] = 0; SS[0] < N; SS[0]++)
                    for (SS[1] = 0; SS[1] < N; SS[1]++)
                        for (SS[2] = 0; SS[2] < N; SS[2]++)
                            for (SS[3] = 0; SS[3] < N; SS[3]++)
                            {
                                for (int kk = 0; kk < N; kk++)
                                {//r
                                    S[0] = SS[0];
                                    S[1] = SS[1];
                                    S[2] = SS[2];
                                    S[3] = SS[3];
                                    k = kk;
                                    i = 0;
                                    j = 0;
                                    
                                    List<List<int>> ControlList = new List<List<int>>();
                                    List<int> State;
                                    deg++;
                                    string output = "Прогон номер:" + deg.ToString() + "\n";
                                    for (int f = 0; f < r; f++)
                                    {
                                        output += count + ") i = " + (int)i + " j = " + (int)j + " k = " + (int)k;
                                        count++;
                                        for (int d = 0; d < S.Length; d++)
                                        {
                                            output += " S[" + d + "] = " + S[d];
                                        }

                                        if (ControlList.Count == 0)
                                            ControlList.Add(new List<int>(){i, j, k, S[0], S[1], S[2], S[3]});
                                        else{
                                            State = new List<int>() { i, j, k, S[0], S[1], S[2], S[3] };
                                            int indexCycle = ControlList.IndexOf(State);
                                            if (indexCycle >= 0)
                                            {
                                                string outputCFO = String.Format("Прогон номер: {0} \n\t Длина до цикла: {1}\n\t Длина цикла: {2}", deg, indexCycle, count-indexCycle);
                                                CFO.WriteLine(outputCFO);
                                                //break;
                                            }
         
                                        }
                                        i = (i + 1) % N;
                                        j = (j + S[i]) % N;
                                        k = (k + S[j]) % M;
                                        //   z = (byte)((S[(((S[i]) + S[j]) % N)] + k) % M);
                                        S[(S[i] + S[j]) % N] = (byte)((k + S[i]) % M);

                                        output += '\n';
                                        Console.WriteLine(output);
                                        FileOut.WriteLine(output);

                                        //  return z;            
                                    }
                                    count = 1;
                                    FileOut.WriteLine();
                                }
                                
                            }
                
            
            FileOut.Close();
            CFO.Close();
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
