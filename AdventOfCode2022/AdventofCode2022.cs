namespace AdventofCode{

class Program{

    public static int CheckAndConvertToInt(bool intString,string line,int indx)
        {   
            int r;

                if(intString)
                {
                    r = Convert.ToInt32(line.Substring(indx,2));
                } else{
                    r = Convert.ToInt32(line.Substring(indx,1));
                }

            return r;
        }

    static List<List<char>> ReadFileToListMatrix(string filnavn)
{

string input = File.ReadAllText(filnavn);
List<List<char>> masterList = new List<List<char>>();
List<char> subList = new List<char>();

foreach (var row in input.Split('\n'))
{
    foreach(char c in row)
    {
        subList.Add(c);
        
    }
    var j = subList;
    masterList.Add(j);
    subList.Clear();

    foreach(var k in masterList)
    {
        Console.WriteLine("test");
        foreach(var c in k)
        {

            Console.WriteLine("test2");
        }
    }
}

    return masterList;
}

    class DayOne
    {  


        public static List<int> MostCals(string filnavn)
        {

            int sum=0;
            List<int> list = new List<int>();
            foreach(string line in System.IO.File.ReadLines(@filnavn))
            {
                if(line!="")
                {
                sum += Convert.ToInt32(line);
                }
                if(line == "")
                {
                    list.Add(sum);
                    sum=0;
                }

            }

            return list;

        }


        

    }

    class DayTwo
    {
        public string filnavn = "";

        public int Tournament()
        {

            char rockOpp = 'A';
            char papOpp = 'B';
            char scissOpp = 'C';

            char myRock = 'X';
            char myPap = 'Y';
            char mySci = 'Z';

            int rockScore = 1;
            int papScore = 2;
            int sciScore = 3;

            int winScore = 6;
            int drawScore = 3;


            int score = 0;
            foreach(string line in System.IO.File.ReadLines(@filnavn))
            {
                if(line[0]==rockOpp)
                {
                    if(line[2]==myRock) //draw
                    {
                        score += rockScore+drawScore;
                    }
                    if(line[2]==myPap) //win
                    {
                        score+=papScore+winScore;
                    }

                    if(line[2]==mySci) //loose
                    {
                        score+=sciScore;
                    }
                }
                if(line[0]==papOpp)
                {
                    if(line[2]==mySci)
                    {
                        score += sciScore+winScore; //win
                    }
                    if(line[2]==myPap)
                    {
                        score+=papScore+drawScore; //draw
                    }                
                    if(line[2]==myRock) //loose
                    {
                        score+=rockScore;
                    }
                }
                if(line[0]==scissOpp)
                {
                    if(line[2]==myRock) //win
                    {
                        score+=rockScore+winScore;
                    }
                    if(line[2]==mySci) //draw
                    {
                        score+=sciScore+drawScore;
                    }
                    if(line[2]==myPap) //loose
                    {
                        score+=papScore;
                    }
                }
            }

            return score;
        }

        public int WinOrLose()
        {
            
            char rockOpp = 'A';
            char papOpp = 'B';
            char scissOpp = 'C';

            int rockScore = 1;
            int papScore = 2;
            int sciScore = 3;

            int winScore = 6;
            int drawScore = 3;


            int score = 0;
        foreach(string line in System.IO.File.ReadLines(@filnavn))
        {
            if(line[2]=='X') //loose
            {
                if(line[0]==rockOpp)
                {
                    score += sciScore;
                }
                if(line[0]==papOpp)
                {
                    score += rockScore;
                }
                if(line[0]==scissOpp)
                {
                    score+=papScore;
                }
            }
            if(line[2]=='Y') //draw
            {
                if(line[0]==rockOpp)
                {
                    score+=rockScore+drawScore;
                }
                if(line[0]==papOpp)
                {
                    score+= papScore+drawScore;
                }
                if(line[0]==scissOpp)
                {
                    score+= sciScore+drawScore;
                }
            }
            if(line[2]=='Z') //win
            {
                if(line[0]==rockOpp)
                {
                    score+=papScore+winScore;
                }
                if(line[0]==papOpp)
                {
                    score+= sciScore+winScore;
                }
                if(line[0]==scissOpp)
                {
                    score+= rockScore+winScore;
                }            
            }
        }
            return score;
        }



    }

    class DayThree
    {
        public string filnavn = "";

        public int RucksackPriority()
        {
        int sum =0;
        //a-z = 1-26
        //A-Z = 27-52
        string alf = "abcdefghijklmnopqrstuvwxyz";
        string ALF = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        foreach(string line in System.IO.File.ReadLines(@filnavn))
        {
            int cond = 0;
            string comp1 = line.Substring(0,line.Length/2);
            string comp2 = line.Substring(line.Length/2);
            foreach(char c in comp1)
            {
                foreach(char c2 in comp2)
                {
                    if(c==c2)
                    {
                        if(alf.Contains(c))
                        {
                        for(int i=0;i<alf.Length;i++)
                        {
                            if(alf[i]==c & cond!=1)
                            {
                                sum+=i+1;
                                cond=1;
                                break;
                            }   
                        }

                        }
                        if(ALF.Contains(c))
                        {
                            for(int i=0;i<ALF.Length;i++)
                            {
                                if(ALF[i]==c &cond != 1)
                                {
                                    sum+=i+27;
                                    cond=1;
                                    break;
                                }
                            }
                        }

                    }
                }
            }
        }   
            return sum;
        }


        public int SumGroupBadges()
        {
        string alf = "abcdefghijklmnopqrstuvwxyz";
        string ALF = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int sum = 0;
        int cond = 0;

        List<string> list = readFiletoList(filnavn);
        string[] str = list.ToArray();

        for(int i=0;i<str.Length;i+=3)
        {
            cond = 0;
            foreach(char c in str[i])
            {
                if(str[i+1].Contains(c)&str[i+2].Contains(c))
                {
                    for(int j=0;j<alf.Length;j++)
                    {
                        if(cond!=1)
                        {
                            if(c==alf[j])
                            {
                                sum+=j+1;
                                cond = 1;
                            }
                        }
                    }

                    for(int k=0;k<ALF.Length;k++)
                    {
                        if(c==ALF[k])
                        {
                            if(cond!=1)
                            {
                                cond = 1;
                                sum+=k+27;
                            }
                    }
                    }
                    break;
                }
                
            }
        }
                return sum;
        }


        public static List<string> readFiletoList(string filename)
        {   
        List<string> lst = new List<string>();
        foreach(string line in System.IO.File.ReadLines(@filename))
        {
            lst.Add(line);
        }
            return lst;
        }

    }

    class DayFour
        {

       public string filnavn = "";
        public int CheckDoubleEffort()
        {
            int counter = 0;
            int sum = 0;

            foreach(string line in System.IO.File.ReadLines(@filnavn))
            {
                string lines = line+" ";
                Console.WriteLine(lines+":lines");
                int dashIndx = line.IndexOf('-');
                int commaIndx = line.IndexOf(',');
                int lstDashIndx = line.LastIndexOf('-');

                bool isIntString = lines.Substring(0,2).All(char.IsDigit);
                bool isIntString2 = lines.Substring(dashIndx+1,2).All(char.IsDigit);
                bool isIntstring3 = lines.Substring(commaIndx+1,2).All(char.IsDigit);
                bool isIntstring4 = lines.Substring(lstDashIndx+1,1).All(char.IsDigit);
             //   Console.WriteLine("TEST:"+line.Substring(9,2));

                int r1 = CheckAndConvertToInt(isIntString,lines,0);
                int r2 = CheckAndConvertToInt(isIntString2,lines,dashIndx+1);
                int r3 = CheckAndConvertToInt(isIntstring3,lines,commaIndx+1);
                int r4 = CheckAndConvertToInt(isIntstring4,lines,lstDashIndx+1);

            //    Console.WriteLine("r1:"+r1+". r2:"+r2+". r3:"+r3+". r4:"+r4);


                int[] arr = Enumerable.Range(r1, r2-r1+1).ToArray();
                int[] arr2 = Enumerable.Range(r3,r4-r3+1).ToArray();
                
                //Console.WriteLine("arr:"+string.Join(",",arr)+". arr2:"+string.Join(",",arr2));
                
                if(CheckIfInsection(arr,arr2) || CheckIfInsection(arr2,arr))
                {
                    sum++;
                }


                counter++;
            
                

Console.WriteLine(counter);
            }
            return sum;
        }



        private bool CheckIfInsection(int[] arr1, int[] arr2)
        {
            
            int i = 0;
            //int j = 0;
            int p = arr2[0];
           // int count = 0;

            for (i = 0; i < arr2.Length; i++) {

                if(arr1.Contains(arr2[i]))
                {
                    return true;
                }
                //-------DEL 1 LØSNING-------//
                   /* for (j=0; j < arr1.Length;j++) { 
                      //  Console.WriteLine("arr2[i]="+arr2[i]+". arr1[j]="+arr1[j]);
                        if (arr2[i] == arr1[j])
                        {
                            count++;
                            break;
                        }*/
                    }
            /*}
            Console.WriteLine("arr1.Length="+arr1.Length+". arr2.Length="+arr2.Length);
            Console.WriteLine(count);
            if (count == arr2.Length)
            {
                Console.WriteLine("True");
                return true;
            } else {
                Console.WriteLine("False");
            }*/
            return false;

        }
        }

    public class DayFive{
    public string filnavn = "";
    private Stack<string>[] MakeStacks(int n)
    {

        Stack<string>[] stackList = new Stack<string>[n];


        for(int i=0;i<n;i++)
        {
               stackList[i] = new Stack<string>();
        }

        stackList[0].Push("C");
        stackList[0].Push("Z");
        stackList[0].Push("N");
        stackList[0].Push("B");
        stackList[0].Push("M");
        stackList[0].Push("W");
        stackList[0].Push("Q");
        stackList[0].Push("V");

        stackList[1].Push("H");
        stackList[1].Push("Z");
        stackList[1].Push("R");
        stackList[1].Push("W");
        stackList[1].Push("C");
        stackList[1].Push("B");

        stackList[2].Push("F");
        stackList[2].Push("Q");
        stackList[2].Push("R");
        stackList[2].Push("J");


        stackList[3].Push("Z");
        stackList[3].Push("S");
        stackList[3].Push("W");
        stackList[3].Push("H");
        stackList[3].Push("F");
        stackList[3].Push("N");
        stackList[3].Push("M");
        stackList[3].Push("T");

        stackList[4].Push("G");
        stackList[4].Push("F");
        stackList[4].Push("W");
        stackList[4].Push("L");
        stackList[4].Push("N");
        stackList[4].Push("Q");
        stackList[4].Push("P");

        stackList[5].Push("L");
        stackList[5].Push("P");
        stackList[5].Push("W");

        stackList[6].Push("V");
        stackList[6].Push("B");
        stackList[6].Push("D");
        stackList[6].Push("R");
        stackList[6].Push("G");
        stackList[6].Push("C");
        stackList[6].Push("Q");
        stackList[6].Push("J");

        stackList[7].Push("Z");
        stackList[7].Push("Q");
        stackList[7].Push("N");
        stackList[7].Push("B");
        stackList[7].Push("W");

        stackList[8].Push("H");
        stackList[8].Push("L");
        stackList[8].Push("F");
        stackList[8].Push("C");
        stackList[8].Push("G");
        stackList[8].Push("T");
        stackList[8].Push("J");
/*        foreach(Stack<string> stack in stackList)
        {

        }*/

        return stackList;
    }

    public Stack<string>[] ArrangeStack()
    {
        Stack<string>[] stackList = MakeStacks(9);

        int counter = 0;
        foreach(string line in System.IO.File.ReadLines(@filnavn))
        {
            counter++;
            string lines = line+" ";
            
            if(counter>9)
            {
                int n =0;
                int indxFrom = line.LastIndexOf('m')+2;
                int indxTo = line.LastIndexOf(' ')+1;
                bool isIntString = line.Substring(5,2).All(char.IsDigit);
                bool isIntString2 = line.Substring(indxFrom,2).All(char.IsDigit);
                bool isIntstring3 = lines.Substring(indxTo,2).All(char.IsDigit);
                int moves = CheckAndConvertToInt(isIntString,line,5);
                int fromStack = CheckAndConvertToInt(isIntString2,lines,indxFrom);
                int toStack = CheckAndConvertToInt(isIntstring3,lines,indxTo);
                Stack<string> mellomStack = new Stack<string>();

               while(n<moves)
                {
                  n++;
                  Console.WriteLine("n="+n);
                  if(moves>1)
                  {
                  string theCrate = stackList[fromStack-1].Pop();
                  mellomStack.Push(theCrate);
                  }
                  else
                  {
                  string theCrate = stackList[fromStack-1].Pop();
                  stackList[toStack-1].Push(theCrate);
                  /*Console.WriteLine("Moves:"+moves);
                  Console.WriteLine("Pop on "+fromStack+". Push on "+toStack);
                  Console.WriteLine("crates on stack:"+toStack+" = "+stackList[toStack-1].Count());*/
                  }
                }
                if(moves>1)
                {
                    while(n>0)
                    {
                        string theCrate = mellomStack.Pop();
                        stackList[toStack-1].Push(theCrate);
                        n--;

                    }
                }


                Console.WriteLine("---------next line---------");
            }

        }
        
        return stackList;

    }

    public void WriteStacks(Stack<string>[] stackList)
    {
        foreach(Stack<string> stabel in stackList)
        {
            Console.Write(stabel.Peek());
        }
    }    
        


    }   

    public class DaySix{

        static bool UniqueChars(List<char> s)
        {
            for(int i =0;i<s.Count;i++)
            {
                for(int j=i+1;j<s.Count;j++)
                {
                    if(s[i]==s[j])
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        public void FindStartMarker(string filen)
        {
            
            Queue<char> theQ = new Queue<char>();
            foreach(string linje in System.IO.File.ReadAllLines(@filen))
            {
                for(int i =0;i<linje.Length;i++)
            {

                if(theQ.Count == 14)
                {
                    theQ.Dequeue();
                }

                theQ.Enqueue(linje[i]);
                List<char> Qlist = theQ.ToList();
                
                bool theMark = UniqueChars(Qlist);
                if(theMark==true)
                {
                    int k = i+1;
                    Console.WriteLine(k);
                }
                
            }

            }
          //  Console.WriteLine(theQ.Count);

        }

    }

    public class DaySeven
    {

        public int SumTotalFIles(string filnavn)
        {
        
        //dirs samler mappene som: (path, filstørrelse)
        Dictionary<string,int> dirs = new Dictionary<string,int>();
        List<int> dirsTodelete = new List<int>();
        string path = "/home";
        dirs.Add(path,0);
        string dirName = "";
        int totalSum=0;
        int totalSpace = 70000000;
        int minSpace = 30000000;
        bool ls = false;
        foreach (string line in System.IO.File.ReadLines(@filnavn))
        {
            if(line[0]=='$')
            {
                if(line.Length>5)   //turn of ls, change the patch
                {
                    ls = false;
                    if(line[5]=='/')
                    {
                        path="/home";
                    }

                    else if(line[5]!='.') //change the path if cmd is "cd" and not "cd .."
                    {
                        dirName = line.Substring(5);
                        path=path+"/"+dirName;
                        dirs.Add(path,0);
                    }

                    else{   //catch if the cmd is "cd .."
                        int startInd = path.LastIndexOf('/');
                        path = path.Substring(0,startInd);
                    }
                }

                if(line=="$ ls")
                {
                    ls = true;
                }
            }

            if(ls)
            {
                int firstSpace = line.IndexOf(' ');
                bool isIntString = line.Substring(0,firstSpace).All(char.IsDigit); 
                if(isIntString)
                {
                string dir = path;
                int filesize = Convert.ToInt32(line.Substring(0,firstSpace));
                dirs[path]+=filesize;
                int freq = path.Count(path => (path == '/'));
                for(int i=0;i<freq-1;i++)
                {
                    int stopIndx = dir.LastIndexOf('/');
                    dir = dir.Substring(0,stopIndx);    
                    if(dir == "")
                    {
                        dir = "/home";
                    } 
                    dirs[dir]+=filesize;           
                }
                }
            }


           }

           int freeSpace = totalSpace - dirs["/home"];
           int minDirSize = minSpace - freeSpace;

           foreach(KeyValuePair <string,int> dir in dirs)
           {
                if(dir.Value <= 100000)
                {
                    totalSum+=dir.Value;
                }

                if(dir.Value >= minDirSize)
                {
                    dirsTodelete.Add(dir.Value);
                }
           }


    //--------- del 1 ---------\\
        //return totalSum;


    //--------- del 2 ---------\\

        return dirsTodelete.Min();
        

            
        }

        }


    public class DayEight {
        public int CheckVisibleTree(string filnavn)
        {
            int numTreesVisible = 0;
            List<List<char>> treeList = ReadFileToListMatrix(filnavn);

            for(int i = 0; i< treeList.Count;i++)
            {
                foreach(char c in treeList[i])
                {
                    Console.WriteLine(c);
                }
            }
            
            return numTreesVisible;


        }

    }

    }

    }



