namespace Lanche;

using System; 

class URI {

    static void Main(string[] args) { 

        /**
         * Escreva a sua solução aqui
         * Code your solution here
         * Escriba su solución aquí
         */
        string line = Console.ReadLine();
        string[] values = line.Split(' ');
         
        int code = Convert.ToInt32(values[0]);
        int quantity = Convert.ToInt32(values[1]);
         
        double price = 0.0;
         
        switch(code) {
            case 1:
                price = 4.00;
                break;
            case 2:
                price = 4.50;
                break;
            case 3:
                price = 5.00;
                break; 
            case 4:
                price = 2.00;
                break;
            case 5:
                price = 1.50;
                break;
            default:
                price = 0.00;
                break;
        }
         
        double totalValue = quantity * price;
        
        
        Console.WriteLine("Total: R$ " + totalValue.ToString("F2"));
         
         

    }

}