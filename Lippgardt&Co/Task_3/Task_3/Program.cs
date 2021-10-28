using System;
using System.Collections.Generic;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { "mov a 5", "jnz a 1", "inc a" };
            var reg = Interpret(arr);
            foreach (var item in reg)
            {
                Console.WriteLine($"Register:{item.Key} Value={item.Value}");
            }
        }
        public static Dictionary<string, int> Interpret(string[] program)
        {
            Dictionary<string, int> registers = new Dictionary<string, int>();
            
            for (int i = 0; i < program.Length; i++)
            {
                string[] instruction = program[i].Split(' ');
                switch (instruction[0])
                {
                    case "mov":
                        if (int.TryParse(instruction[2], out int value))
                            registers[instruction[1]] = value;
                        else
                            registers[instruction[1]] = registers[instruction[2]];
                        break;
                    case "inc":
                        registers[instruction[1]]++;
                        break;
                    case "dec":
                        registers[instruction[1]]--;
                        break;
                    case "jnz":
                        if (int.TryParse(instruction[1], out int _value) && _value != 0 || registers.ContainsKey(instruction[1]) && registers[instruction[1]] != 0)
                            i += Convert.ToInt32(instruction[2]) -1;
                        break;
                        ///<summary>
                        ///Возможно я не правильно понял  и после выполнения этой команды ее нужно удалять из масива команд
                        ///так как она в данном конкретном случае обнуляет регеситр,но уж слишком странным способом.когда это было можно сделать mov a 0
                        ///(в общем при отрицателльном значение она блокирует выполение команд, пока содержимое регистра не обнулится)                          
                        ///</summary>
                }
            }
            return registers;
        }
    }
}