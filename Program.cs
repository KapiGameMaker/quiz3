class Program{
    static void Main(){
        int stallAmount = int.Parse(Console.ReadLine());
        char[] stall = new char[stallAmount];
        bool isEnd = false;

        for(int i = 0 ; i < stall.Length ; i++)
        {
            stall[i] = '_';
        }

        while(!isEnd)
        {
            //int first = 0;
            //int second = 0;
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            if(first <= 0 && second <= 0){
                isEnd = false;
            }
            else if(first == second){
                switch(stallCheckOne(stall,first))
                {
                        case 1:
                            Console.WriteLine("The stall is reserved.");
                            break;
                        default:
                            stall[first-1] = 'X';
                            stallPrint(stall);
                            isEnd = IsStallAllReserve(stall);
                            break;
                }  
            }
            else if(first <= 0 && second > 0){
                switch(stallCheckOne(stall,second))
                {
                        case 1:
                            Console.WriteLine("The stall is reserved.");
                            break;
                        default:
                            stall[second-1] = 'X';
                            stallPrint(stall);
                            isEnd = IsStallAllReserve(stall);
                            break;
                }  
            }
            else if(first > 0 && second <= 0){
                switch(stallCheckOne(stall,first))
                {
                        case 1:
                            Console.WriteLine("The stall is reserved.");
                            break;
                        default:
                            stall[first-1] = 'X';
                            stallPrint(stall);
                            isEnd = IsStallAllReserve(stall);
                            break;
                }  
            }
            else{
                switch(stallCheckDouble(stall,first,second))
                {
                        case 1:
                            Console.WriteLine("The stall is reserved.");
                            break;
                        case 2:
                            Console.WriteLine("The entrance can't be reserved.");
                            break;
                        default:
                            stall[first-1] = 'X';
                            stall[second-1] = 'X';
                            stallPrint(stall);
                            isEnd = IsStallAllReserve(stall);
                            break;
                }    
            }
        }
    }

    static void stallPrint(char[] stall)
    {
        for(int i =0 ; i < stall.Length ; i++)
        {
            Console.Write(stall[i]);
        }
        Console.WriteLine("");
    }

    static int stallCheckOne(char[] stall, int number)
    {
        if(stall[number-1] != 'X')
        {
            return 0;
        }
        else return 1;
    }

    static int stallCheckDouble(char[] stall, int number1,int number2)
    {
        if(stall[number1-1] != 'X' && stall[number2-1] != 'X')
        {
            stall[number1-1] = 'X';
            stall[number2-1] = 'X';
            for(int i =0 ; i < stall.Length ; i++)
            {
                if(stall[i] != '_')
                {
                    return 2;
                }
            }
            return 0;
        }
        else return 1;
    }

    static bool IsStallAllReserve(char[] stall)
    {
        int counter = 0;
        for(int i =0 ; i < stall.Length ; i++)
        {
            if(stall[i] == '_') counter++;
        }
        if(counter == 1)
        {
            Console.WriteLine("All stall are reserved.");
            return true;
        }
        else return false;
    }
}
